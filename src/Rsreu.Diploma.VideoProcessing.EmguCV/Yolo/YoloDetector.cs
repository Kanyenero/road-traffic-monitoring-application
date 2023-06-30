using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Util;
using Rsreu.Diploma.VideoProcessing.Events;
using Rsreu.Diploma.VideoProcessing.Models;
using System.Drawing;
using Backend = Emgu.CV.Dnn.Backend;

namespace Rsreu.Diploma.VideoProcessing.EmguCV.Yolo;

internal class YoloDetector : IDisposable
{
    private Net _model;
    private string[] _classes;
    private bool _disposed;

    public YoloDetector()
    {
        Version = YoloVersion.V3;
        Path = new()
        {
            Configuration = DefaultDirectories.YoloV3Config,
            Weights = DefaultDirectories.YoloV3Weights,
            CocoNames = DefaultDirectories.YoloV3CocoNames
        };
        Backend = Backend.Default;
        Target = Target.Cpu;
        ProcessingFrameSize = new(320, 320);
        NmsThreshold = 0.1f;
        ScoreThreshold = 0.1f;
        AllowedClasses = new[] { 2, 3, 5, 7 };
        ResizeFactor = 32;
    }

    public YoloVersion Version { get; private set; }

    public YoloPath Path { get; private set; }

    public Backend Backend { get; private set; }

    public Target Target { get; private set; }

    public Size ProcessingFrameSize { get; private set; }

    public float NmsThreshold { get; private set; }

    public float ScoreThreshold { get; private set; }

    public int[] AllowedClasses { get; private set; }

    public int ResizeFactor { get; private set; }

    public Rectangle Roi { get; set; }

    public event EventHandler<RoiChangeEventArgs> RoiResized;

    public void Initialize()
    {
        _model?.Dispose();
        _model = DnnInvoke.ReadNetFromDarknet(Path.Configuration, Path.Weights);
        _model.SetPreferableBackend(Backend);
        _model.SetPreferableTarget(Target);

        _classes = File.ReadAllLines(Path.CocoNames);

        Roi = Rectangle.Empty;
    }

    public void SetOptions(YoloDetectorOptions options)
    {
        if (Version != options.Version)
        {
            setVersion(options.Version);
        }
        if (Backend != options.Backend)
        {
            setBackend(options.Backend);
        }
        if (options.AllowedClasses is not null && options.AllowedClasses.Any())
        {
            AllowedClasses = options.AllowedClasses.ToArray();
        }

        ProcessingFrameSize = options.FrameSize;
        NmsThreshold = options.NmsThreshold;
        ScoreThreshold = options.ScoreThreshold;

        void setVersion(YoloVersion version)
        {
            switch (version)
            {
                case YoloVersion.V3:
                    Path.Configuration = DefaultDirectories.YoloV3Config;
                    Path.Weights = DefaultDirectories.YoloV3Weights;
                    Path.CocoNames = DefaultDirectories.YoloV3CocoNames;
                    break;

                case YoloVersion.V3Tiny:
                    Path.Configuration = DefaultDirectories.YoloV3TinyConfig;
                    Path.Weights = DefaultDirectories.YoloV3TinyWeights;
                    Path.CocoNames = DefaultDirectories.YoloV3TinyCocoNames;
                    break;

                case YoloVersion.V4:
                    Path.Configuration = DefaultDirectories.YoloV4Config;
                    Path.Weights = DefaultDirectories.YoloV4Weights;
                    Path.CocoNames = DefaultDirectories.YoloV4CocoNames;
                    break;

                case YoloVersion.V4Tiny:
                    Path.Configuration = DefaultDirectories.YoloV4TinyConfig;
                    Path.Weights = DefaultDirectories.YoloV4TinyWeights;
                    Path.CocoNames = DefaultDirectories.YoloV4TinyCocoNames;
                    break;

                default:
                    throw new ArgumentException($"Unexpected yolo version '{Enum.GetName(version)}'.", nameof(version));
            }

            Version = options.Version;

            Initialize();
        }
        void setBackend(Backend backend)
        {
            switch (backend)
            {
                case Backend.Default:
                    Backend = Backend.Default;
                    Target = Target.Cpu;
                    break;

                case Backend.Cuda:
                    Backend = Backend.Cuda;
                    Target = Target.Cuda;
                    break;

                default:
                    throw new ArgumentException($"Unexpected backend '{Enum.GetName(backend)}'.", nameof(backend));
            }

            if (_model is not null)
            {
                _model.SetPreferableBackend(Backend);
                _model.SetPreferableTarget(Target);
            }
        }
    }

    public bool Detect(Mat frame, out List<Detection> detections)
    {
        return Roi.IsEmpty || Roi.Size == frame.Size ? DetectOnRoiEmpty(frame, out detections) : DetectOnRoiExists(frame, out detections);
    }

    private bool DetectOnRoiExists(Mat frame, out List<Detection> detections)
    {
        var roiResized = ResizeRoi(Roi, ResizeFactor, frame.Size, out var newRoi);
        if (roiResized)
        {
            Roi = newRoi;
            RoiResized?.Invoke(this, new RoiChangeEventArgs(Roi));
        }

        var procFrame = new Mat(frame, Roi);
        detections = DetectInternal(procFrame);

        var roiScale = CalculateScale(Roi.Size, ProcessingFrameSize);
        ScaleDetectionsOnRoiExists(detections, roiScale, Roi.Location);

        return true;
    }

    private bool DetectOnRoiEmpty(Mat frame, out List<Detection> detections)
    {
        var procFrame = new Mat(frame, new Rectangle(0, 0, frame.Width, frame.Height));
        detections = DetectInternal(procFrame);

        var frameScale = CalculateScale(frame.Size, ProcessingFrameSize);
        ScaleDetectionsOnRoiEmpty(detections, frameScale);

        return true;
    }

    private List<Detection> DetectInternal(Mat procFrame)
    {
        CvInvoke.Resize(procFrame, procFrame, ProcessingFrameSize, interpolation: Inter.Cubic);

        var blob = DnnInvoke.BlobFromImage(procFrame, 1 / 255.0, swapRB: true);
        _model.SetInput(blob);

        var outputBlobs = new VectorOfMat();
        _model.Forward(outputBlobs, _model.UnconnectedOutLayersNames);

        var yoloResult = YoloHelper.GetYoloResult(outputBlobs, ScoreThreshold, NmsThreshold, ProcessingFrameSize);
        var detections = YoloHelper.GetDetections(yoloResult, _classes, AllowedClasses).ToArray();

        return detections.ToList();
    }

    private static void ScaleDetectionsOnRoiExists(List<Detection> detections, (double scaleX, double scaleY) scale, Point roiLocation)
    {
        foreach (var detection in detections)
        {
            var location = detection.BoundingBox.Location;
            var size = detection.BoundingBox.Size;

            var xroi = (int)(location.X * scale.scaleX);
            var yroi = (int)(location.Y * scale.scaleY);

            var scaledLocation = new Point(xroi + roiLocation.X, yroi + roiLocation.Y);
            var scaledSize = new Size((int)(size.Width * scale.scaleX), (int)(size.Height * scale.scaleY));

            detection.BoundingBox = new(scaledLocation, scaledSize);
        }
    }

    private static void ScaleDetectionsOnRoiEmpty(List<Detection> detections, (double scaleX, double scaleY) scale)
    {
        foreach (var detection in detections)
        {
            var location = detection.BoundingBox.Location;
            var size = detection.BoundingBox.Size;

            var scaledLocation = new Point((int)(location.X * scale.scaleX), (int)(location.Y * scale.scaleY));
            var scaledSize = new Size((int)(size.Width * scale.scaleX), (int)(size.Height * scale.scaleY));

            detection.BoundingBox = new(scaledLocation, scaledSize);
        }
    }

    public static (double scaleX, double scaleY) CalculateScale(Size size1, Size size2)
    {
        var scaleX = (double)size1.Width / size2.Width;
        var scaleY = (double)size1.Height / size2.Height;

        return (scaleX, scaleY);
    }

    public static bool ResizeRoi(Rectangle roi, int resizeFactor, Size limit, out Rectangle result)
    {
        if (roi.Width % resizeFactor == 0 || roi.Height % resizeFactor == 0)
        {
            result = roi;
            return false;
        }

        var width = (int)FindClosestDivisible(roi.Width, resizeFactor);
        var height = (int)FindClosestDivisible(roi.Height, resizeFactor);

        var right = roi.X + width;
        var bottom = roi.Y + height;

        if (right > limit.Width)
        {
            width -= right - limit.Width;
        }
        if (bottom > limit.Height)
        {
            height -= bottom - limit.Height;
        }

        result = new Rectangle(roi.X, roi.Y, width, height);
        return true;
    }

    private static double FindClosestDivisible(double dividend, double divisor)
    {
        var output = Math.Round(dividend / divisor);

        if (output == 0 && dividend > 0)
        {
            output += 1;
        }

        return output *= divisor;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _model.Dispose();
            _disposed = true;
        }
    }
}

using Emgu.CV;
using Rsreu.Diploma.VideoProcessing.EmguCV.Yolo;
using Rsreu.Diploma.VideoProcessing.Models;
using Rsreu.Diploma.VideoProcessing.Sort;
using System.Drawing;

namespace Rsreu.Diploma.VideoProcessing.EmguCV;

public class MultiObjectTracker : IDisposable
{
    private YoloDetector _detector;
    private SortTracker _tracker;
    private bool _disposed;

    public MultiObjectTracker()
    {
        _detector = new YoloDetector();
        _tracker = new SortTracker();
        FrameInterval = 1;
    }

    public Rectangle Roi
    {
        get => _detector.Roi;
        set => _detector.Roi = value;
    }

    public int FrameNumber { get; set; }

    public int FrameInterval { get; private set; }

    public TrackerStats Stats => new(_tracker.TrackCount);

    public void Initialize()
    {
        if (_disposed)
        {
            _detector = new YoloDetector();
            _tracker = new SortTracker();
            _disposed = false;
        }

        _detector.Initialize();

        FrameNumber = 0;
    }

    public void SetOptions(MultiObjectTrackerOptions options)
    {
        if (options.DetectorFrameInterval.HasValue)
        {
            FrameInterval = options.DetectorFrameInterval.Value;
        }
        if (options.YoloDetectorOptions is not null)
        {
            _detector.SetOptions(options.YoloDetectorOptions);
        }
    }

    public IEnumerable<Track> Update(Mat frame)
    {
        var detections = new List<Detection>();

        if (NeedToRunDetector())
        {
            _detector.Detect(frame, out detections);
        }

        return _tracker.Track(detections);
    }

    private bool NeedToRunDetector()
    {
        return FrameNumber % FrameInterval == 0;
    }

    public void Reset()
    {
        _tracker.Clear();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _detector.Dispose();
            _disposed = true;
        }
    }
}

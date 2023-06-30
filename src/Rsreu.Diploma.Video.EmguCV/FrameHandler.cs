using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Rsreu.Diploma.Video.Models;
using Rsreu.Diploma.VideoProcessing.EmguCV;
using Rsreu.Diploma.VideoProcessing.Models;
using System.Drawing;

namespace Rsreu.Diploma.Video.EmguCV;

internal class FrameHandler : IDisposable
{
    private VideoMetadata _metadata;
    private MultiObjectTracker _tracker;
    private bool _disposed;

    public FrameHandler(FrameHandlerOptions options)
    {
        _tracker = new MultiObjectTracker();

        SetOptions(options);
    }

    public int FrameNumber
    {
        get => _tracker.FrameNumber;
        set => _tracker.FrameNumber = value;
    }

    public void SetOptions(FrameHandlerOptions options)
    {
        if (options.MultiObjectTrackerOptions is not null)
        {
            _tracker.SetOptions(options.MultiObjectTrackerOptions);
        }
    }

    public void SetRoi(Rectangle roi)
    {
        _tracker.Roi = roi;
    }

    internal void Initialize(VideoMetadata metadata)
    {
        _metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));

        if (_disposed)
        {
            _tracker = new MultiObjectTracker();
        }

        _tracker.Initialize();
    }

    internal bool Handle(Mat input, out Mat output)
    {
        if (_metadata is null)
        {
            throw new InvalidOperationException($"{nameof(_metadata)} was null.");
        }
        if (_tracker is null)
        {
            throw new InvalidOperationException($"{nameof(_tracker)} was null.");
        }

        return InternalHandle(input, out output);
    }

    private bool InternalHandle(Mat inputFrame, out Mat outputFrame)
    {
        var tracks = _tracker.Update(inputFrame);
        DrawTracks(inputFrame, tracks);

        var stats = _tracker.Stats;
        DrawStats(inputFrame, stats);

        var roi = _tracker.Roi;
        DrawRoi(inputFrame, roi);

        CvInvoke.Circle(inputFrame, _tracker.Roi.Location, 1, new MCvScalar(0, 255, 255), thickness: 2);

        outputFrame = inputFrame.Clone();

        return true;
    }

    private static void DrawTracks(IInputOutputArray frame, IEnumerable<Track> tracks)
    {
        foreach (var track in tracks)
        {
            var bbox = Rectangle.Round(track.Prediction);

            CvInvoke.Rectangle(frame, bbox, new MCvScalar(0, 255, 0), thickness: 2);
            CvInvoke.PutText(frame, track.TrackId + " " + track.Detection?.ClassName, new Point(bbox.X, bbox.Y - 3), FontFace.HersheySimplex, 1.0, new MCvScalar(0, 0, 255), thickness: 2);
        }
    }

    private static void DrawStats(IInputOutputArray frame, TrackerStats stats)
    {
        CvInvoke.PutText(frame, stats.ToString(), new Point(5, 30), FontFace.HersheySimplex, 1.0, new MCvScalar(0, 0, 255), thickness: 2);
    }

    private static void DrawRoi(IInputOutputArray frame, Rectangle roi)
    {
        CvInvoke.Rectangle(frame, roi, new MCvScalar(0, 220, 220), thickness: 1);
    }

    public void Reset()
    {
        _tracker.Reset();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _tracker.Dispose();
            _disposed = true;
        }
    }
}

//using Rsreu.Diploma.Extensions;
//using Rsreu.Diploma.Video.EmguCV.Models;
//using Rsreu.Diploma.Video.EmguCV.Options;
//using System.Drawing;

//namespace Rsreu.Diploma.VideoProcessing.EmguCV;

//internal class CvKalmanMultiTracker : IDisposable
//{
//    private readonly List<CvKalmanTracker> _trackers;
//    private Rectangle _roi;
//    private Rectangle _innerRoi;
//    private bool _disposed;

//    public CvKalmanMultiTracker() 
//    {
//        _trackers = new List<CvKalmanTracker>();

//        IouThreshold = 0.75f;
//        MinAliveIterations = 10;
//    }

//    public bool HasActiveTracks => _trackers.Count > 0;

//    public int Count => _trackers.Count;

//    public int TotalCount { get; private set; }

//    public int TrackId { get; private set; }

//    public int MinAliveIterations { get; set; }

//    public Rectangle Roi
//    {
//        get => _roi;
//        set
//        {
//            _roi = value;
//            _innerRoi = new Rectangle(_roi.X + 10, _roi.Y + 10, _roi.Width - 20, _roi.Height - 20);
//        }
//    }

//    public Rectangle InnerRoi { get; private set; }

//    public float IouThreshold { get; set; }

//    public void SetOptions(KalmanMultiTrackerOptions options)
//    {
//        IouThreshold = options.IntersectionOverUnionThreshold;
//        MinAliveIterations = options.MinAliveIterations;
//    }

//    public void Initialize(Size frameSize)
//    {
//        if (Roi.IsEmpty)
//        {
//            Roi = new Rectangle(10, 10, frameSize.Width - 20, frameSize.Height - 20);
//        }

//        Clear();
//    }

//    public void AddTracks(IEnumerable<Detection> detections)
//    {
//        foreach (var detection in detections)
//        {
//            if (CanAddTracker(detection.BoundingBox))
//            {
//                var track = new Track(TrackId++)
//                {
//                    ClassName = detection.ClassName,
//                    Detection = detection.BoundingBox,
//                };

//                Add(new CvKalmanTracker(track, MinAliveIterations));
//            }
//        }
//    }

//    public bool CanAddTracker(Rectangle measurement)
//    {
//        return !TryGetTrackerByMeasurement(measurement, out var _);
//    }

//    public void Add(CvKalmanTracker tracker)
//    {
//        _trackers.Add(tracker);

//        TotalCount++;
//    }

//    public void Correct(IEnumerable<Rectangle> measurements)
//    {
//        foreach(var measurement in measurements)
//        {
//            var trackerExists = TryGetTrackerByMeasurement(measurement, out var tracker);
//            if (trackerExists)
//            {
//                tracker.Correct(measurement);
//            }
//        }
//    }

//    private bool TryGetTrackerByMeasurement(Rectangle measurement, out CvKalmanTracker result)
//    {
//        foreach (var tracker in _trackers)
//        {
//            var physicallySame = PhysicalComparison(tracker.Track, measurement);
//            if (physicallySame)
//            {
//                result = tracker;
//                return true;
//            }
//        }

//        result = null;
//        return false;
//    }

//    private bool PhysicalComparison(Track track, Rectangle measurement)
//    {
//        var iouEstimated = track.Estimation.IntersectionOverUnion(measurement);
//        //var iouPredicted = track.Prediction.IntersectionOverUnion(measurement);

//        return iouEstimated > IouThreshold/* || iouPredicted > IouThreshold*/;
//    }

//    public IEnumerable<Track> Predict()
//    {
//        RemoveExpiredTrackers();

//        foreach (var tracker in _trackers)
//        {
//            yield return tracker.Predict();
//        }
//    }

//    private void RemoveExpiredTrackers()
//    {
//        var indexesToRemove = GetTrackersToRemove();

//        foreach (var index in indexesToRemove)
//        {
//            _trackers.RemoveAt(index);
//        }
//    }

//    private IEnumerable<int> GetTrackersToRemove()
//    {
//        for (var i = 0; i < _trackers.Count; i++)
//        {
//            var tracker = _trackers[i];

//            if (tracker.CanBeRemoved && OutOfRoi(_innerRoi, tracker.Track.Detection))
//            {
//                yield return i;
//            }
//        }
//    }

//    private static bool OutOfRoi(Rectangle roi, Rectangle bbox)
//    {
//        var center = bbox.Center();

//        return center.X > roi.Right || center.X < roi.Left || center.Y > roi.Bottom || center.Y < roi.Top;
//    }

//    public void Clear()
//    {
//        _trackers.Clear();

//        TrackId = 0;
//        TotalCount = 0;
//    }

//    public void Dispose()
//    {
//        if (!_disposed)
//        {
//            foreach (var tracker in _trackers)
//            {
//                tracker.Dispose();
//            }

//            _disposed = true;
//        }
//    }
//}

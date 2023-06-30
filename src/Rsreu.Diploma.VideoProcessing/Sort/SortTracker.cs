using HungarianAlgorithm;
using Rsreu.Diploma.Extensions;
using Rsreu.Diploma.VideoProcessing.Enumerations;
using Rsreu.Diploma.VideoProcessing.Models;
using Rsreu.Diploma.VideoProcessing.Sort.Kalman;
using System.Drawing;

namespace Rsreu.Diploma.VideoProcessing.Sort;

public class SortTracker
{
    private readonly Dictionary<int, (Track Track, KalmanBoxTracker Tracker)> _trackers;
    private int _trackerIndex = 1;

    public SortTracker(float iouThreshold = 0.3f, int maxMisses = 3)
    {
        _trackers = new Dictionary<int, (Track Track, KalmanBoxTracker Tracker)>();
        IouThreshold = iouThreshold;
        MaxMisses = maxMisses;
    }

    public float IouThreshold { get; private set; }

    public int MaxMisses { get; private set; }

    public int TrackCount { get; private set; }

    public void SetOptions(SortTrackerOptions options)
    {
        IouThreshold = options.IouThreshold;
        MaxMisses = options.MaxMisses;
    }

    public IEnumerable<Track> Track(List<Detection> detections)
    {
        Dictionary<int, Detection> matchedDetections;
        ICollection<Detection> unmatchedDetections;

        var predictionsExists = TryGetPredictions(out var predictions);
        if (!predictionsExists)
        {
            matchedDetections = new();
            unmatchedDetections = detections;
        }

        IEnumerable<KeyValuePair<int, (Track Track, KalmanBoxTracker Tracker)>> removedTracks = null;

        var matchedDetectionsExists = TryMatchDetectionsWithPredictions(detections, predictions, out matchedDetections, out unmatchedDetections);
        if (matchedDetectionsExists)
        {
            var activeTracksExists = TryGetActiveTracks(matchedDetections, predictions, out var activeTracks);
            if (activeTracksExists)
            {
                var missedTracksUpdated = TryUpdateMissedTracks(activeTracks, out var missedTracks);
                if (missedTracksUpdated)
                {
                    var missedTracksRemoved = TryRemoveTracks(out removedTracks);
                    AddTracks(unmatchedDetections);

                    if (missedTracksRemoved)
                    {
                        return _trackers.Select(track => track.Value.Track).Concat(removedTracks.Select(track => track.Value.Track));
                    }

                    return _trackers.Select(track => track.Value.Track);
                }
            }
        }

        AddTracks(unmatchedDetections);

        return _trackers.Select(track => track.Value.Track);

        #region local functions
        bool TryGetPredictions(out Dictionary<int, RectangleF> predictions)
        {
            predictions = new Dictionary<int, RectangleF>();

            foreach (var tracker in _trackers)
            {
                var prediction = tracker.Value.Tracker.Predict();
                predictions.Add(tracker.Key, prediction);

                tracker.Value.Track.Prediction = prediction;
            }

            return predictions.Count > 0;
        }
        bool TryMatchDetectionsWithPredictions(List<Detection> detections, Dictionary<int, RectangleF> predictions, out Dictionary<int, Detection> matchedDetections, out ICollection<Detection> unmatchedDetections)
        {
            if (detections.Count == 0)
            {
                matchedDetections = null;
                unmatchedDetections = null;
                return false;
            }

            ICollection<RectangleF> bboxPredictions = predictions.Values;

            var matrix = detections.SelectMany(detection => bboxPredictions.Select(bboxPrediction =>
            {
                var iou = detection.BoundingBox.IntersectionOverUnion(bboxPrediction);
                return (int)(100 * -iou);
            })).ToArray(detections.Count, bboxPredictions.Count);

            if (detections.Count > bboxPredictions.Count)
            {
                matrix = Enumerable.Range(0, detections.Count)
                    .SelectMany(row => Enumerable.Range(0, bboxPredictions.Count).Select(col => matrix[row, col]).Concat(new int[detections.Count - bboxPredictions.Count]))
                    .ToArray(detections.Count, detections.Count);
            }

            var originalMatrix = (int[,])matrix.Clone();
            var minimalThreshold = (int)(-IouThreshold * 100);
            var assignments = matrix.FindAssignments();
            var boxTrackerMapping = assignments.Select((ti, bi) => (bi, ti))
                .Where(bt => bt.ti < bboxPredictions.Count && originalMatrix[bt.bi, bt.ti] <= minimalThreshold)
                .ToDictionary(bt => bt.bi, bt => bt.ti);

            unmatchedDetections = detections.Where((_, index) => !boxTrackerMapping.ContainsKey(index)).ToList();
            matchedDetections = detections.Select((detection, index) => boxTrackerMapping.TryGetValue(index, out var tracker) ? (Tracker: tracker, Detection: detection) : (Tracker: -1, Detection: null))
                .Where(td => td.Tracker != -1)
                .ToDictionary(td => td.Tracker, tb => tb.Detection);

            return matchedDetections.Any();
        }
        bool TryGetActiveTracks(Dictionary<int, Detection> matchedDetections, Dictionary<int, RectangleF> predictions, out HashSet<int> activeTracks)
        {
            if (matchedDetections.Count == 0)
            {
                activeTracks = null;
                return false;
            }

            activeTracks = new HashSet<int>();

            foreach (var item in matchedDetections)
            {
                var prediction = predictions.ElementAt(item.Key);
                var track = _trackers[prediction.Key];
                track.Track.Misses = 0;
                track.Track.State = TrackState.Active;
                track.Tracker.Update(item.Value.BoundingBox);
                track.Track.Prediction = prediction.Value;

                activeTracks.Add(track.Track.TrackId);
            }

            TrackCount = activeTracks.Count;
            return true;
        }
        bool TryUpdateMissedTracks(HashSet<int> activeTracks, out IEnumerable<KeyValuePair<int, (Track Track, KalmanBoxTracker Tracker)>> missedTracks)
        {
            missedTracks = _trackers.Where(x => !activeTracks.Contains(x.Key));

            foreach (var missedTrack in missedTracks)
            {
                missedTrack.Value.Track.Misses++;
                missedTrack.Value.Track.TotalMisses++;
                missedTrack.Value.Track.State = TrackState.Ending;
            }

            return missedTracks.Any();
        }
        bool TryRemoveTracks(out IEnumerable<KeyValuePair<int, (Track Track, KalmanBoxTracker Tracker)>> toRemoveTracks)
        {
            toRemoveTracks = _trackers.Where(x => x.Value.Track.Misses > MaxMisses).ToList();

            foreach (var toRemoveTrack in toRemoveTracks)
            {
                toRemoveTrack.Value.Track.State = TrackState.Ended;
                _trackers.Remove(toRemoveTrack.Key);
            }

            return toRemoveTracks.Any();
        }
        void AddTracks(ICollection<Detection> unmatchedDetections)
        {
            if (unmatchedDetections == null)
            {
                return;
            }

            foreach (var unmatchedDetection in unmatchedDetections)
            {
                var track = new Track
                {
                    TrackId = _trackerIndex++,
                    Misses = 0,
                    State = TrackState.Started,
                    TotalMisses = 0,
                    Prediction = unmatchedDetection.BoundingBox,
                    Detection = unmatchedDetection
                };

                _trackers.Add(track.TrackId, (track, new KalmanBoxTracker(unmatchedDetection.BoundingBox)));
            }
        }
        #endregion
    }

    public void Clear()
    {
        _trackers.Clear();
        _trackerIndex = 1;
    }
}

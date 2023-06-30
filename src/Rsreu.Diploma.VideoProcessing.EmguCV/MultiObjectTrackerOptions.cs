using Rsreu.Diploma.VideoProcessing.EmguCV.Yolo;
using Rsreu.Diploma.VideoProcessing.Sort;

namespace Rsreu.Diploma.VideoProcessing.EmguCV;

public class MultiObjectTrackerOptions
{
    public int? DetectorFrameInterval { get; set; }

    public YoloDetectorOptions YoloDetectorOptions { get; set; }

    public SortTrackerOptions SortTrackerOptions { get; set; }
}

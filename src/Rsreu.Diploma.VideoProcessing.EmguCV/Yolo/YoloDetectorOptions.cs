using Emgu.CV.Dnn;
using System.Drawing;

namespace Rsreu.Diploma.VideoProcessing.EmguCV.Yolo;

public class YoloDetectorOptions
{
    public YoloVersion Version { get; set; }

    public Size FrameSize { get; set; }

    public Backend Backend { get; set; }

    public Target Target { get; set; }

    public float NmsThreshold { get; set; }

    public float ScoreThreshold { get; set; }

    public IEnumerable<int> AllowedClasses { get; set; }
}

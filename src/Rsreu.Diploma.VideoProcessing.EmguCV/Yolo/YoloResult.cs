using System.Drawing;

namespace Rsreu.Diploma.VideoProcessing.EmguCV.Yolo;

public class YoloResult
{
    public Rectangle[] BoundingBoxes { get; set; }

    public float[] Scores { get; set; }

    public int[] ClassIndicies { get; set; }

    public int[] ThresholdedBoundingBoxIndices { get; set; }
}

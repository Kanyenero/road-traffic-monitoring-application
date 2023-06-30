using System.Drawing;

namespace Rsreu.Diploma.VideoProcessing.Models;

public record Detection
{
    public string ClassName { get; set; }

    public RectangleF BoundingBox { get; set; }

    public float Score { get; set; }

    public override string ToString() => $"Class={ClassName},Score={Score:0.00},Location={BoundingBox.Location}";
}

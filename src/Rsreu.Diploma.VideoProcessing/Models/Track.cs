using Rsreu.Diploma.VideoProcessing.Enumerations;
using System.Drawing;

namespace Rsreu.Diploma.VideoProcessing.Models;

public record Track
{
    public int TrackId { get; set; }

    public int TotalMisses { get; set; }

    public int Misses { get; set; }

    public TrackState State { get; set; }

    public RectangleF Prediction { get; set; }

    public Detection Detection { get; set; }

    public override string ToString() => $"Id={TrackId},Class={Detection?.ClassName},Location={Prediction.Location}";
}

using System.Drawing;

namespace Rsreu.Diploma.VideoProcessing.Events;

public class RoiChangeEventArgs : EventArgs
{
    public RoiChangeEventArgs(Rectangle roi)
    {
        Roi = roi;
    }

    public Rectangle Roi { get; set; }
}

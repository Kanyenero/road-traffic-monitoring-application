using System.Drawing;

namespace Rsreu.Diploma.Video.Events;

public class FrameEventArgs : EventArgs
{
    public Bitmap Frame { get; set; }

    public int FrameNumber { get; set; }

    public int Downtime { get; set; }

    public int Busytime { get; set; }
}

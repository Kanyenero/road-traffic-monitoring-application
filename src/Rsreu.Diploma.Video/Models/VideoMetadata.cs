using System.Drawing;

namespace Rsreu.Diploma.Video.Models;

public class VideoMetadata
{
    public string FileName { get; set; }

    public string Codec { get; set; }

    public int FourCC { get; set; }

    public int FrameRate { get; set; }

    public int FrameCount { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public Size FrameSize => new(Width, Height);

    public override string ToString() => $"{{Name={FileName},FrameRate={FrameRate},Size={FrameSize}}}";
}

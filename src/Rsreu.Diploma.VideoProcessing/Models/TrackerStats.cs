namespace Rsreu.Diploma.VideoProcessing.Models;

public readonly struct TrackerStats
{
    public static readonly TrackerStats Empty;

    public TrackerStats(int frameObjectCount)
    {
        FrameObjectCount = frameObjectCount;
    }

    public int FrameObjectCount { get; }

    public override string ToString() => $"Active={FrameObjectCount}";
}

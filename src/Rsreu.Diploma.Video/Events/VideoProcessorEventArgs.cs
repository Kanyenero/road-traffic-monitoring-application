namespace Rsreu.Diploma.Video.Events;

public class VideoProcessorEventArgs : EventArgs
{
    public string Error { get; set; }

    public bool HasError => !string.IsNullOrEmpty(Error);

    public static new VideoProcessorEventArgs Empty => new();
}

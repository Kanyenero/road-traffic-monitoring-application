using Rsreu.Diploma.Video.Enumerations;
using Rsreu.Diploma.Video.Events;
using Rsreu.Diploma.Video.Models;
using System.Drawing;

namespace Rsreu.Diploma.Video.Contracts;

public interface IVideoProcessor
{
    VideoMetadata VideoSourceInfo { get; }

    GrabState GrabState { get; }

    bool IsReady { get; }

    bool ProcessingEnabled { get; set; }

    bool WritingEnabled { get; set; }

    event EventHandler<VideoProcessorEventArgs> Ready;
    event EventHandler<FrameEventArgs> FrameReady;
    event EventHandler<EventArgs> FramesOver;

    void SetVideoSource(string value);

    void SetOutputDirectory(string value);

    void SetRoi(Rectangle roi);

    void SetConfiguration(IVideoProcessorConfiguration configuration);

    void Start();

    void Pause();

    void Stop();

    void QueryFirstFrame();
}

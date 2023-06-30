using Rsreu.Diploma.Video.Contracts;

namespace Rsreu.Diploma.Video.EmguCV;

public class VideoProcessorConfiguration : IVideoProcessorConfiguration
{
    public FrameHandlerOptions FrameHandlerOptions { get; set; }

    public FrameProviderOptions FrameProviderOptions { get; set; }

    public FrameWriterOptions FrameWriterOptions { get; set; }
}

using Emgu.CV;
using Emgu.CV.CvEnum;
using Rsreu.Diploma.Video.EmguCV.Extensions;
using Rsreu.Diploma.Video.Models;

namespace Rsreu.Diploma.Video.EmguCV;

internal class FrameProvider : IDisposable
{
    private VideoCapture _videoCapture;
    private VideoMetadata _metadata;
    private bool _disposed;

    public FrameProvider()
    {
    }

    public FrameProvider(FrameProviderOptions options)
    {
        SetOptions(options);
    }

    public void SetOptions(FrameProviderOptions options)
    {
        throw new NotImplementedException();
    }

    public VideoMetadata Metadata 
    {
        get => _metadata;
    }

    public int FrameNumber 
    {
        get => (int)_videoCapture.GetCaptureProperty(CapProp.PosFrames);
    }

    internal void Initialize(string videoSource)
    {
        _videoCapture?.Dispose();
        _videoCapture = new VideoCapture(videoSource);

        _metadata = _videoCapture.GetMetadata();
        _metadata.FileName = Path.GetFileName(videoSource);
    }

    public bool Read(IOutputArray frame)
    {
        return _videoCapture.Read(frame);
    }

    public bool QueryFirst(IOutputArray frame)
    {
        return _videoCapture.SetCaptureProperty(CapProp.PosFrames, 0) && _videoCapture.Read(frame) && _videoCapture.SetCaptureProperty(CapProp.PosFrames, 0);
    }

    public bool Reset()
    {
        return _videoCapture.SetCaptureProperty(CapProp.PosFrames, 0);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _videoCapture?.Dispose();
            _disposed = true;
        }
    }   
}

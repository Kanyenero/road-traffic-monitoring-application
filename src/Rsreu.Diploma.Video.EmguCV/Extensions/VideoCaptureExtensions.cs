using Emgu.CV;
using Emgu.CV.CvEnum;
using Rsreu.Diploma.Video.Models;

namespace Rsreu.Diploma.Video.EmguCV.Extensions;

internal static class VideoCaptureExtensions
{
    public static VideoMetadata GetMetadata(this VideoCapture videoCapture)
    {
        var fourcc = (int)videoCapture.GetCaptureProperty(CapProp.FourCC);
        var codec = string.Format("{0}{1}{2}{3}", (char)(fourcc & 255), (char)((fourcc >> 8) & 255), (char)((fourcc >> 16) & 255), (char)((fourcc >> 24) & 255)).ToUpper();
        var fps = (int)Math.Round(videoCapture.GetCaptureProperty(CapProp.Fps));
        var count = (int)videoCapture.GetCaptureProperty(CapProp.FrameCount);
        var width = videoCapture.Width;
        var height = videoCapture.Height;

        return new VideoMetadata
        {
            FourCC = fourcc,
            Codec = codec,
            FrameRate = fps,
            FrameCount = count,
            Width = width,
            Height = height
        };
    }
}

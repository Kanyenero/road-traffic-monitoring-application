using Emgu.CV;
using Rsreu.Diploma.Video.Constants;
using Rsreu.Diploma.Video.Models;
using System.Drawing;

namespace Rsreu.Diploma.Video.EmguCV;

internal class FrameWriter : IDisposable
{
    private VideoWriter _videoWriter;
    private VideoMetadata _metadata;
    private string _outputDirectory;
    private string _outputFile;
    private bool _disposed;

    public bool IsOpened 
    {
        get => _videoWriter is not null && _videoWriter.IsOpened;
    }

    public bool IsDisposed 
    {
        get => _disposed;
    }

    public FrameWriter()
    {
    }

    public FrameWriter(FrameWriterOptions options)
    {
        SetOptions(options);
    }

    public void SetOptions(FrameWriterOptions options)
    {
        throw new NotImplementedException();
    }

    public void SetFrameSize(Size value)
    {
        _videoWriter?.Dispose();
        _videoWriter = CreateWriter(value, isColor: true);
    }

    public void SetOutputDirectory(string value)
    {
        _outputDirectory = value;
        _outputFile = BuildOutputFilePath(_outputDirectory, _metadata.FileName);

        _videoWriter?.Dispose();
        _videoWriter = CreateWriter(isColor: true);
    }

    public void Initialize(VideoMetadata metadata)
    {
        _metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
        _outputDirectory = DefaultDirectories.VideoOutput;
        _outputFile = BuildOutputFilePath(_outputDirectory, _metadata.FileName);

        _videoWriter?.Dispose();
        _videoWriter = CreateWriter(isColor: true);
    }

    private static string BuildOutputFilePath(string directory, string filename)
    {
        return directory + "\\" + Path.GetFileNameWithoutExtension(filename) + " " + Guid.NewGuid() + " " + Path.GetExtension(filename);
    }

    private VideoWriter CreateWriter(bool isColor = true)
    {
        if (_outputFile is null)
        {
            throw new InvalidOperationException($"{nameof(_outputFile)} was null.");
        }
        if (_metadata is null)
        {
            throw new InvalidOperationException($"{nameof(_metadata)} was null.");
        }

        return new VideoWriter(_outputFile, _metadata.FourCC, _metadata.FrameRate, _metadata.FrameSize, isColor);
    }

    private VideoWriter CreateWriter(Size frameSize, bool isColor = true)
    {
        if (_outputFile is null)
        {
            throw new InvalidOperationException($"{nameof(_outputFile)} was null.");
        }
        if (_metadata is null)
        {
            throw new InvalidOperationException($"{nameof(_metadata)} was null.");
        }

        return new VideoWriter(_outputFile, _metadata.FourCC, _metadata.FrameRate, frameSize, isColor);
    }

    public void Write(Mat frame)
    {
        if (_disposed || !IsOpened)
        {
            _videoWriter = new VideoWriter(_outputFile, _metadata.FourCC, _metadata.FrameRate, _metadata.FrameSize, isColor: true);
            _disposed = false;
        }

        _videoWriter.Write(frame);
    }

    public void Dispose()
    {
        if (!_disposed && IsOpened)
        {
            _videoWriter.Dispose();
            _disposed = true;
        }
    }
}

using Emgu.CV;
using Rsreu.Diploma.Video.Contracts;
using Rsreu.Diploma.Video.Enumerations;
using Rsreu.Diploma.Video.Events;
using Rsreu.Diploma.Video.Models;
using System.Diagnostics;
using System.Drawing;

namespace Rsreu.Diploma.Video.EmguCV;

public class VideoProcessor : IVideoProcessor
{
    private readonly FrameProvider _frameProvider;
    private readonly FrameHandler _frameHandler;
    private readonly FrameWriter _frameWriter;
    private readonly AutoResetEvent _pauseEvent;
    private Task _task;

    public VideoProcessor(VideoProcessorConfiguration configuration)
    {
        _frameProvider = new FrameProvider(/*configuration.FrameProviderOptions*/);
        _frameHandler = new FrameHandler(configuration.FrameHandlerOptions);
        _frameWriter = new FrameWriter(/*configuration.FrameWriterOptions*/);
        _pauseEvent = new AutoResetEvent(initialState: false);
    }

    public VideoMetadata VideoSourceInfo
    {
        get => _frameProvider.Metadata;
    }

    public GrabState GrabState { get; private set; }

    public bool IsReady { get; private set; }

    public bool ProcessingEnabled { get; set; }

    public bool WritingEnabled { get; set; }

    public event EventHandler<VideoProcessorEventArgs> Ready;
    public event EventHandler<FrameEventArgs> FrameReady;
    public event EventHandler<EventArgs> FramesOver;

    internal void Initialize(string videoSource)
    {
        IsReady = false;

        try
        {
            _frameProvider.Initialize(videoSource);
            _frameHandler.Initialize(_frameProvider.Metadata);
            _frameWriter.Initialize(_frameProvider.Metadata);
        }
        catch (Exception ex)
        {
            Ready?.Invoke(this, new VideoProcessorEventArgs { Error = ex.Message });

            return;
        }

        Ready?.Invoke(this, VideoProcessorEventArgs.Empty);
        IsReady = true;
    }

    public void SetVideoSource(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(value));

        Initialize(value);
    }

    public void SetOutputDirectory(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(value));

        _frameWriter.SetOutputDirectory(value);
    }

    public void SetRoi(Rectangle roi)
    {
        _frameHandler.SetRoi(roi);
    }

    public void SetConfiguration(IVideoProcessorConfiguration configuration)
    {
        var config = (configuration as VideoProcessorConfiguration) ?? throw new InvalidCastException($"Unexpected type '{configuration.GetType()}'.");

        if (config.FrameHandlerOptions is not null)
        {
            _frameHandler.SetOptions(config.FrameHandlerOptions);
        }
    }

    private void Run()
    {
        //if (_frameHandler.ProcFrameSize.HasValue)
        //{
        //    _frameWriter.SetFrameSize(_frameHandler.ProcFrameSize.Value);
        //}

        Bitmap frame = null;
        var baseFrame = new Mat();
        var procFrame = new Mat();

        var frametime = 1000 / VideoSourceInfo.FrameRate;
        var stopwatch = Stopwatch.StartNew();

        while (GrabState == GrabState.Running || GrabState == GrabState.Pause)
        {
            if (GrabState == GrabState.Pause)
            {
                _pauseEvent.WaitOne();

                continue;
            }

            if (!_frameProvider.Read(baseFrame))
            {
                GrabState = GrabState.Stopping;

                break;
            }

            frame?.Dispose();

            var frameNumber = _frameProvider.FrameNumber;
            _frameHandler.FrameNumber = frameNumber;

            var frameProcessed = ProcessingEnabled && _frameHandler.Handle(baseFrame, out procFrame);

            if (WritingEnabled)
            {
                if (frameProcessed)
                {
                    _frameWriter.Write(procFrame);
                }
                else
                {
                    _frameWriter.Write(baseFrame);
                }
            }
            else if (!_frameWriter.IsDisposed)
            {
                _frameWriter.Dispose();
            }

            frame = frameProcessed ? procFrame.ToBitmap() : baseFrame.ToBitmap();

            var busytime = (int)stopwatch.ElapsedMilliseconds;
            var downtime = frametime - busytime;

            FrameReady?.Invoke(this, new FrameEventArgs
            {
                Frame = frame,
                FrameNumber = frameNumber,
                Busytime = busytime,
                Downtime = downtime
            });

            if (downtime > 0)
            {
                Thread.Sleep(downtime);
            }

            stopwatch.Restart();
        }

        if (!_frameWriter.IsDisposed)
        {
            _frameWriter.Dispose();
        }

        GrabState = GrabState.Stopped;
    }

    public void Start()
    {
        if (GrabState == GrabState.Pause)
        {
            GrabState = GrabState.Running;

            _pauseEvent.Set();
        }
        else if (GrabState == GrabState.Stopped || GrabState == GrabState.Stopping)
        {
            GrabState = GrabState.Running;

            _task = new Task(Run);
            _task.Start();
            _task.GetAwaiter().OnCompleted(() => FramesOver?.Invoke(this, EventArgs.Empty));
        }
    }

    public void Pause()
    {
        if (GrabState == GrabState.Running)
        {
            GrabState = GrabState.Pause;
        }
    }

    public void Stop()
    {
        if (GrabState == GrabState.Pause)
        {
            GrabState = GrabState.Stopping;

            _pauseEvent.Set();
        }
        else if (GrabState == GrabState.Running)
        {
            GrabState = GrabState.Stopping;
        }

        if (_task != null)
        {
            _task.Wait(100);
            _task = null;
        }

        _frameProvider.Reset();
        _frameHandler.Reset();
    }

    public void QueryFirstFrame()
    {
        var mat = new Mat();

        if (_frameProvider.QueryFirst(mat))
        {
            var frame = mat.ToBitmap();

            FrameReady?.Invoke(this, new FrameEventArgs
            {
                Frame = frame
            });
        }
    }
}

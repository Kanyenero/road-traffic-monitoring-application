using Rsreu.Diploma.Video.Constants;
using Rsreu.Diploma.Video.Contracts;
using Rsreu.Diploma.Video.Enumerations;
using Rsreu.Diploma.Video.Events;
using Rsreu.Diploma.Video.Models;

namespace Rsreu.Diploma.Controls;

public partial class VideoPlayer : UserControl
{
    private IVideoProcessor _videoProcessor;
    private Rectangle _roi;

    public VideoPlayer()
    {
        InitializeComponent();
        //WireAllControls(this);
    }

    public VideoMetadata VideoSourceInfo
    {
        get => _videoProcessor.VideoSourceInfo;
    }

    public bool IsReady
    {
        get => _videoProcessor is not null && _videoProcessor.IsReady;
    }

    public event EventHandler Ready;

    private void WireAllControls(Control parentControl)
    {
        foreach (Control childControl in parentControl.Controls)
        {
            childControl.Click += new EventHandler(delegate (object sender, EventArgs e)
            {
                InvokeOnClick(this, EventArgs.Empty);
            });

            if (childControl.HasChildren)
            {
                WireAllControls(childControl);
            }
        }
    }

    public void SetVideoProcessor(IVideoProcessor videoProcessor)
    {
        if (videoProcessor != null)
        {
            _videoProcessor = videoProcessor;
            _videoProcessor.Ready += onReady;
            _videoProcessor.FrameReady += onFrameReady;
            _videoProcessor.FramesOver += onFramesOver;
        }

        SetInitialDefaults();

        void onReady(object sender, VideoProcessorEventArgs e)
        {
            if (e.HasError)
            {
                SetInitialDefaults();
            }
            else
            {
                SetReadyDefaults();

                _videoProcessor.QueryFirstFrame();
                Ready?.Invoke(this, EventArgs.Empty);
            }
        }
        void onFrameReady(object sender, FrameEventArgs e)
        {
            lock (e.Frame)
            {
                pictureBox.Image = (Bitmap)e.Frame?.Clone();
            }

            lblFrameCount.Text = e.FrameNumber + "/" + VideoSourceInfo.FrameCount;
            lblBusytime.Text = string.Format("{0}/{1}", e.Busytime.ToString("00"), e.Downtime.ToString("00"));
        }
        void onFramesOver(object sender, EventArgs e) => OnStop();
    }

    public void SetVideoProcessorConfiguration(IVideoProcessorConfiguration configuration)
    {
        if (_videoProcessor is not null && _videoProcessor.IsReady)
        {
            _videoProcessor.SetConfiguration(configuration);
        }
    }

    private void OnPictureBoxClick(object sender, EventArgs e)
    {
        mstrContext.Visible = false;
        pnlFrame.BringToFront();
    }

    private void OnBtnPlayPauseClick(object sender, EventArgs e)
    {
        if (_videoProcessor.GrabState == GrabState.Pause || _videoProcessor.GrabState == GrabState.Stopped)
        {
            _videoProcessor.Start();

            onPlay();
        }
        else if (_videoProcessor.GrabState == GrabState.Running)
        {
            _videoProcessor.Pause();

            onPause();
        }

        btnStop.Enabled = true;

        void onPlay()
        {
            btnPlayPause.Image = Properties.Resources.Pause;
            btnOpen.Enabled = false;
            btnSave.Enabled = false;
            btnRegionSelection.Enabled = false;
        }

        void onPause()
        {
            btnPlayPause.Image = Properties.Resources.Play;
            btnOpen.Enabled = true;
            btnSave.Enabled = true;
            btnRegionSelection.Enabled = true;
        }
    }

    private void OnBtnStopClick(object sender, EventArgs e)
    {
        OnStop();
    }

    private void OnBtnOpenClick(object sender, EventArgs e)
    {
        var directory = DefaultDirectories.VideoSource;

        using var openVideoDialog = new OpenFileDialog();

        openVideoDialog.Filter = "MP4 (*.mp4)|*.mp4|AVI (*.avi)|*.avi";
        openVideoDialog.InitialDirectory = directory;
        openVideoDialog.Title = "Открыть видео";

        if (openVideoDialog.ShowDialog() == DialogResult.OK)
        {
            _videoProcessor.SetVideoSource(openVideoDialog.FileName);
        }
    }

    private void OnBtnSaveClick(object sender, EventArgs e)
    {
        var directory = DefaultDirectories.ImageOutput;

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        using var saveFrameDialog = new SaveFileDialog();

        saveFrameDialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|Bitmap (*.bmp)|*.bmp";
        saveFrameDialog.InitialDirectory = directory;
        saveFrameDialog.Title = "Сохранить изображение";

        if (saveFrameDialog.ShowDialog() == DialogResult.OK)
        {
            pictureBox.Image?.Save(saveFrameDialog.FileName);
        }
    }

    private void OnBtnRegionSelectionClick(object sender, EventArgs e)
    {
        if (pictureBox.RegionSelectionEnabled)
        {
            pictureBox.RegionSelectionEnabled = false;

            OnRegionSelectionDisabled();
        }
        else
        {
            pictureBox.RegionSelectionEnabled = true;

            OnRegionSelectionEnabled();
        }
    }

    private void OnRegionSelected(object sender, RegionSelectionEventArgs e)
    {
        mstrContext.Location = new(e.BottomRight.X - mstrContext.Width, e.BottomRight.Y - mstrContext.Height);
        mstrContext.Visible = true;
        mstrContext.BringToFront();

        _roi = e.Region;
    }

    private void OnBtnDrawClick(object sender, EventArgs e)
    {

    }

    private void OnApplyClick(object sender, EventArgs e)
    {
        mstrContext.Visible = false;
        pnlFrame.BringToFront();
        pictureBox.Invalidate();
        OnRegionSelectionDisabled();

        _videoProcessor.SetRoi(_roi);
    }

    private void OnBtnProcessingClick(object sender, EventArgs e)
    {
        if (_videoProcessor.ProcessingEnabled)
        {
            _videoProcessor.ProcessingEnabled = false;

            OnProcessingDisabled();
        }
        else
        {
            _videoProcessor.ProcessingEnabled = true;

            OnProcessingEnabled();
        }
    }

    private void OnBtnRecordClick(object sender, EventArgs e)
    {
        if (_videoProcessor.WritingEnabled)
        {
            _videoProcessor.WritingEnabled = false;

            OnWritingDisabled();
        }
        else
        {
            var directory = DefaultDirectories.VideoOutput;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            _videoProcessor.SetOutputDirectory(directory);
            _videoProcessor.WritingEnabled = true;

            OnWritingEnabled();
        }
    }

    private void SetInitialDefaults()
    {
        btnPlayPause.Enabled = false;
        btnStop.Enabled = false;
        btnOpen.Enabled = true;
        btnSave.Enabled = false;
        btnDraw.Enabled = false;
        btnRegionSelection.Enabled = false;
        btnProcessing.Enabled = false;
        btnRecord.Enabled = false;

        lblFrameCount.Text = "0/0";
        lblBusytime.Text = "00/00";

        btnPlayPause.Image = Properties.Resources.Play;
    }

    private void SetReadyDefaults()
    {
        btnPlayPause.Enabled = true;
        btnStop.Enabled = false;
        btnOpen.Enabled = true;
        btnSave.Enabled = true;
        btnDraw.Enabled = true;
        btnRegionSelection.Enabled = true;
        btnProcessing.Enabled = true;
        btnRecord.Enabled = true;

        lblFrameCount.Text = "0/" + (VideoSourceInfo?.FrameCount ?? 0);
        lblBusytime.Text = "00/00";

        btnPlayPause.Image = Properties.Resources.Play;
    }

    private void OnStop()
    {
        if (_videoProcessor.ProcessingEnabled)
        {
            _videoProcessor.ProcessingEnabled = false;

            OnProcessingDisabled();
        }
        if (_videoProcessor.WritingEnabled)
        {
            _videoProcessor.WritingEnabled = false;

            OnWritingDisabled();
        }

        _videoProcessor.Stop();
        _videoProcessor.QueryFirstFrame();

        SetReadyDefaults();
    }

    private void OnProcessingDisabled()
    {
        btnProcessing.Image = Properties.Resources.ProcessImage;
        btnProcessing.ToolTipText = "Включить обработку кадров";
    }

    private void OnProcessingEnabled()
    {
        btnProcessing.Image = Properties.Resources.ProcessImageInProgress;
        btnProcessing.ToolTipText = "Выключить обработку кадров";
    }

    private void OnWritingDisabled()
    {
        btnRecord.Image = Properties.Resources.Record;
        btnRecord.ToolTipText = "Включить запись";
        btnProcessing.Enabled = true;
    }

    private void OnWritingEnabled()
    {
        btnRecord.Image = Properties.Resources.RecordInProgress;
        btnRecord.ToolTipText = "Выключить запись";
        btnProcessing.Enabled = false;
    }

    private void OnRegionSelectionDisabled()
    {
        btnRegionSelection.Image = Properties.Resources.RegionSelection;
        btnRegionSelection.ToolTipText = "Включить режим выделения региона";
    }

    private void OnRegionSelectionEnabled()
    {
        btnRegionSelection.Image = Properties.Resources.RegionSelectionInProgress;
        btnRegionSelection.ToolTipText = "Выключить режим выделения региона";
    }
}

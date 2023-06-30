using Emgu.CV.Dnn;
using Microsoft.Extensions.Configuration;
using Rsreu.Diploma.Video.EmguCV;
using Rsreu.Diploma.VideoProcessing.EmguCV;
using Rsreu.Diploma.VideoProcessing.EmguCV.Yolo;

namespace Rsreu.Diploma;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        InitializeChildComponents();
        SubscribeEvents();
    }

    private void InitializeChildComponents()
    {
        cboxOutputFrameResolutions.SelectedIndex = 0;
        cboxBackendName.SelectedIndex = 1;
        cboxYoloVersion.SelectedIndex = 0;

        InitializeVideoPlayer();
    }

    private void InitializeVideoPlayer()
    {
        var configuration = Program.Configuration.GetSection("VideoProcessorConfiguration").Get<VideoProcessorConfiguration>();

        //videoPlayer.SetPictureBox(new ImageBox());
        videoPlayer.SetVideoProcessor(new VideoProcessor(configuration));
        videoPlayer.Ready += new EventHandler(delegate (object sender, EventArgs e)
        {
            lblVideoFrameRate.Text = videoPlayer.VideoSourceInfo.FrameRate.ToString();
            lblVideoResolution.Text = videoPlayer.VideoSourceInfo.Width + "x" + videoPlayer.VideoSourceInfo.Height;
            lblVideoCodec.Text = videoPlayer.VideoSourceInfo.Codec;
        });
        videoPlayer.Click += new EventHandler(delegate (object sender, EventArgs e)
        {
            ActiveControl = videoPlayer;
        });
    }

    private void SubscribeEvents()
    {
        btnApplyVideoPlayerConfiguration.Click += new EventHandler(delegate (object sender, EventArgs e)
        {
            if (!videoPlayer.IsReady)
            {
                return;
            }
            videoPlayer.SetVideoProcessorConfiguration(new VideoProcessorConfiguration
            {
                FrameHandlerOptions = new FrameHandlerOptions
                {
                    MultiObjectTrackerOptions = new MultiObjectTrackerOptions
                    {
                        YoloDetectorOptions = new YoloDetectorOptions
                        {
                            NmsThreshold = float.Parse(nudNmsThreshold.Text),
                            ScoreThreshold = float.Parse(nudScoreThreshold.Text),
                            Backend = Enum.Parse<Backend>(cboxBackendName.SelectedItem.ToString()),
                            Version = Enum.Parse<YoloVersion>(cboxYoloVersion.SelectedItem.ToString()),
                            FrameSize = getProcFrameSize()
                        }
                    }
                }
            });

            Size getProcFrameSize()
            {
                var sizes = cboxOutputFrameResolutions.SelectedItem.ToString().Split('x');
                return new Size(int.Parse(sizes[0]), int.Parse(sizes[1]));
            }
        });
    }
}

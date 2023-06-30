namespace Rsreu.Diploma
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip = new StatusStrip();
            pnlFooter = new Panel();
            cboxYoloVersion = new ComboBox();
            lblYoloVersionHeader = new Label();
            cboxBackendName = new ComboBox();
            lblBackendNameHeader = new Label();
            lblOutputFrameResolution = new Label();
            nudScoreThreshold = new NumericUpDown();
            lblScoreThresholdHeader = new Label();
            nudNmsThreshold = new NumericUpDown();
            lblNmsThresholdHeader = new Label();
            lblVideoPlayerConfigurationHeader = new Label();
            btnApplyVideoPlayerConfiguration = new Button();
            cboxOutputFrameResolutions = new ComboBox();
            tlpnlVideoPlayerSourceInfo = new TableLayoutPanel();
            lblVideoCodec = new Label();
            lblVideoCodecHeader = new Label();
            lblVideoResolution = new Label();
            lblVideoFrameRate = new Label();
            lblVideoResolutionHeader = new Label();
            lblVideoFrameRateHeader = new Label();
            lblVideoPlayerSourceInfoHeader = new Label();
            pnlBody = new Panel();
            videoPlayer = new Controls.VideoPlayer();
            pnlLeftMenu = new Panel();
            tlpnlLeftMenuLayout = new TableLayoutPanel();
            tlpnlVideoPlayerConfiguration = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)nudScoreThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNmsThreshold).BeginInit();
            tlpnlVideoPlayerSourceInfo.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlLeftMenu.SuspendLayout();
            tlpnlLeftMenuLayout.SuspendLayout();
            tlpnlVideoPlayerConfiguration.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Location = new Point(0, 890);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1258, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // pnlFooter
            // 
            pnlFooter.AutoSize = true;
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 890);
            pnlFooter.Margin = new Padding(2);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1258, 0);
            pnlFooter.TabIndex = 1;
            // 
            // cboxYoloVersion
            // 
            cboxYoloVersion.Dock = DockStyle.Fill;
            cboxYoloVersion.FormattingEnabled = true;
            cboxYoloVersion.Items.AddRange(new object[] { "V3", "V3Tiny", "V4", "V4Tiny" });
            cboxYoloVersion.Location = new Point(141, 192);
            cboxYoloVersion.Name = "cboxYoloVersion";
            cboxYoloVersion.Size = new Size(156, 33);
            cboxYoloVersion.TabIndex = 11;
            cboxYoloVersion.TabStop = false;
            // 
            // lblYoloVersionHeader
            // 
            lblYoloVersionHeader.AutoSize = true;
            lblYoloVersionHeader.Dock = DockStyle.Fill;
            lblYoloVersionHeader.Location = new Point(3, 189);
            lblYoloVersionHeader.Name = "lblYoloVersionHeader";
            lblYoloVersionHeader.Size = new Size(132, 39);
            lblYoloVersionHeader.TabIndex = 10;
            lblYoloVersionHeader.Text = "Версия YOLO";
            lblYoloVersionHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboxBackendName
            // 
            cboxBackendName.Dock = DockStyle.Fill;
            cboxBackendName.FormattingEnabled = true;
            cboxBackendName.Items.AddRange(new object[] { "Default", "Cuda" });
            cboxBackendName.Location = new Point(141, 153);
            cboxBackendName.Name = "cboxBackendName";
            cboxBackendName.Size = new Size(156, 33);
            cboxBackendName.TabIndex = 9;
            cboxBackendName.TabStop = false;
            // 
            // lblBackendNameHeader
            // 
            lblBackendNameHeader.AutoSize = true;
            lblBackendNameHeader.Dock = DockStyle.Fill;
            lblBackendNameHeader.Location = new Point(3, 150);
            lblBackendNameHeader.Name = "lblBackendNameHeader";
            lblBackendNameHeader.Size = new Size(132, 39);
            lblBackendNameHeader.TabIndex = 8;
            lblBackendNameHeader.Text = "Устройство";
            lblBackendNameHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOutputFrameResolution
            // 
            lblOutputFrameResolution.AutoSize = true;
            lblOutputFrameResolution.Dock = DockStyle.Fill;
            lblOutputFrameResolution.Location = new Point(3, 111);
            lblOutputFrameResolution.Name = "lblOutputFrameResolution";
            lblOutputFrameResolution.Size = new Size(132, 39);
            lblOutputFrameResolution.TabIndex = 6;
            lblOutputFrameResolution.Text = "Размер кадра";
            lblOutputFrameResolution.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudScoreThreshold
            // 
            nudScoreThreshold.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudScoreThreshold.DecimalPlaces = 1;
            nudScoreThreshold.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudScoreThreshold.Location = new Point(141, 76);
            nudScoreThreshold.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nudScoreThreshold.Name = "nudScoreThreshold";
            nudScoreThreshold.Size = new Size(156, 31);
            nudScoreThreshold.TabIndex = 5;
            nudScoreThreshold.TabStop = false;
            nudScoreThreshold.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // lblScoreThresholdHeader
            // 
            lblScoreThresholdHeader.AutoSize = true;
            lblScoreThresholdHeader.Dock = DockStyle.Fill;
            lblScoreThresholdHeader.Location = new Point(3, 72);
            lblScoreThresholdHeader.Name = "lblScoreThresholdHeader";
            lblScoreThresholdHeader.Size = new Size(132, 39);
            lblScoreThresholdHeader.TabIndex = 4;
            lblScoreThresholdHeader.Text = "Коэф. доверия";
            lblScoreThresholdHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudNmsThreshold
            // 
            nudNmsThreshold.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudNmsThreshold.DecimalPlaces = 1;
            nudNmsThreshold.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudNmsThreshold.Location = new Point(141, 37);
            nudNmsThreshold.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNmsThreshold.Name = "nudNmsThreshold";
            nudNmsThreshold.Size = new Size(156, 31);
            nudNmsThreshold.TabIndex = 3;
            nudNmsThreshold.TabStop = false;
            nudNmsThreshold.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // lblNmsThresholdHeader
            // 
            lblNmsThresholdHeader.AutoSize = true;
            lblNmsThresholdHeader.Dock = DockStyle.Fill;
            lblNmsThresholdHeader.Location = new Point(3, 33);
            lblNmsThresholdHeader.Name = "lblNmsThresholdHeader";
            lblNmsThresholdHeader.Size = new Size(132, 39);
            lblNmsThresholdHeader.TabIndex = 3;
            lblNmsThresholdHeader.Text = "Порог NMS";
            lblNmsThresholdHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVideoPlayerConfigurationHeader
            // 
            lblVideoPlayerConfigurationHeader.AutoSize = true;
            lblVideoPlayerConfigurationHeader.BackColor = SystemColors.ControlLightLight;
            tlpnlVideoPlayerConfiguration.SetColumnSpan(lblVideoPlayerConfigurationHeader, 2);
            lblVideoPlayerConfigurationHeader.Dock = DockStyle.Fill;
            lblVideoPlayerConfigurationHeader.Location = new Point(0, 0);
            lblVideoPlayerConfigurationHeader.Margin = new Padding(0);
            lblVideoPlayerConfigurationHeader.Name = "lblVideoPlayerConfigurationHeader";
            lblVideoPlayerConfigurationHeader.Size = new Size(300, 33);
            lblVideoPlayerConfigurationHeader.TabIndex = 1;
            lblVideoPlayerConfigurationHeader.Text = "Управление обработкой видео";
            lblVideoPlayerConfigurationHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnApplyVideoPlayerConfiguration
            // 
            btnApplyVideoPlayerConfiguration.AutoSize = true;
            btnApplyVideoPlayerConfiguration.BackColor = SystemColors.Control;
            tlpnlVideoPlayerConfiguration.SetColumnSpan(btnApplyVideoPlayerConfiguration, 2);
            btnApplyVideoPlayerConfiguration.Dock = DockStyle.Fill;
            btnApplyVideoPlayerConfiguration.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            btnApplyVideoPlayerConfiguration.Location = new Point(1, 229);
            btnApplyVideoPlayerConfiguration.Margin = new Padding(1, 1, 1, 0);
            btnApplyVideoPlayerConfiguration.Name = "btnApplyVideoPlayerConfiguration";
            btnApplyVideoPlayerConfiguration.Size = new Size(298, 35);
            btnApplyVideoPlayerConfiguration.TabIndex = 2;
            btnApplyVideoPlayerConfiguration.TabStop = false;
            btnApplyVideoPlayerConfiguration.Text = "Применить настройки";
            btnApplyVideoPlayerConfiguration.TextAlign = ContentAlignment.TopCenter;
            btnApplyVideoPlayerConfiguration.UseVisualStyleBackColor = false;
            // 
            // cboxOutputFrameResolutions
            // 
            cboxOutputFrameResolutions.Dock = DockStyle.Fill;
            cboxOutputFrameResolutions.FormattingEnabled = true;
            cboxOutputFrameResolutions.Items.AddRange(new object[] { "320x320", "480x480", "640x640", "800x800", "960x960", "1280x1280", "1920x1920" });
            cboxOutputFrameResolutions.Location = new Point(141, 114);
            cboxOutputFrameResolutions.Name = "cboxOutputFrameResolutions";
            cboxOutputFrameResolutions.Size = new Size(156, 33);
            cboxOutputFrameResolutions.TabIndex = 7;
            cboxOutputFrameResolutions.TabStop = false;
            // 
            // tlpnlVideoPlayerSourceInfo
            // 
            tlpnlVideoPlayerSourceInfo.AutoSize = true;
            tlpnlVideoPlayerSourceInfo.ColumnCount = 2;
            tlpnlVideoPlayerSourceInfo.ColumnStyles.Add(new ColumnStyle());
            tlpnlVideoPlayerSourceInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpnlVideoPlayerSourceInfo.Controls.Add(lblVideoCodec, 1, 3);
            tlpnlVideoPlayerSourceInfo.Controls.Add(lblVideoCodecHeader, 0, 3);
            tlpnlVideoPlayerSourceInfo.Controls.Add(lblVideoResolution, 1, 2);
            tlpnlVideoPlayerSourceInfo.Controls.Add(lblVideoFrameRate, 1, 1);
            tlpnlVideoPlayerSourceInfo.Controls.Add(lblVideoResolutionHeader, 0, 2);
            tlpnlVideoPlayerSourceInfo.Controls.Add(lblVideoFrameRateHeader, 0, 1);
            tlpnlVideoPlayerSourceInfo.Controls.Add(lblVideoPlayerSourceInfoHeader, 0, 0);
            tlpnlVideoPlayerSourceInfo.Dock = DockStyle.Fill;
            tlpnlVideoPlayerSourceInfo.Location = new Point(0, 0);
            tlpnlVideoPlayerSourceInfo.Margin = new Padding(0);
            tlpnlVideoPlayerSourceInfo.Name = "tlpnlVideoPlayerSourceInfo";
            tlpnlVideoPlayerSourceInfo.RowCount = 4;
            tlpnlVideoPlayerSourceInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tlpnlVideoPlayerSourceInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tlpnlVideoPlayerSourceInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tlpnlVideoPlayerSourceInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tlpnlVideoPlayerSourceInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpnlVideoPlayerSourceInfo.Size = new Size(300, 150);
            tlpnlVideoPlayerSourceInfo.TabIndex = 2;
            // 
            // lblVideoCodec
            // 
            lblVideoCodec.AutoSize = true;
            lblVideoCodec.Dock = DockStyle.Fill;
            lblVideoCodec.Location = new Point(134, 111);
            lblVideoCodec.Name = "lblVideoCodec";
            lblVideoCodec.Size = new Size(163, 39);
            lblVideoCodec.TabIndex = 8;
            lblVideoCodec.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVideoCodecHeader
            // 
            lblVideoCodecHeader.AutoSize = true;
            lblVideoCodecHeader.Dock = DockStyle.Fill;
            lblVideoCodecHeader.Location = new Point(3, 111);
            lblVideoCodecHeader.Name = "lblVideoCodecHeader";
            lblVideoCodecHeader.Size = new Size(125, 39);
            lblVideoCodecHeader.TabIndex = 7;
            lblVideoCodecHeader.Text = "Кодек";
            lblVideoCodecHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVideoResolution
            // 
            lblVideoResolution.AutoSize = true;
            lblVideoResolution.Dock = DockStyle.Fill;
            lblVideoResolution.Location = new Point(134, 72);
            lblVideoResolution.Name = "lblVideoResolution";
            lblVideoResolution.Size = new Size(163, 39);
            lblVideoResolution.TabIndex = 6;
            lblVideoResolution.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVideoFrameRate
            // 
            lblVideoFrameRate.AutoSize = true;
            lblVideoFrameRate.Dock = DockStyle.Fill;
            lblVideoFrameRate.Location = new Point(134, 33);
            lblVideoFrameRate.Name = "lblVideoFrameRate";
            lblVideoFrameRate.Size = new Size(163, 39);
            lblVideoFrameRate.TabIndex = 5;
            lblVideoFrameRate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVideoResolutionHeader
            // 
            lblVideoResolutionHeader.AutoSize = true;
            lblVideoResolutionHeader.Dock = DockStyle.Fill;
            lblVideoResolutionHeader.Location = new Point(3, 72);
            lblVideoResolutionHeader.Name = "lblVideoResolutionHeader";
            lblVideoResolutionHeader.Size = new Size(125, 39);
            lblVideoResolutionHeader.TabIndex = 3;
            lblVideoResolutionHeader.Text = "Размер кадра";
            lblVideoResolutionHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVideoFrameRateHeader
            // 
            lblVideoFrameRateHeader.AutoSize = true;
            lblVideoFrameRateHeader.Dock = DockStyle.Fill;
            lblVideoFrameRateHeader.Location = new Point(3, 33);
            lblVideoFrameRateHeader.Name = "lblVideoFrameRateHeader";
            lblVideoFrameRateHeader.Size = new Size(125, 39);
            lblVideoFrameRateHeader.TabIndex = 2;
            lblVideoFrameRateHeader.Text = "FPS";
            lblVideoFrameRateHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVideoPlayerSourceInfoHeader
            // 
            lblVideoPlayerSourceInfoHeader.AutoSize = true;
            lblVideoPlayerSourceInfoHeader.BackColor = SystemColors.ControlLightLight;
            tlpnlVideoPlayerSourceInfo.SetColumnSpan(lblVideoPlayerSourceInfoHeader, 2);
            lblVideoPlayerSourceInfoHeader.Dock = DockStyle.Fill;
            lblVideoPlayerSourceInfoHeader.Location = new Point(0, 0);
            lblVideoPlayerSourceInfoHeader.Margin = new Padding(0);
            lblVideoPlayerSourceInfoHeader.Name = "lblVideoPlayerSourceInfoHeader";
            lblVideoPlayerSourceInfoHeader.Size = new Size(300, 33);
            lblVideoPlayerSourceInfoHeader.TabIndex = 0;
            lblVideoPlayerSourceInfoHeader.Text = "Информация о видео";
            lblVideoPlayerSourceInfoHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(videoPlayer);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(300, 0);
            pnlBody.Margin = new Padding(2);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(958, 890);
            pnlBody.TabIndex = 2;
            // 
            // videoPlayer
            // 
            videoPlayer.Dock = DockStyle.Fill;
            videoPlayer.Location = new Point(0, 0);
            videoPlayer.Margin = new Padding(2);
            videoPlayer.MinimumSize = new Size(480, 480);
            videoPlayer.Name = "videoPlayer";
            videoPlayer.Size = new Size(958, 890);
            videoPlayer.TabIndex = 0;
            // 
            // pnlLeftMenu
            // 
            pnlLeftMenu.Controls.Add(tlpnlLeftMenuLayout);
            pnlLeftMenu.Dock = DockStyle.Left;
            pnlLeftMenu.Location = new Point(0, 0);
            pnlLeftMenu.Name = "pnlLeftMenu";
            pnlLeftMenu.Size = new Size(300, 890);
            pnlLeftMenu.TabIndex = 1;
            // 
            // tlpnlLeftMenuLayout
            // 
            tlpnlLeftMenuLayout.ColumnCount = 1;
            tlpnlLeftMenuLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpnlLeftMenuLayout.Controls.Add(tlpnlVideoPlayerSourceInfo, 0, 0);
            tlpnlLeftMenuLayout.Controls.Add(tlpnlVideoPlayerConfiguration, 0, 1);
            tlpnlLeftMenuLayout.Dock = DockStyle.Fill;
            tlpnlLeftMenuLayout.Location = new Point(0, 0);
            tlpnlLeftMenuLayout.Name = "tlpnlLeftMenuLayout";
            tlpnlLeftMenuLayout.RowCount = 3;
            tlpnlLeftMenuLayout.RowStyles.Add(new RowStyle());
            tlpnlLeftMenuLayout.RowStyles.Add(new RowStyle());
            tlpnlLeftMenuLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpnlLeftMenuLayout.Size = new Size(300, 890);
            tlpnlLeftMenuLayout.TabIndex = 0;
            // 
            // tlpnlVideoPlayerConfiguration
            // 
            tlpnlVideoPlayerConfiguration.AutoSize = true;
            tlpnlVideoPlayerConfiguration.ColumnCount = 2;
            tlpnlVideoPlayerConfiguration.ColumnStyles.Add(new ColumnStyle());
            tlpnlVideoPlayerConfiguration.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpnlVideoPlayerConfiguration.Controls.Add(cboxYoloVersion, 1, 5);
            tlpnlVideoPlayerConfiguration.Controls.Add(cboxBackendName, 1, 4);
            tlpnlVideoPlayerConfiguration.Controls.Add(cboxOutputFrameResolutions, 1, 3);
            tlpnlVideoPlayerConfiguration.Controls.Add(nudScoreThreshold, 1, 2);
            tlpnlVideoPlayerConfiguration.Controls.Add(nudNmsThreshold, 1, 1);
            tlpnlVideoPlayerConfiguration.Controls.Add(btnApplyVideoPlayerConfiguration, 0, 6);
            tlpnlVideoPlayerConfiguration.Controls.Add(lblVideoPlayerConfigurationHeader, 0, 0);
            tlpnlVideoPlayerConfiguration.Controls.Add(lblYoloVersionHeader, 0, 5);
            tlpnlVideoPlayerConfiguration.Controls.Add(lblNmsThresholdHeader, 0, 1);
            tlpnlVideoPlayerConfiguration.Controls.Add(lblScoreThresholdHeader, 0, 2);
            tlpnlVideoPlayerConfiguration.Controls.Add(lblBackendNameHeader, 0, 4);
            tlpnlVideoPlayerConfiguration.Controls.Add(lblOutputFrameResolution, 0, 3);
            tlpnlVideoPlayerConfiguration.Dock = DockStyle.Fill;
            tlpnlVideoPlayerConfiguration.Location = new Point(0, 150);
            tlpnlVideoPlayerConfiguration.Margin = new Padding(0);
            tlpnlVideoPlayerConfiguration.Name = "tlpnlVideoPlayerConfiguration";
            tlpnlVideoPlayerConfiguration.RowCount = 7;
            tlpnlVideoPlayerConfiguration.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tlpnlVideoPlayerConfiguration.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpnlVideoPlayerConfiguration.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpnlVideoPlayerConfiguration.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpnlVideoPlayerConfiguration.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpnlVideoPlayerConfiguration.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpnlVideoPlayerConfiguration.RowStyles.Add(new RowStyle());
            tlpnlVideoPlayerConfiguration.Size = new Size(300, 264);
            tlpnlVideoPlayerConfiguration.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 912);
            Controls.Add(pnlBody);
            Controls.Add(pnlLeftMenu);
            Controls.Add(pnlFooter);
            Controls.Add(statusStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MinimumSize = new Size(900, 697);
            Name = "MainForm";
            Text = "Стенд для дипломного проекта";
            ((System.ComponentModel.ISupportInitialize)nudScoreThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNmsThreshold).EndInit();
            tlpnlVideoPlayerSourceInfo.ResumeLayout(false);
            tlpnlVideoPlayerSourceInfo.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlLeftMenu.ResumeLayout(false);
            tlpnlLeftMenuLayout.ResumeLayout(false);
            tlpnlLeftMenuLayout.PerformLayout();
            tlpnlVideoPlayerConfiguration.ResumeLayout(false);
            tlpnlVideoPlayerConfiguration.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private Panel pnlFooter;
        private Panel pnlBody;
        private Controls.VideoPlayer videoPlayer;
        private Label lblVideoPlayerSourceInfoHeader;
        private Label lblVideoPlayerConfigurationHeader;
        private TableLayoutPanel tlpnlVideoPlayerSourceInfo;
        private Label lblVideoFrameRateHeader;
        private Label lblVideoHeight;
        private Label lblVideoResolutionHeader;
        private Label lblVideoResolution;
        private Label lblVideoFrameRate;
        private Label lblVideoCodec;
        private Label lblVideoCodecHeader;
        private Button btnApplyVideoPlayerConfiguration;
        private Label lblScoreThresholdHeader;
        private Label lblNmsThresholdHeader;
        private NumericUpDown nudNmsThreshold;
        private NumericUpDown nudScoreThreshold;
        private Label lblOutputFrameResolution;
        private ComboBox cboxOutputFrameResolutions;
        private Label lblBackendNameHeader;
        private ComboBox cboxBackendName;
        private ComboBox cboxYoloVersion;
        private Label lblYoloVersionHeader;
        private Panel pnlLeftMenu;
        private TableLayoutPanel tlpnlLeftMenuLayout;
        private TableLayoutPanel tlpnlVideoPlayerConfiguration;
    }
}
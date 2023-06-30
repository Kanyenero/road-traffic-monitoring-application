namespace Rsreu.Diploma.Controls
{
    partial class VideoPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip = new ToolStrip();
            btnPlayPause = new ToolStripButton();
            btnStop = new ToolStripButton();
            lblFrameCount = new ToolStripLabel();
            btnRecord = new ToolStripButton();
            btnProcessing = new ToolStripButton();
            btnRegionSelection = new ToolStripButton();
            btnDraw = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnSave = new ToolStripButton();
            btnOpen = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            lblBusytime = new ToolStripLabel();
            pnlFrame = new Panel();
            mstrContext = new MenuStrip();
            tstrmiApply = new ToolStripMenuItem();
            pictureBox = new ExtendedPictureBox();
            pnlControls = new Panel();
            toolStrip.SuspendLayout();
            pnlFrame.SuspendLayout();
            mstrContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            pnlControls.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Dock = DockStyle.Fill;
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new Size(32, 32);
            toolStrip.Items.AddRange(new ToolStripItem[] { btnPlayPause, btnStop, lblFrameCount, btnRecord, btnProcessing, btnRegionSelection, btnDraw, toolStripSeparator1, btnSave, btnOpen, toolStripSeparator2, lblBusytime });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(613, 48);
            toolStrip.TabIndex = 0;
            // 
            // btnPlayPause
            // 
            btnPlayPause.AutoSize = false;
            btnPlayPause.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPlayPause.Image = Properties.Resources.Play;
            btnPlayPause.ImageTransparentColor = Color.Magenta;
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(50, 50);
            btnPlayPause.ToolTipText = "Включить проигрывание/пауза";
            btnPlayPause.Click += OnBtnPlayPauseClick;
            // 
            // btnStop
            // 
            btnStop.AutoSize = false;
            btnStop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStop.Image = Properties.Resources.Stop;
            btnStop.ImageTransparentColor = Color.Magenta;
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(50, 50);
            btnStop.ToolTipText = "Остановить проигрывание";
            btnStop.Click += OnBtnStopClick;
            // 
            // lblFrameCount
            // 
            lblFrameCount.AutoSize = false;
            lblFrameCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblFrameCount.Name = "lblFrameCount";
            lblFrameCount.Size = new Size(100, 50);
            lblFrameCount.Text = "0/0";
            lblFrameCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRecord
            // 
            btnRecord.Alignment = ToolStripItemAlignment.Right;
            btnRecord.AutoSize = false;
            btnRecord.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRecord.Image = Properties.Resources.Record;
            btnRecord.ImageTransparentColor = Color.Magenta;
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(50, 50);
            btnRecord.ToolTipText = "Включить запись";
            btnRecord.Click += OnBtnRecordClick;
            // 
            // btnProcessing
            // 
            btnProcessing.Alignment = ToolStripItemAlignment.Right;
            btnProcessing.AutoSize = false;
            btnProcessing.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnProcessing.Image = Properties.Resources.ProcessImage;
            btnProcessing.ImageTransparentColor = Color.Magenta;
            btnProcessing.Name = "btnProcessing";
            btnProcessing.Size = new Size(50, 50);
            btnProcessing.ToolTipText = "Включить обработку кадров";
            btnProcessing.Click += OnBtnProcessingClick;
            // 
            // btnRegionSelection
            // 
            btnRegionSelection.Alignment = ToolStripItemAlignment.Right;
            btnRegionSelection.AutoSize = false;
            btnRegionSelection.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRegionSelection.Image = Properties.Resources.RegionSelection;
            btnRegionSelection.ImageTransparentColor = Color.Magenta;
            btnRegionSelection.Name = "btnRegionSelection";
            btnRegionSelection.Size = new Size(50, 50);
            btnRegionSelection.ToolTipText = "Включить режим выделения региона";
            btnRegionSelection.Click += OnBtnRegionSelectionClick;
            // 
            // btnDraw
            // 
            btnDraw.Alignment = ToolStripItemAlignment.Right;
            btnDraw.AutoSize = false;
            btnDraw.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDraw.Image = Properties.Resources.Draw;
            btnDraw.ImageTransparentColor = Color.Magenta;
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(50, 50);
            btnDraw.Click += OnBtnDrawClick;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator1.AutoSize = false;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 45);
            // 
            // btnSave
            // 
            btnSave.Alignment = ToolStripItemAlignment.Right;
            btnSave.AutoSize = false;
            btnSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSave.Image = Properties.Resources.SaveImage;
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(50, 50);
            btnSave.ToolTipText = "Сохранить кадр";
            btnSave.Click += OnBtnSaveClick;
            // 
            // btnOpen
            // 
            btnOpen.Alignment = ToolStripItemAlignment.Right;
            btnOpen.AutoSize = false;
            btnOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpen.Image = Properties.Resources.Folder;
            btnOpen.ImageTransparentColor = Color.Magenta;
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(50, 50);
            btnOpen.ToolTipText = "Открыть видео";
            btnOpen.Click += OnBtnOpenClick;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator2.AutoSize = false;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 45);
            // 
            // lblBusytime
            // 
            lblBusytime.Alignment = ToolStripItemAlignment.Right;
            lblBusytime.AutoSize = false;
            lblBusytime.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblBusytime.Name = "lblBusytime";
            lblBusytime.Size = new Size(100, 50);
            lblBusytime.Text = "00/00";
            lblBusytime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlFrame
            // 
            pnlFrame.Controls.Add(mstrContext);
            pnlFrame.Controls.Add(pictureBox);
            pnlFrame.Dock = DockStyle.Fill;
            pnlFrame.Location = new Point(0, 0);
            pnlFrame.Margin = new Padding(0);
            pnlFrame.Name = "pnlFrame";
            pnlFrame.Size = new Size(613, 240);
            pnlFrame.TabIndex = 2;
            // 
            // mstrContext
            // 
            mstrContext.AutoSize = false;
            mstrContext.Dock = DockStyle.None;
            mstrContext.ImageScalingSize = new Size(24, 24);
            mstrContext.Items.AddRange(new ToolStripItem[] { tstrmiApply });
            mstrContext.Location = new Point(376, 214);
            mstrContext.Name = "mstrContext";
            mstrContext.Padding = new Padding(0);
            mstrContext.Size = new Size(96, 26);
            mstrContext.TabIndex = 4;
            mstrContext.Text = "menuStrip1";
            mstrContext.Visible = false;
            // 
            // tstrmiApply
            // 
            tstrmiApply.Name = "tstrmiApply";
            tstrmiApply.Size = new Size(103, 26);
            tstrmiApply.Text = "Применить";
            tstrmiApply.Click += OnApplyClick;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = SystemColors.ControlLightLight;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Margin = new Padding(0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(613, 240);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.RegionSelected += OnRegionSelected;
            pictureBox.Click += OnPictureBoxClick;
            // 
            // pnlControls
            // 
            pnlControls.Controls.Add(toolStrip);
            pnlControls.Dock = DockStyle.Bottom;
            pnlControls.Location = new Point(0, 240);
            pnlControls.Margin = new Padding(0);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(613, 48);
            pnlControls.TabIndex = 3;
            // 
            // VideoPlayer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlFrame);
            Controls.Add(pnlControls);
            Margin = new Padding(2);
            MinimumSize = new Size(384, 288);
            Name = "VideoPlayer";
            Size = new Size(613, 288);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            pnlFrame.ResumeLayout(false);
            mstrContext.ResumeLayout(false);
            mstrContext.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripButton btnPlayPause;
        private ToolStripButton btnStop;
        private ToolStripLabel lblFrameCount;
        private ToolStripButton btnRecord;
        private ToolStripButton btnProcessing;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnSave;
        private ToolStripButton btnOpen;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel lblBusytime;
        private Panel pnlFrame;
        private Panel pnlControls;
        private ToolStripButton btnRegionSelection;
        private ExtendedPictureBox pictureBox;
        private MenuStrip mstrContext;
        private ToolStripMenuItem tstrmiApply;
        private ToolStripButton btnDraw;
    }
}
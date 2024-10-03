namespace V2MCFormsApp
{
    partial class V2MC
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V2MC));
            UploadPathTextBox = new TextBox();
            UploadLable = new Label();
            ResoucePackPath = new Label();
            ResourcePackPathBox = new TextBox();
            DataPackPathLable = new Label();
            DataPackPathBox = new TextBox();
            ConvertButton = new Button();
            PackNameLable = new Label();
            PackNameTextBox = new TextBox();
            ScaleLable = new Label();
            WidthLable = new Label();
            HeightLable = new Label();
            StartTimeLable = new Label();
            ScaleOverrideCheckBox = new CheckBox();
            StartSecondsTextBox = new TextBox();
            StartMinutesTextBox = new TextBox();
            StartHoursTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            label4 = new Label();
            EndHoursTextBox = new TextBox();
            EndMinutesTextBox = new TextBox();
            EndSecondsTextBox = new TextBox();
            EndAtLable = new Label();
            PreviewImage = new PictureBox();
            OutputPathLable = new Label();
            OutputPathTextBox = new TextBox();
            AutoInstallCheckBox = new CheckBox();
            openFileDialog1 = new OpenFileDialog();
            BrowseButton = new Button();
            VideoSlider = new TrackBar();
            OutputBrowse = new Button();
            DataPackBrowse = new Button();
            EndAudioOnLastFrameCheckBox = new CheckBox();
            StatusLabel = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            FileDurationLabelLabel = new Label();
            FileDurationLabel = new Label();
            ReloadPreviewButton = new Button();
            TPSLabel = new Label();
            TicksPerSecondUpDown = new NumericUpDown();
            toolTip1 = new ToolTip(components);
            ScreenWidthUpDown = new NumericUpDown();
            ScreenHeightUpDown = new NumericUpDown();
            ScreenScaleUpDown = new NumericUpDown();
            button1 = new Button();
            ScreenScaleLabel = new Label();
            ScreenWidthLabel = new Label();
            ScreenHeightLabel = new Label();
            ScaleUpDown = new NumericUpDown();
            WidthUpDown = new NumericUpDown();
            HeightUpDown = new NumericUpDown();
            CancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PreviewImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VideoSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TicksPerSecondUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScreenWidthUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScreenHeightUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScreenScaleUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScaleUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WidthUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HeightUpDown).BeginInit();
            SuspendLayout();
            // 
            // UploadPathTextBox
            // 
            UploadPathTextBox.AccessibleDescription = "";
            UploadPathTextBox.AllowDrop = true;
            UploadPathTextBox.Location = new Point(84, 6);
            UploadPathTextBox.Name = "UploadPathTextBox";
            UploadPathTextBox.Size = new Size(455, 23);
            UploadPathTextBox.TabIndex = 1;
            UploadPathTextBox.Tag = "";
            UploadPathTextBox.DragDrop += UploadPathTextBox_DragDrop;
            UploadPathTextBox.DragEnter += UploadPathTextBox_DragEnter;
            UploadPathTextBox.KeyPress += UploadPathTextBox_KeyPress;
            // 
            // UploadLable
            // 
            UploadLable.AutoSize = true;
            UploadLable.Location = new Point(12, 9);
            UploadLable.Name = "UploadLable";
            UploadLable.Size = new Size(66, 15);
            UploadLable.TabIndex = 2;
            UploadLable.Text = "Upload File";
            // 
            // ResoucePackPath
            // 
            ResoucePackPath.AutoSize = true;
            ResoucePackPath.Location = new Point(12, 93);
            ResoucePackPath.Name = "ResoucePackPath";
            ResoucePackPath.Size = new Size(110, 15);
            ResoucePackPath.TabIndex = 4;
            ResoucePackPath.Text = "Resource Pack Path";
            // 
            // ResourcePackPathBox
            // 
            ResourcePackPathBox.AccessibleDescription = "";
            ResourcePackPathBox.AllowDrop = true;
            ResourcePackPathBox.Enabled = false;
            ResourcePackPathBox.Location = new Point(128, 90);
            ResourcePackPathBox.Name = "ResourcePackPathBox";
            ResourcePackPathBox.Size = new Size(411, 23);
            ResourcePackPathBox.TabIndex = 6;
            ResourcePackPathBox.Tag = "";
            // 
            // DataPackPathLable
            // 
            DataPackPathLable.AutoSize = true;
            DataPackPathLable.Location = new Point(12, 122);
            DataPackPathLable.Name = "DataPackPathLable";
            DataPackPathLable.Size = new Size(86, 15);
            DataPackPathLable.TabIndex = 6;
            DataPackPathLable.Text = "Data Pack Path";
            // 
            // DataPackPathBox
            // 
            DataPackPathBox.AccessibleDescription = "";
            DataPackPathBox.AllowDrop = true;
            DataPackPathBox.Enabled = false;
            DataPackPathBox.Location = new Point(104, 119);
            DataPackPathBox.Name = "DataPackPathBox";
            DataPackPathBox.Size = new Size(435, 23);
            DataPackPathBox.TabIndex = 8;
            DataPackPathBox.Tag = "";
            // 
            // ConvertButton
            // 
            ConvertButton.Location = new Point(101, 594);
            ConvertButton.Name = "ConvertButton";
            ConvertButton.Size = new Size(75, 24);
            ConvertButton.TabIndex = 23;
            ConvertButton.Text = "Convert!";
            ConvertButton.UseVisualStyleBackColor = true;
            ConvertButton.Click += ConvertButton_Click;
            // 
            // PackNameLable
            // 
            PackNameLable.AutoSize = true;
            PackNameLable.Location = new Point(12, 156);
            PackNameLable.Name = "PackNameLable";
            PackNameLable.Size = new Size(67, 15);
            PackNameLable.TabIndex = 9;
            PackNameLable.Text = "Pack Name";
            // 
            // PackNameTextBox
            // 
            PackNameTextBox.AccessibleDescription = "";
            PackNameTextBox.AllowDrop = true;
            PackNameTextBox.Location = new Point(86, 153);
            PackNameTextBox.Name = "PackNameTextBox";
            PackNameTextBox.Size = new Size(95, 23);
            PackNameTextBox.TabIndex = 10;
            PackNameTextBox.Tag = "";
            // 
            // ScaleLable
            // 
            ScaleLable.AutoSize = true;
            ScaleLable.Location = new Point(25, 185);
            ScaleLable.Name = "ScaleLable";
            ScaleLable.Size = new Size(34, 15);
            ScaleLable.TabIndex = 11;
            ScaleLable.Text = "Scale";
            // 
            // WidthLable
            // 
            WidthLable.AutoSize = true;
            WidthLable.Location = new Point(9, 267);
            WidthLable.Name = "WidthLable";
            WidthLable.Size = new Size(75, 15);
            WidthLable.TabIndex = 13;
            WidthLable.Text = "Image Width";
            // 
            // HeightLable
            // 
            HeightLable.AutoSize = true;
            HeightLable.Location = new Point(5, 296);
            HeightLable.Name = "HeightLable";
            HeightLable.Size = new Size(79, 15);
            HeightLable.TabIndex = 15;
            HeightLable.Text = "Image Height";
            // 
            // StartTimeLable
            // 
            StartTimeLable.AutoSize = true;
            StartTimeLable.Location = new Point(-2, 419);
            StartTimeLable.Margin = new Padding(0, 3, 0, 3);
            StartTimeLable.Name = "StartTimeLable";
            StartTimeLable.Size = new Size(58, 15);
            StartTimeLable.TabIndex = 17;
            StartTimeLable.Text = "Start time";
            // 
            // ScaleOverrideCheckBox
            // 
            ScaleOverrideCheckBox.AutoSize = true;
            ScaleOverrideCheckBox.Location = new Point(27, 240);
            ScaleOverrideCheckBox.Name = "ScaleOverrideCheckBox";
            ScaleOverrideCheckBox.RightToLeft = RightToLeft.Yes;
            ScaleOverrideCheckBox.Size = new Size(124, 19);
            ScaleOverrideCheckBox.TabIndex = 12;
            ScaleOverrideCheckBox.Text = "Use Width/Height ";
            ScaleOverrideCheckBox.UseVisualStyleBackColor = true;
            ScaleOverrideCheckBox.CheckedChanged += ScaleOverrideCheckBox_CheckedChanged;
            // 
            // StartSecondsTextBox
            // 
            StartSecondsTextBox.AccessibleDescription = "";
            StartSecondsTextBox.AllowDrop = true;
            StartSecondsTextBox.Location = new Point(138, 416);
            StartSecondsTextBox.Margin = new Padding(0, 3, 0, 3);
            StartSecondsTextBox.MaxLength = 2;
            StartSecondsTextBox.Name = "StartSecondsTextBox";
            StartSecondsTextBox.Size = new Size(29, 23);
            StartSecondsTextBox.TabIndex = 17;
            StartSecondsTextBox.Tag = "";
            StartSecondsTextBox.Text = "00";
            StartSecondsTextBox.TextChanged += ParseStartTime;
            StartSecondsTextBox.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // StartMinutesTextBox
            // 
            StartMinutesTextBox.AccessibleDescription = "";
            StartMinutesTextBox.AllowDrop = true;
            StartMinutesTextBox.Location = new Point(99, 416);
            StartMinutesTextBox.Margin = new Padding(0, 3, 0, 3);
            StartMinutesTextBox.MaxLength = 2;
            StartMinutesTextBox.Name = "StartMinutesTextBox";
            StartMinutesTextBox.Size = new Size(29, 23);
            StartMinutesTextBox.TabIndex = 16;
            StartMinutesTextBox.Tag = "";
            StartMinutesTextBox.Text = "00";
            StartMinutesTextBox.TextChanged += ParseStartTime;
            StartMinutesTextBox.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // StartHoursTextBox
            // 
            StartHoursTextBox.AccessibleDescription = "";
            StartHoursTextBox.AllowDrop = true;
            StartHoursTextBox.Location = new Point(60, 416);
            StartHoursTextBox.Margin = new Padding(0, 3, 0, 3);
            StartHoursTextBox.MaxLength = 2;
            StartHoursTextBox.Name = "StartHoursTextBox";
            StartHoursTextBox.Size = new Size(29, 23);
            StartHoursTextBox.TabIndex = 15;
            StartHoursTextBox.Tag = "";
            StartHoursTextBox.Text = "00";
            StartHoursTextBox.TextChanged += ParseStartTime;
            StartHoursTextBox.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 419);
            label2.Margin = new Padding(0, 3, 0, 3);
            label2.Name = "label2";
            label2.Size = new Size(10, 15);
            label2.TabIndex = 25;
            label2.Text = ":";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 419);
            label3.Margin = new Padding(0, 3, 0, 3);
            label3.Name = "label3";
            label3.Size = new Size(10, 15);
            label3.TabIndex = 26;
            label3.Text = ":";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(128, 448);
            label1.Margin = new Padding(0, 3, 0, 3);
            label1.Name = "label1";
            label1.Size = new Size(10, 15);
            label1.TabIndex = 32;
            label1.Text = ":";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 448);
            label4.Margin = new Padding(0, 3, 0, 3);
            label4.Name = "label4";
            label4.Size = new Size(10, 15);
            label4.TabIndex = 31;
            label4.Text = ":";
            // 
            // EndHoursTextBox
            // 
            EndHoursTextBox.AccessibleDescription = "";
            EndHoursTextBox.AllowDrop = true;
            EndHoursTextBox.Location = new Point(60, 445);
            EndHoursTextBox.Margin = new Padding(0, 3, 0, 3);
            EndHoursTextBox.MaxLength = 2;
            EndHoursTextBox.Name = "EndHoursTextBox";
            EndHoursTextBox.Size = new Size(29, 23);
            EndHoursTextBox.TabIndex = 18;
            EndHoursTextBox.Tag = "";
            EndHoursTextBox.Text = "00";
            EndHoursTextBox.TextChanged += ParseEndTime;
            EndHoursTextBox.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // EndMinutesTextBox
            // 
            EndMinutesTextBox.AccessibleDescription = "";
            EndMinutesTextBox.AllowDrop = true;
            EndMinutesTextBox.Location = new Point(99, 445);
            EndMinutesTextBox.Margin = new Padding(0, 3, 0, 3);
            EndMinutesTextBox.MaxLength = 2;
            EndMinutesTextBox.Name = "EndMinutesTextBox";
            EndMinutesTextBox.Size = new Size(29, 23);
            EndMinutesTextBox.TabIndex = 19;
            EndMinutesTextBox.Tag = "";
            EndMinutesTextBox.Text = "00";
            EndMinutesTextBox.TextChanged += ParseEndTime;
            EndMinutesTextBox.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // EndSecondsTextBox
            // 
            EndSecondsTextBox.AccessibleDescription = "";
            EndSecondsTextBox.AllowDrop = true;
            EndSecondsTextBox.Location = new Point(138, 445);
            EndSecondsTextBox.Margin = new Padding(0, 3, 0, 3);
            EndSecondsTextBox.MaxLength = 2;
            EndSecondsTextBox.Name = "EndSecondsTextBox";
            EndSecondsTextBox.Size = new Size(29, 23);
            EndSecondsTextBox.TabIndex = 20;
            EndSecondsTextBox.Tag = "";
            EndSecondsTextBox.Text = "00";
            EndSecondsTextBox.TextChanged += ParseEndTime;
            EndSecondsTextBox.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // EndAtLable
            // 
            EndAtLable.AutoSize = true;
            EndAtLable.Location = new Point(-2, 448);
            EndAtLable.Margin = new Padding(0, 3, 0, 3);
            EndAtLable.Name = "EndAtLable";
            EndAtLable.Size = new Size(54, 15);
            EndAtLable.TabIndex = 27;
            EndAtLable.Text = "End time";
            // 
            // PreviewImage
            // 
            PreviewImage.BackColor = Color.Transparent;
            PreviewImage.Location = new Point(187, 156);
            PreviewImage.Name = "PreviewImage";
            PreviewImage.Size = new Size(480, 480);
            PreviewImage.TabIndex = 33;
            PreviewImage.TabStop = false;
            // 
            // OutputPathLable
            // 
            OutputPathLable.AutoSize = true;
            OutputPathLable.Location = new Point(12, 38);
            OutputPathLable.Name = "OutputPathLable";
            OutputPathLable.Size = new Size(72, 15);
            OutputPathLable.TabIndex = 35;
            OutputPathLable.Text = "Output Path";
            // 
            // OutputPathTextBox
            // 
            OutputPathTextBox.AccessibleDescription = "";
            OutputPathTextBox.AllowDrop = true;
            OutputPathTextBox.Location = new Point(90, 35);
            OutputPathTextBox.Name = "OutputPathTextBox";
            OutputPathTextBox.Size = new Size(449, 23);
            OutputPathTextBox.TabIndex = 3;
            OutputPathTextBox.Tag = "";
            // 
            // AutoInstallCheckBox
            // 
            AutoInstallCheckBox.AutoSize = true;
            AutoInstallCheckBox.Location = new Point(12, 64);
            AutoInstallCheckBox.Name = "AutoInstallCheckBox";
            AutoInstallCheckBox.RightToLeft = RightToLeft.Yes;
            AutoInstallCheckBox.Size = new Size(86, 19);
            AutoInstallCheckBox.TabIndex = 5;
            AutoInstallCheckBox.Text = "Auto Install";
            toolTip1.SetToolTip(AutoInstallCheckBox, resources.GetString("AutoInstallCheckBox.ToolTip"));
            AutoInstallCheckBox.UseVisualStyleBackColor = true;
            AutoInstallCheckBox.CheckedChanged += AutoInstallCheckBox_CheckedChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(545, 6);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(54, 23);
            BrowseButton.TabIndex = 2;
            BrowseButton.Text = "Browse";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // VideoSlider
            // 
            VideoSlider.BackColor = SystemColors.Control;
            VideoSlider.Enabled = false;
            VideoSlider.Location = new Point(8, 543);
            VideoSlider.Name = "VideoSlider";
            VideoSlider.Size = new Size(168, 45);
            VideoSlider.TabIndex = 22;
            VideoSlider.Scroll += VideoSlider_Scroll;
            // 
            // OutputBrowse
            // 
            OutputBrowse.Location = new Point(545, 38);
            OutputBrowse.Name = "OutputBrowse";
            OutputBrowse.Size = new Size(54, 23);
            OutputBrowse.TabIndex = 4;
            OutputBrowse.Text = "Browse";
            OutputBrowse.UseVisualStyleBackColor = true;
            OutputBrowse.Click += OutputBrowse_Click;
            // 
            // DataPackBrowse
            // 
            DataPackBrowse.Location = new Point(545, 119);
            DataPackBrowse.Name = "DataPackBrowse";
            DataPackBrowse.Size = new Size(54, 23);
            DataPackBrowse.TabIndex = 9;
            DataPackBrowse.Text = "Browse";
            DataPackBrowse.UseVisualStyleBackColor = true;
            DataPackBrowse.Click += DataPackBrowse_Click;
            // 
            // EndAudioOnLastFrameCheckBox
            // 
            EndAudioOnLastFrameCheckBox.AutoSize = true;
            EndAudioOnLastFrameCheckBox.Location = new Point(-2, 518);
            EndAudioOnLastFrameCheckBox.Name = "EndAudioOnLastFrameCheckBox";
            EndAudioOnLastFrameCheckBox.RightToLeft = RightToLeft.Yes;
            EndAudioOnLastFrameCheckBox.Size = new Size(158, 19);
            EndAudioOnLastFrameCheckBox.TabIndex = 21;
            EndAudioOnLastFrameCheckBox.Text = "End Audio on Last Frame";
            toolTip1.SetToolTip(EndAudioOnLastFrameCheckBox, "Whether to end the audio when there are no more frames to show.");
            EndAudioOnLastFrameCheckBox.UseVisualStyleBackColor = true;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(12, 621);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(0, 15);
            StatusLabel.TabIndex = 43;
            // 
            // FileDurationLabelLabel
            // 
            FileDurationLabelLabel.AutoSize = true;
            FileDurationLabelLabel.Location = new Point(-2, 471);
            FileDurationLabelLabel.Name = "FileDurationLabelLabel";
            FileDurationLabelLabel.Size = new Size(76, 15);
            FileDurationLabelLabel.TabIndex = 0;
            FileDurationLabelLabel.Text = "File duration:";
            // 
            // FileDurationLabel
            // 
            FileDurationLabel.AutoSize = true;
            FileDurationLabel.Location = new Point(76, 471);
            FileDurationLabel.Name = "FileDurationLabel";
            FileDurationLabel.Size = new Size(49, 15);
            FileDurationLabel.TabIndex = 44;
            FileDurationLabel.Text = "00:00:00";
            // 
            // ReloadPreviewButton
            // 
            ReloadPreviewButton.Location = new Point(-2, 489);
            ReloadPreviewButton.Name = "ReloadPreviewButton";
            ReloadPreviewButton.Size = new Size(96, 24);
            ReloadPreviewButton.TabIndex = 45;
            ReloadPreviewButton.Text = "Reload preview";
            ReloadPreviewButton.UseVisualStyleBackColor = true;
            ReloadPreviewButton.Click += ReloadPreviewButton_Click;
            // 
            // TPSLabel
            // 
            TPSLabel.AutoSize = true;
            TPSLabel.Location = new Point(-1, 389);
            TPSLabel.Name = "TPSLabel";
            TPSLabel.Size = new Size(95, 15);
            TPSLabel.TabIndex = 46;
            TPSLabel.Text = "Ticks per Second";
            // 
            // TicksPerSecondUpDown
            // 
            TicksPerSecondUpDown.Location = new Point(100, 387);
            TicksPerSecondUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            TicksPerSecondUpDown.Name = "TicksPerSecondUpDown";
            TicksPerSecondUpDown.Size = new Size(56, 23);
            TicksPerSecondUpDown.TabIndex = 47;
            toolTip1.SetToolTip(TicksPerSecondUpDown, "This can let your frames be higher quality at the cost of having a lower framerate. You will need to change the tick rate of your game.");
            TicksPerSecondUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // ScreenWidthUpDown
            // 
            ScreenWidthUpDown.DecimalPlaces = 2;
            ScreenWidthUpDown.Enabled = false;
            ScreenWidthUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            ScreenWidthUpDown.Location = new Point(90, 323);
            ScreenWidthUpDown.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            ScreenWidthUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            ScreenWidthUpDown.Name = "ScreenWidthUpDown";
            ScreenWidthUpDown.Size = new Size(71, 23);
            ScreenWidthUpDown.TabIndex = 55;
            ScreenWidthUpDown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            ScreenWidthUpDown.ValueChanged += ScreenWidthUpDown_ValueChanged;
            ScreenWidthUpDown.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // ScreenHeightUpDown
            // 
            ScreenHeightUpDown.DecimalPlaces = 2;
            ScreenHeightUpDown.Enabled = false;
            ScreenHeightUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            ScreenHeightUpDown.Location = new Point(89, 352);
            ScreenHeightUpDown.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            ScreenHeightUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            ScreenHeightUpDown.Name = "ScreenHeightUpDown";
            ScreenHeightUpDown.Size = new Size(71, 23);
            ScreenHeightUpDown.TabIndex = 57;
            ScreenHeightUpDown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            ScreenHeightUpDown.ValueChanged += ScreenHeightUpDown_ValueChanged;
            ScreenHeightUpDown.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // ScreenScaleUpDown
            // 
            ScreenScaleUpDown.DecimalPlaces = 2;
            ScreenScaleUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            ScreenScaleUpDown.Location = new Point(86, 211);
            ScreenScaleUpDown.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            ScreenScaleUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            ScreenScaleUpDown.Name = "ScreenScaleUpDown";
            ScreenScaleUpDown.Size = new Size(95, 23);
            ScreenScaleUpDown.TabIndex = 58;
            ScreenScaleUpDown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            ScreenScaleUpDown.ValueChanged += ScreenScaleUpDown_ValueChanged;
            ScreenScaleUpDown.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(90, 489);
            button1.Name = "button1";
            button1.Size = new Size(77, 24);
            button1.TabIndex = 48;
            button1.Text = "Reset Times";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ResetTimeBoxes;
            // 
            // ScreenScaleLabel
            // 
            ScreenScaleLabel.AutoSize = true;
            ScreenScaleLabel.Location = new Point(6, 214);
            ScreenScaleLabel.Name = "ScreenScaleLabel";
            ScreenScaleLabel.Size = new Size(72, 15);
            ScreenScaleLabel.TabIndex = 49;
            ScreenScaleLabel.Text = "Screen Scale";
            // 
            // ScreenWidthLabel
            // 
            ScreenWidthLabel.AutoSize = true;
            ScreenWidthLabel.Location = new Point(7, 327);
            ScreenWidthLabel.Name = "ScreenWidthLabel";
            ScreenWidthLabel.Size = new Size(77, 15);
            ScreenWidthLabel.TabIndex = 51;
            ScreenWidthLabel.Text = "Screen Width";
            // 
            // ScreenHeightLabel
            // 
            ScreenHeightLabel.AutoSize = true;
            ScreenHeightLabel.Location = new Point(6, 356);
            ScreenHeightLabel.Name = "ScreenHeightLabel";
            ScreenHeightLabel.Size = new Size(81, 15);
            ScreenHeightLabel.TabIndex = 56;
            ScreenHeightLabel.Text = "Screen Height";
            // 
            // ScaleUpDown
            // 
            ScaleUpDown.DecimalPlaces = 2;
            ScaleUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            ScaleUpDown.Location = new Point(86, 182);
            ScaleUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            ScaleUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            ScaleUpDown.Name = "ScaleUpDown";
            ScaleUpDown.Size = new Size(95, 23);
            ScaleUpDown.TabIndex = 59;
            ScaleUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            ScaleUpDown.ValueChanged += ScaleTextBox_ValueChanged;
            ScaleUpDown.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // WidthUpDown
            // 
            WidthUpDown.Enabled = false;
            WidthUpDown.Location = new Point(89, 265);
            WidthUpDown.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            WidthUpDown.Name = "WidthUpDown";
            WidthUpDown.Size = new Size(71, 23);
            WidthUpDown.TabIndex = 60;
            WidthUpDown.ValueChanged += WidthTextBox_TextChanged;
            WidthUpDown.KeyPress += SizeAndTimeTextBox_KeyPress;
            // 
            // HeightUpDown
            // 
            HeightUpDown.Enabled = false;
            HeightUpDown.Location = new Point(90, 294);
            HeightUpDown.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            HeightUpDown.Name = "HeightUpDown";
            HeightUpDown.Size = new Size(70, 23);
            HeightUpDown.TabIndex = 61;
            HeightUpDown.ValueChanged += HeightTextBox_TextChanged;
            // 
            // CancelButton
            // 
            CancelButton.Enabled = false;
            CancelButton.Location = new Point(12, 595);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 62;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // V2MC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(678, 647);
            Controls.Add(CancelButton);
            Controls.Add(HeightUpDown);
            Controls.Add(WidthUpDown);
            Controls.Add(ScaleUpDown);
            Controls.Add(ScreenScaleUpDown);
            Controls.Add(ScreenHeightUpDown);
            Controls.Add(ScreenHeightLabel);
            Controls.Add(ScreenWidthUpDown);
            Controls.Add(ScreenWidthLabel);
            Controls.Add(ScreenScaleLabel);
            Controls.Add(button1);
            Controls.Add(TicksPerSecondUpDown);
            Controls.Add(TPSLabel);
            Controls.Add(ReloadPreviewButton);
            Controls.Add(FileDurationLabel);
            Controls.Add(FileDurationLabelLabel);
            Controls.Add(StatusLabel);
            Controls.Add(EndAudioOnLastFrameCheckBox);
            Controls.Add(DataPackBrowse);
            Controls.Add(OutputBrowse);
            Controls.Add(VideoSlider);
            Controls.Add(BrowseButton);
            Controls.Add(AutoInstallCheckBox);
            Controls.Add(OutputPathLable);
            Controls.Add(OutputPathTextBox);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(EndHoursTextBox);
            Controls.Add(EndMinutesTextBox);
            Controls.Add(EndSecondsTextBox);
            Controls.Add(EndAtLable);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(StartHoursTextBox);
            Controls.Add(StartMinutesTextBox);
            Controls.Add(StartSecondsTextBox);
            Controls.Add(ScaleOverrideCheckBox);
            Controls.Add(StartTimeLable);
            Controls.Add(HeightLable);
            Controls.Add(WidthLable);
            Controls.Add(ScaleLable);
            Controls.Add(PackNameLable);
            Controls.Add(PackNameTextBox);
            Controls.Add(ConvertButton);
            Controls.Add(DataPackPathLable);
            Controls.Add(DataPackPathBox);
            Controls.Add(ResoucePackPath);
            Controls.Add(ResourcePackPathBox);
            Controls.Add(UploadLable);
            Controls.Add(UploadPathTextBox);
            Controls.Add(PreviewImage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "V2MC";
            Text = "Video to Resource Pack";
            ((System.ComponentModel.ISupportInitialize)PreviewImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)VideoSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)TicksPerSecondUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScreenWidthUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScreenHeightUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScreenScaleUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScaleUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)WidthUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)HeightUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox UploadPathTextBox;
        private Label UploadLable;
        private Label ResoucePackPath;
        private TextBox ResourcePackPathBox;
        private Label DataPackPathLable;
        private TextBox DataPackPathBox;
        private Button ConvertButton;
        private Label PackNameLable;
        private TextBox PackNameTextBox;
        private Label ScaleLable;
        private Label WidthLable;
        private Label HeightLable;
        private Label StartTimeLable;
        private CheckBox ScaleOverrideCheckBox;
        private TextBox StartSecondsTextBox;
        private TextBox StartMinutesTextBox;
        private TextBox StartHoursTextBox;
        private Label label2;
        private Label label3;
        private Label label1;
        private Label label4;
        private TextBox EndHoursTextBox;
        private TextBox EndMinutesTextBox;
        private TextBox EndSecondsTextBox;
        private Label EndAtLable;
        private PictureBox PreviewImage;
        private Label OutputPathLable;
        private TextBox OutputPathTextBox;
        private CheckBox AutoInstallCheckBox;
        private OpenFileDialog openFileDialog1;
        private Button BrowseButton;
        private TrackBar VideoSlider;
        private Button OutputBrowse;
        private Button DataPackBrowse;
        private CheckBox EndAudioOnLastFrameCheckBox;
        private Label StatusLabel;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label FileDurationLabelLabel;
        private Label FileDurationLabel;
        private Button ReloadPreviewButton;
        private Label TPSLabel;
        private NumericUpDown TicksPerSecondUpDown;
        private ToolTip toolTip1;
        private Button button1;
        private Label ScreenScaleLabel;
        private Label ScreenWidthLabel;
        private NumericUpDown ScreenWidthUpDown;
        private NumericUpDown ScreenHeightUpDown;
        private Label ScreenHeightLabel;
        private NumericUpDown ScreenScaleUpDown;
        private NumericUpDown ScaleUpDown;
        private NumericUpDown WidthUpDown;
        private NumericUpDown HeightUpDown;
        private Button CancelButton;
    }
}

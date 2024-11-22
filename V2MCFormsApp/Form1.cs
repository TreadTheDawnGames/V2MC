using V2MCRPLib;
using V2MCRPLib.API;
using V2MCRPLib.Config;
using V2MCRPLib.Utilities;
using ImageMagick;
using FFMpegCore;
using System.Globalization;
using System.Collections.Generic;
using System.Security.Permissions;
using FFMpegCore.Enums;
using FFMpegCore.Helpers;
using Microsoft.VisualBasic;
using System.Net;
using System.IO.Compression;
using System.Drawing.Design;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;


namespace V2MCFormsApp
{
    public partial class V2MC : Form
    {
        string inputFile;
        double scale;
        int width;
        int height;
        string movieName;
        TimeSpan startTime;
        TimeSpan endTime;
        bool endAudioOnLastFrame;
        string outputPath;
        V2MCOutputType outputType = V2MCOutputType.custom;
        int originalWidth;
        int originalHeight;
        TimeSpan Duration;
        int ticksPerSecond = 20;

        float ScreenWidthScale = 1;
        float ScreenHeightScale = 1;
        float ScreenScale = 1;

        string previewDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Preview");

        FormLogger? Logger;

        bool useScale;

        API api;


        bool conversionStarted = false;

        List<TextBox> unparsableTimeBoxes = new();
        List<Control> ControlsToNotChangeEnable = new List<Control>();

        enum BrowseButtonField { Upload, Output, Resource, Data }
        BrowseButtonField browseField;

        APIConfiguration config;



        public V2MC()
        {
            InitializeComponent();

            //if ffmpeg does not exist
            //  ask user for ffmpeg path
            //      if no path
            //          ask if want to install

            ResourcePackPathBox.Text = Path.Combine(Utils.FindMinecraftPackFolder(), "resourcepacks");
            OutputPathTextBox.Text = Utils.FindDownloadsPath();
            scale = Convert.ToDouble(ScaleUpDown.Value);
            StartHoursTextBox.Text = "00";
            StartMinutesTextBox.Text = "00";
            StartSecondsTextBox.Text = "00";
            EndHoursTextBox.Text = "00";
            EndMinutesTextBox.Text = "00";
            EndSecondsTextBox.Text = "00";
            ScreenScale = (float)ScreenScaleUpDown.Value;
            ScreenWidthScale = (float)ScreenWidthUpDown.Value;
            ScreenHeightScale = (float)ScreenHeightUpDown.Value;
            Application.ApplicationExit += (sender, eventArgs) => CloseApplication(sender, eventArgs);

            if (!Directory.Exists(previewDirectory))
                Directory.CreateDirectory(previewDirectory);

            Logger = new FormLogger(ILogger.LogLevel.Debug, StatusLabel);


            //Application.EnterThreadModal += (thing, thing2) => MessageBox.Show("EnteringThreadModal");

        }



        public void UploadPathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            UploadPathTextBox.Text = data[0];
            InitializeUploadedFile();
        }

        private void UploadPathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

        private void SetupWidthHeightScaleTextBoxes(IMediaAnalysis analysis)
        {
            //scale = whatever number it is that gets the width to 48


            if (analysis == null)
            {
                throw new Exception("Error: Media analysis was null.");
            }
            originalWidth = analysis.PrimaryVideoStream.Width;
            originalHeight = analysis.PrimaryVideoStream.Height;
            scale = 48f / originalWidth;
            ScaleUpDown.Value = Convert.ToDecimal(scale);
            var widthP = (analysis.PrimaryVideoStream.Width * scale);
            var heightP = (analysis.PrimaryVideoStream.Height * scale);

            int width = (int)widthP;
            int height = (int)heightP;


            WidthUpDown.Value = Convert.ToDecimal(width);
            HeightUpDown.Value = Convert.ToDecimal(height);
        }

        private void SetupDurationTexts(IMediaAnalysis analysis)
        {
            if (analysis == null)
            {
                throw new Exception("Media analysis was null.");
            }
            var duration = analysis.PrimaryVideoStream.Duration;

            EndHoursTextBox.Text = duration.Hours.ToString("00");
            EndMinutesTextBox.Text = duration.Minutes.ToString("00");
            EndSecondsTextBox.Text = duration.Seconds.ToString("00");

            Duration = duration;
            FileDurationLabel.Text = duration.Hours.ToString("00") + ":" +
            duration.Minutes.ToString("00") + ":" +
            duration.Seconds.ToString("00");
        }

        private void CreatePreviewImage(string inputFile, TimeSpan atTime, int previewIndex)
        {
            
            if (inputFile == null || inputFile == "" || inputFile == string.Empty)
            {
                throw new Exception("No file uploaded.");
            }
            try
            {

                FFMpeg.Snapshot(inputFile, Path.Combine(previewDirectory, "PreviewSm.png"), new Size(width, height), atTime);
                var image = new MagickImage(Path.Combine(previewDirectory, "PreviewSm.png"));
                image.FilterType = FilterType.Point;

                //image.Resize(width, height);

                if (!ScaleOverrideCheckBox.Checked)
                {
                    var newScale = (120f / originalWidth) * ScreenScale /** 4*/;
                    //var newHeightScale = (120f / originalHeight) * ScreenScale /** 4*/;
                    var geo = new MagickGeometry((int)(originalWidth * newScale), (int)(originalHeight * newScale));
                    geo.IgnoreAspectRatio = true;
                    image.Resize(geo);
                }
                else
                {

                    var newWidthScale = (120f / originalWidth) * ScreenWidthScale /** 4*/;
                    var newHeightScale = (120f / originalWidth) * ScreenHeightScale /** 4*/;
                    var geo = new MagickGeometry((int)(originalWidth * newWidthScale), (int)(originalHeight * newHeightScale));
                    //geo.FillArea = true;
                    geo.IgnoreAspectRatio = true;

                    image.Resize(geo);
                }


                image.Write(Path.Combine(previewDirectory, "Preview" + previewIndex + ".png"));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //   PackPreview.ImageLocation = Path.Combine(previewDirectory, "Preview.png");
        }

        private void InitializeUploadedFile()
        {
            bool dataPackPathSet = false;
            string fileName = Path.GetFileNameWithoutExtension(UploadPathTextBox.Text);


            PackNameTextBox.Text = fileName.Replace(" ", string.Empty);

            if (Path.Exists(Path.Combine(Utils.FindMinecraftPackFolder(), "saves", PackNameTextBox.Text, "datapacks")) && !dataPackPathSet)
            {
                DataPackPathBox.Text = Path.Combine(Utils.FindMinecraftPackFolder(), "saves", PackNameTextBox.Text, "datapacks");
                outputPath = DataPackPathBox.Text;
                dataPackPathSet = true;
            }

            if (!dataPackPathSet)
            {
                DataPackPathBox.Text = "";
            }


            try
            {
                IMediaAnalysis analysis = null;
                bool queueThrow = false;
                string throwReason = "";
                try
                {
                    analysis = FFProbe.Analyse(UploadPathTextBox.Text);

                }
                catch
                {
                    queueThrow = true;
                    throwReason += "\nUnrecognized file.";
                }

                if (analysis != null)
                {
                    VideoSlider.Enabled = true;

                    if (analysis.PrimaryVideoStream != null)
                    {
                        inputFile = UploadPathTextBox.Text;

                        SetupWidthHeightScaleTextBoxes(analysis);

                        SetupDurationTexts(analysis);

                        PreloadPreviewImages(inputFile);
                        VideoSlider.Value = 1;
                        VideoSlider_Scroll(null, null);
                    }
                    else
                    {
                        queueThrow = true;
                        throwReason += "\nNo primary video stream.";
                    }

                    ParseStartTime(null, null);
                    ParseEndTime(null, null);


                    if (analysis.PrimaryAudioStream == null)
                    {
                        queueThrow = true;
                        throwReason += "\nNo primary audio stream.";
                    }

                }
                else
                {
                    queueThrow = true;
                    throwReason += "\nAnalysis of uploaded file failed: Analysis null";
                    VideoSlider.Enabled = false;
                }

                if (queueThrow)
                {
                    throw new Exception("Could not upload " + UploadPathTextBox.Text + ":\n" + throwReason + "\n\nPlease choose a different file.");
                }
            }
            catch (Exception ex)
            {
                if (UploadPathTextBox.Text != "")
                {

                    MessageBox.Show(ex.Message, "Error");
                    Logger?.Log("File error", ILogger.LogLevel.Progress);
                    UploadPathTextBox.Text = "";
                }
            }

        }
        private APIConfiguration SetupArgs()
        {
            inputFile = UploadPathTextBox.Text;
            if (inputFile == null || inputFile == string.Empty || inputFile == "")
            {
                throw new Exception("No file uploaded");
            }

            var analysis = FFProbe.Analyse(inputFile);
            if (analysis.PrimaryVideoStream == null || analysis.PrimaryAudioStream == null)
            {
                string reason = "";
                if (analysis.PrimaryVideoStream == null)
                {
                    reason += "\nNo primary video stream";
                }
                if (analysis.PrimaryAudioStream == null)
                {
                    reason += "\nNo primary audio stream";
                }


                throw new Exception("Cannot use " + inputFile + " to create a pack: " + reason);
            }
            scale = ParseNumberFromNumericUpDown(ScaleUpDown);
            movieName = PackNameTextBox.Text;

            startTime = ParseTimeSpan(StartHoursTextBox, StartMinutesTextBox, StartSecondsTextBox);

            endTime = ParseTimeSpan(EndHoursTextBox, EndMinutesTextBox, EndSecondsTextBox);

            width = (int)ParseNumberFromNumericUpDown(WidthUpDown);

            height = (int)ParseNumberFromNumericUpDown(HeightUpDown);


            ticksPerSecond = (int)ParseNumberFromNumericUpDown(TicksPerSecondUpDown);
            endAudioOnLastFrame = EndAudioOnLastFrameCheckBox.Checked;


            if (outputType == V2MCOutputType.custom)
            {
                outputPath = OutputPathTextBox.Text;
            }
            else if (outputType == V2MCOutputType.autoInstall)
            {
                outputPath = DataPackPathBox.Text;
            }

            if (!Directory.Exists(outputPath))
            {
                throw new Exception("Output directory does not exist:" + outputPath);
            }


            if (ScaleOverrideCheckBox.Checked)
            {
                config = new APIConfiguration(inputFile, width, height, movieName, startTime, endTime, endAudioOnLastFrame, outputPath, ScreenWidthScale, ScreenHeightScale, outputType, ticksPerSecond, 26, 22, false, Logger);
            }
            else
            {
                config = new APIConfiguration(inputFile, scale, movieName, startTime, endTime, endAudioOnLastFrame, outputPath, ScreenScale, outputType, ticksPerSecond, 26, 22, false, Logger);
            }
            return config;

        }

        private double ParseNumberFromTextBox(TextBox numberBox)
        {
            try
            {

                if (double.TryParse(numberBox.Text, out double parsedNumber))
                {
                    return parsedNumber;
                }
                else
                {
                    throw new Exception("Unable to parse " + numberBox);
                }
            }
            catch
            {
                Logger?.Log("Unable to parse " + numberBox.Name, ILogger.LogLevel.Progress);
                return 0;
            }
        }
        private double ParseNumberFromNumericUpDown(NumericUpDown numberBox)
        {
            try
            {

                return Convert.ToDouble(numberBox.Value);
            }
            catch
            {
                Logger?.Log("Unable to parse " + numberBox.Name, ILogger.LogLevel.Progress);
                return 0;
            }
        }
        private void CheckTimeInputBoxUnparsable(TextBox inputBox)
        {
            if (!int.TryParse(inputBox.Text, out int i))
            {
                if (!unparsableTimeBoxes.Contains(inputBox))
                    unparsableTimeBoxes.Add(inputBox);
            }
            else
            {
                if (unparsableTimeBoxes.Contains(inputBox))
                    unparsableTimeBoxes.Remove(inputBox);
            }
        }

        private TimeSpan ParseTimeSpan(TextBox hoursBox, TextBox minutesBox, TextBox secondsBox, bool throwError = true)
        {
            string throwReason = "";
            bool queueThrow = false;
            int hours = 0, minutes = 0, seconds = 0;

            CheckTimeInputBoxUnparsable(hoursBox);
            CheckTimeInputBoxUnparsable(minutesBox);
            CheckTimeInputBoxUnparsable(secondsBox);

            if (!int.TryParse(hoursBox.Text, out hours) || !int.TryParse(minutesBox.Text, out minutes) || !int.TryParse(secondsBox.Text, out seconds) || unparsableTimeBoxes.Count > 0)
            {
                queueThrow = true;
                string unparsedBoxes = "";


                unparsableTimeBoxes.Sort((emp1, emp2) =>
                {
                    return emp1.TabIndex.CompareTo(emp2.TabIndex);
                });


                foreach (TextBox box in unparsableTimeBoxes)
                {
                    unparsedBoxes += "\n" + box.Name;

                }
                unparsedBoxes = unparsedBoxes.Replace("TextBox", "");

                throwReason += "\nCould not parse time inputs: " + unparsedBoxes;
            }

            TimeSpan span = new TimeSpan(hours, minutes, seconds);

            if (span.TotalMilliseconds < 0)
            {
                queueThrow = true;
                throwReason += "\nInputted time is negative.";
            }
            if (span.TotalMilliseconds > Duration.TotalMilliseconds)
            {
                queueThrow = true;
                if (inputFile != null)
                {
                    if (Duration.TotalMilliseconds > 0)
                    {
                        throwReason += "\nInputted time is past the end of the video.";
                    }
                    else if (Duration.TotalMilliseconds == 0)
                    {

                        throwReason += "\nThe duration of the uploaded file is zero";

                    }
                    else
                    {
                        throwReason += "\nThe duration of the uploaded file is less than zero. How did you manage to do that?";
                    }
                }
                else
                {
                    throwReason += "\nNo file uploaded";
                }
            }

            if (queueThrow && throwError)
            {
                throw new Exception("Invalid time: \n" + throwReason);
            }
            else if (queueThrow && !throwError)
            {
                Logger?.Log("Invalid time: " + throwReason.Replace("\n", " "), ILogger.LogLevel.Progress);
                span = TimeSpan.Zero;
            }
            else
            {
                if (unparsableTimeBoxes.Count == 0)
                {
                    Logger?.Log("", ILogger.LogLevel.Progress);
                }
            }


            return span;
        }

        private void AutoInstallCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            bool autoInstall = AutoInstallCheckBox.Checked;

            //ResourcePackPathBox.Enabled = autoInstall;
            DataPackPathBox.Enabled = autoInstall;
            OutputPathTextBox.Enabled = !autoInstall;

            outputType = autoInstall ? V2MCOutputType.autoInstall : V2MCOutputType.custom;

        }

        private void ScaleOverrideCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            bool useWHOverride = ScaleOverrideCheckBox.Checked;

            WidthUpDown.Enabled = useWHOverride;
            HeightUpDown.Enabled = useWHOverride;
            ScreenWidthUpDown.Enabled = useWHOverride;
            ScreenHeightUpDown.Enabled = useWHOverride;
            ScaleUpDown.Enabled = !useWHOverride;
            ScreenScaleUpDown.Enabled = !useWHOverride;

            useScale = !useWHOverride;


        }


        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {


            string data = openFileDialog1.FileName;
            UploadPathTextBox.Text = data;
            InitializeUploadedFile();

        }
        private void BrowseButton_Click(object sender, EventArgs e)
        {

            browseField = BrowseButtonField.Upload;
            openFileDialog1.Filter = "Video Files|*.mp4;*.mov;*.webm;*.avi";
            openFileDialog1.ShowDialog();
        }
        private void OutputBrowse_Click(object sender, EventArgs e)
        {
            browseField = BrowseButtonField.Output;
            folderBrowserDialog1.ShowDialog();
            OutputPathTextBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void ResourcePackBrowse_Click(object sender, EventArgs e)
        {
            browseField = BrowseButtonField.Resource;
            folderBrowserDialog1.ShowDialog();
            ResourcePackPathBox.Text = folderBrowserDialog1.SelectedPath;

        }

        private void DataPackBrowse_Click(object sender, EventArgs e)
        {
            browseField = BrowseButtonField.Data;
            folderBrowserDialog1.ShowDialog();
            DataPackPathBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private async void ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                SetAllEnabled(false);

                Cursor = Cursors.WaitCursor;
                if (!conversionStarted)
                {
                    conversionStarted = true;
                    var config = SetupArgs();
                    await Task.Run(() =>
                   {
                       api = new API(config);
                       try
                       {
                           CancelButton.Invoke(() => { CancelButton.Enabled = true; });
                           api.Generate();

                       }
                       catch (Exception e)
                       {
                           CancelButton.Invoke(() => { CancelButton.Enabled = false; });
                           if (e is CannotOverwriteException)
                           {

                               if (MessageBox.Show("Do you want to overwrite the existing file: " + e.Message + "?", "Ouput file already exists.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                               {

                                   config.CanOverwrite = true;
                                   api = new API(config);
                                   try
                                   {
                                       CancelButton.Invoke(() => { CancelButton.Enabled = true; });
                                       api.Generate();
                                   }
                                   catch (Exception e2)
                                   {
                                       if (e2 is OperationCanceledException)
                                       {
                                           //Logger?.Log("Canceled.", ILogger.LogLevel.Progress);
                                       }
                                       else
                                       {

                                           MessageBox.Show(e2.Message + " \nInner Exception:\n" + e2.InnerException + "\nStack Trace:\n" + e2.StackTrace, "Error");
                                           throw new Exception(e2.Message, e2.InnerException);
                                       }
                                   }
                               }
                               else
                               {
                                   config.Logger?.Log("Aborted generation", ILogger.LogLevel.Progress);
                               }
                           }
                           else
                           {
                               if (e is OperationCanceledException)
                               {
                               }
                               else
                               {

                                   Logger?.Log(e.Message, ILogger.LogLevel.Progress);
                                   MessageBox.Show(e.Message + "\n" + e.InnerException?.Message + "\n" + e.StackTrace, "Error");
                               }
                           }
                       }
                   });
                }
                else
                {

                }
            }
            catch (Exception ex)
            {



                Logger?.Log(ex.Message, ILogger.LogLevel.Progress);
                MessageBox.Show(ex.Message, "Error");

                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                SetAllEnabled(true);
                conversionStarted = false;
                CancelButton.Enabled = false;

            }
            /*            conversionStarted = !conversionStarted;
                        ConvertButton.Text = conversionStarted ? "Convert!" : "Cancel";
            */
        }

        private void ScaleTextBox_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(ScaleUpDown.Value) > 0.01 && Convert.ToDouble(ScaleUpDown.Value) <= 1.0)
            {
                scale = Convert.ToDouble(ScaleUpDown.Value);
                int width = (int)(originalWidth * scale);
                WidthUpDown.Value = Convert.ToDecimal(width);

                int height = (int)(originalHeight * scale);
                HeightUpDown.Value = Convert.ToDecimal(height);

                Logger?.Log("", ILogger.LogLevel.Progress);

                VideoSlider_Scroll(null, null);
            }
            else
            {
                Logger?.Log("Invalid scale", ILogger.LogLevel.Progress);
            }
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            width = (int)ParseNumberFromNumericUpDown(WidthUpDown);
            VideoSlider_Scroll(null, null);
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            height = (int)ParseNumberFromNumericUpDown(HeightUpDown);
            VideoSlider_Scroll(null, null);

        }
        void CloseApplication(object sender, EventArgs e)
        {
            //MessageBox.Show("closing");
            CancelButton_Click(sender, e);
        }
        private void ParseStartTime(object sender, EventArgs e)
        {

            CheckTimeInputBoxUnparsable(StartHoursTextBox);
            CheckTimeInputBoxUnparsable(StartMinutesTextBox);
            CheckTimeInputBoxUnparsable(StartSecondsTextBox);

            CheckTimeInputBoxUnparsable(EndHoursTextBox);
            CheckTimeInputBoxUnparsable(EndMinutesTextBox);
            CheckTimeInputBoxUnparsable(EndSecondsTextBox);
            try
            {
                startTime = ParseTimeSpan(StartHoursTextBox, StartMinutesTextBox, StartSecondsTextBox, false);
                //PreloadPreviewImages(inputFile, false);
            }
            catch (Exception ex)
            {
                Logger?.Log("Unable to parse StartTime: " + ex.Message, ILogger.LogLevel.Progress);
                if (sender != null)
                {
                    throw new Exception("Unable to parse StartTime: " + ex.Message);
                }
            }
        }
        private void ParseEndTime(object sender, EventArgs e)
        {
            CheckTimeInputBoxUnparsable(StartHoursTextBox);
            CheckTimeInputBoxUnparsable(StartMinutesTextBox);
            CheckTimeInputBoxUnparsable(StartSecondsTextBox);

            CheckTimeInputBoxUnparsable(EndHoursTextBox);
            CheckTimeInputBoxUnparsable(EndMinutesTextBox);
            CheckTimeInputBoxUnparsable(EndSecondsTextBox);
            try
            {
                endTime = ParseTimeSpan(EndHoursTextBox, EndMinutesTextBox, EndSecondsTextBox, false);
                //PreloadPreviewImages(inputFile, false);

            }
            catch (Exception ex)
            {
                Logger?.Log("Unable to parse EndTime: " + ex.Message, ILogger.LogLevel.Progress);
                if (sender != null)
                {
                    throw new Exception("Unable to parse EndTime: " + ex.Message);
                }
            }
        }


        private void PreloadPreviewImages(string inputFile)
        {
            foreach (var imageInDirectory in Directory.GetFiles(previewDirectory))
            {
                File.Delete(imageInDirectory);
            }
            for (int i = 0; i <= 10; i++)
            {

                var value = i * 10f;
                var percent = (float)value / (float)100f;
                TimeSpan duration;

                string throwReason = "";
                try
                {

                    ParseStartTime(null, null);
                    ParseEndTime(null, null);
                }
                catch (Exception e)
                {
                    throwReason += "\n" + e.Message;
                    Logger?.Log(e.Message, ILogger.LogLevel.Progress);
                }

                try
                {
                    duration = endTime - startTime;
                    var timeAt = duration * percent;

                    CreatePreviewImage(inputFile, timeAt, i);
                }
                catch (Exception ex)
                {
                    throwReason = "\n" + ex.Message;
                    Logger?.Log("Unable to display preview image: " + throwReason, ILogger.LogLevel.Progress);
                }


            }
        }

        private void VideoSlider_Scroll(object sender, EventArgs e)
        {
            if (VideoSlider.Enabled != true)
                return;
            try
            {
                PreviewImage.ImageLocation = Path.Combine(previewDirectory, "Preview" + VideoSlider.Value + ".png");

            }
            catch (Exception ex)
            {
                Logger?.Log("Unable to find image. " + ex.Message, ILogger.LogLevel.Progress);
            }

        }

        private async void ReloadPreviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                SetAllEnabled(false);

                Cursor = Cursors.WaitCursor;
                PreviewImage.Image = null;
                Directory.Delete(previewDirectory, true);
                Directory.CreateDirectory(previewDirectory);
                await Task.Run(() =>
                {
                    PreloadPreviewImages(inputFile);
                }
                );
            }
            catch (Exception ex)
            {
                Logger?.Log("Reload failed: " + ex.Message, ILogger.LogLevel.Progress);
            }
            finally
            {
                Cursor = Cursors.Default;
                SetAllEnabled(true);


                if (PreviewImage.ImageLocation != null || PreviewImage.ImageLocation != "" || PreviewImage.ImageLocation != string.Empty)
                {
                    VideoSlider_Scroll(null, null);
                }

            }
        }

        private void UploadPathTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                InitializeUploadedFile();
            }
        }


        private void SetAllEnabled(bool enable)
        {
            foreach (Control c in Controls)
            {


                if (enable)
                {
                    if (ControlsToNotChangeEnable.Contains(c))
                    {
                        ControlsToNotChangeEnable.Remove(c);
                        continue;
                    }

                }
                else
                {
                    if (c.Enabled == false)
                    {
                        ControlsToNotChangeEnable.Add(c);
                        continue;
                    }
                }


                c.Enabled = enable;
            }
        }

        private void SizeAndTimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)Keys.Enter)
            {

                ReloadPreviewButton_Click(sender, e);
            }
        }


        private void ResetTimeBoxes(object sender, EventArgs e)
        {
            StartHoursTextBox.Text = "00";
            StartMinutesTextBox.Text = "00";
            StartSecondsTextBox.Text = "00";


            EndHoursTextBox.Text = Duration.Hours.ToString("00");
            EndMinutesTextBox.Text = Duration.Minutes.ToString("00");
            EndSecondsTextBox.Text = Duration.Seconds.ToString("00");
        }

        private void ScreenWidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            var updown = (NumericUpDown)sender;
            if (updown.Value > 0 && updown.Value <= 4)
            {
                ScreenWidthScale = (float)updown.Value;
            }
        }
        private void ScreenHeightUpDown_ValueChanged(object sender, EventArgs e)
        {
            var updown = (NumericUpDown)sender;
            if (updown.Value > 0 && updown.Value <= 4)
            {
                ScreenHeightScale = (float)updown.Value;
            }
        }
        private void ScreenScaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            var updown = (NumericUpDown)sender;
            if (updown.Value > 0 && updown.Value <= 4)
            {
                ScreenScale = (float)updown.Value;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (api != null)
            {
                if (api.Cancelable)
                {

                    api?.KillGeneration();
                    Logger?.Log("Canceling...", ILogger.LogLevel.Progress);
                }
                else
                {
                    Logger?.Log("Nothing to cancel", ILogger.LogLevel.Progress);

                }
            }
            else
            {
                Logger?.Log("Nothing to cancel", ILogger.LogLevel.Progress);
            }
        }

        private void V2MC_Load(object sender, EventArgs e)
        {

            if (!FFmpegLoader.FFMpegSetup(ffmpegFileDialog))
            {
                //MessageBox.Show("Fatal error setting up FFmpeg. Closing the program.", "Fatal Error");
                Close();
            }

        }

        private void OpenFFmpegLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://ffmpeg.org/");
        }

        //https://stackoverflow.com/questions/4580263/how-to-open-in-default-browser-in-c-sharp
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void OpenItchLink(object sender, EventArgs e)
        {
            OpenUrl("https://treadthedawngames.itch.io/");

        }

        private void OpenImgMgkLink(object sender, EventArgs e)
        {
            OpenUrl("https://imagemagick.org/");
        }

        private void OpenGitHubLink(object sender, EventArgs e)
        {
            OpenUrl("https://github.com/treadthedawngames/V2MC");
        }

        private void OpenFFmpegLink(object sender, EventArgs e)
        {
            OpenUrl("https://ffmpeg.org/");
        }

        //https://stackoverflow.com/questions/11365984/c-sharp-open-file-with-default-application-and-parameters
        private void HelpButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    OpenUrl("https://treadthedawn.games/Downloads/v2mcInstructions.txt");
                }
                return;
            }
            catch { }

            if (File.Exists("v2mcInstructions.txt"))
            {
                try
                {

                    using Process fileopener = new Process();

                    fileopener.StartInfo.FileName = "explorer";
                    fileopener.StartInfo.Arguments = "\"" + "v2mcInstructions.txt" + "\"";
                    fileopener.Start();

                }
                catch
                {
                    MessageBox.Show("There was an error opening v2mcInstructions.txt");
                }
            }
            else
            {
                MessageBox.Show("v2mcInstructions.txt is missing", "Help not Found");
            }
        }
    }
}
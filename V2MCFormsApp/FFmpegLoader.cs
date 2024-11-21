using FFMpegCore;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V2MCRPLib.Utilities;

namespace V2MCFormsApp
{
    internal static class FFmpegLoader
    {
        

        static bool IsUserInstalledFFmpeg(FFTool tool, OpenFileDialog ffmpegFileDialog)
        {
            //if the tool is installed, don't bother with setup
            if (Utils.IsToolInstalled(tool))
            {
                return true;
            }

            int attempts = 0;
            while (true)
            {
                DialogResult isInstalledResult;

                if(attempts>0)
                {
                    isInstalledResult = DialogResult.No;
                }
                else
                {
                    isInstalledResult = MessageBox.Show($"{tool.ToString()} was not automatically detected on your system.\nDo you have {tool.ToString()} installed?", "Unable to Locate Dependency", MessageBoxButtons.YesNoCancel);
                }
                

                
                attempts++;
                switch (isInstalledResult)
                {

                    case DialogResult.Cancel:
                        return false;

                    case DialogResult.Yes:

                        if(IsFFmpegInstalledElsewhere(tool, ffmpegFileDialog))
                        {
                            return true;
                        }
                        else
                        {
                            continue;

                        }

                    case DialogResult.No:
                        return IsDownloadSuccessful();

                }

            }

            //return false;
        }

        static bool IsFFmpegInstalledElsewhere(FFTool tool, OpenFileDialog ffmpegFileDialog)
        {
            int attempts = 0;
            while (true)
            {

                if (Utils.IsToolInstalled(tool))
                {
                    return true;
                }
                else if (attempts > 0)
                {
                    switch (MessageBox.Show($"{tool} was not found at path \"{ffmpegFileDialog.FileName}\".\nTry again?", "Unable to locate FFmpeg", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            break;
                        case DialogResult.No:
                            return false;
                    }


                }

                attempts++;
                ffmpegFileDialog.ShowDialog();
                string file = ffmpegFileDialog.FileName;
                if (ffmpegFileDialog.CheckPathExists)
                {

                    var opt = new FFOptions();


                    opt.BinaryFolder = Directory.GetParent(Path.GetFullPath(file)).ToString(); ;


                    GlobalFFOptions.Configure(opt);
                    continue;
                }

            }
        }

        static bool IsDownloadSuccessful()
        {
            bool retrying = false;
            while (true)
            {
                DialogResult result;

                if (!retrying)
                {
                    result = MessageBox.Show("Do you want to automatically download and install FFMpeg Full?", "Automatically Install?", MessageBoxButtons.YesNoCancel);
                }
                else
                {
                    result = DialogResult.Yes;
                }

                switch (result)
                {
                    case DialogResult.Yes:
                        try
                        {
                            DownloadFFmpeg();
                        }
                        catch (Exception ex)
                        {
                            switch (MessageBox.Show("There was a problem downloading FFmpeg. Do you want to retry?", "Download Error", MessageBoxButtons.YesNo))
                            {
                                case DialogResult.Yes:
                                    retrying = true;
                                    continue;

                                case DialogResult.No:
                                    return false;
                                case DialogResult.Cancel:
                                    return false;
                                default: return false;
                            }
                        }
                        return true;

                    case DialogResult.No:
                        return false;

                    default: return false;
                }
            }
        }
        public static async Task DownloadAsync(string requestUri, string filename, CancellationToken token)
        {
            if (filename == null)
                throw new ArgumentNullException("filename");

            try
            {

                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
                    {
                        using (
                            Stream contentStream = await (await httpClient.SendAsync(request, token)).Content.ReadAsStreamAsync(token),
                            stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                        {
                            await contentStream.CopyToAsync(stream, token);
                        }
                    }
                }
            }
            catch (TaskCanceledException tc)
            {
                MessageBox.Show("Download canceled.");
            }
        }
        public static void DownloadFFmpeg()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            
            Task.Run(() =>
            {
                switch (MessageBox.Show("Downloading FFmpeg Full...", "Downloading", MessageBoxButtons.OKCancel))
                {
                  
                    case DialogResult.OK:
                        break;

                    case DialogResult.Cancel:
                        cancellationTokenSource.Cancel();
                        break;
                }
            });
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, "https://github.com/GyanD/codexffmpeg/releases/download/2024-11-18-git-970d57988d/ffmpeg-2024-11-18-git-970d57988d-full_build.zip"))
                    {
                        using (
                            Stream contentStream = (httpClient.Send(request,token)).Content.ReadAsStream(token),
                            stream = new FileStream($".\\ffmpeg.zip", FileMode.Create, FileAccess.Write, FileShare.None, 4096, false))
                        {
                            contentStream.CopyTo(stream);
                        }
                    }
                }

                ZipFile.ExtractToDirectory($".\\ffmpeg.zip", "ffmpeg", true);
                File.Delete($".\\ffmpeg.zip");
                var opt = new FFOptions();
                opt.BinaryFolder = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg", "ffmpeg-2024-11-18-git-970d57988d-full_build", "bin");
                GlobalFFOptions.Configure(opt);
                SendKeys.Send("{ESC}");


            }
            catch (Exception e)
            {
                string msg = e.Message;
                if (e is HttpRequestException)
                {
                    SendKeys.Send("{ESC}");
                    MessageBox.Show(e.Message, "Internet Error");
                    msg = "Internet Error";
                }
                else
                {
                    MessageBox.Show(e.Message, "Error");
                }
                throw new Exception(msg);
            }
        }



        public static bool FFMpegSetup(OpenFileDialog ffmpegFileDialog)
        {
            string originalPath = GlobalFFOptions.Current.BinaryFolder;
            if (File.Exists("ffmpegSetupLocation.txt"))
            {
                using (StreamReader sw = new StreamReader("ffmpegSetupLocation.txt"))
                {
                    var opt = new FFOptions();
                    try
                    {
                        opt.BinaryFolder = sw.ReadLine();
                        GlobalFFOptions.Configure(opt);
                        if (!Utils.IsToolInstalled(FFTool.FFmpeg))
                        {
                            if (!Utils.IsToolInstalled(FFTool.FFProbe))
                            {
                                opt.BinaryFolder = originalPath;
                            }
                        }

                    }
                    catch
                    {
                        //do nothing and proceed to checking manually
                    }
                }
            }
            //if ffmpeg exists locally, don't bother doing ffmpeg setup
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg", "ffmpeg-2024-11-18-git-970d57988d-full_build", "bin")))
            {

                var opt = new FFOptions();
                opt.BinaryFolder = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg", "ffmpeg-2024-11-18-git-970d57988d-full_build", "bin");
                GlobalFFOptions.Configure(opt);


                return Utils.IsToolInstalled(FFTool.FFProbe) && Utils.IsToolInstalled(FFTool.FFmpeg);
            }
            else
            {
                //try setting up ffmpeg
                if (TrySetupFFmpeg(ffmpegFileDialog))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        static bool TrySetupFFmpeg(OpenFileDialog ffmpegFileDialog)
        {
            bool missingFFmpeg = !IsUserInstalledFFmpeg(FFTool.FFmpeg, ffmpegFileDialog);
            string ffmpegInstallLocation = GlobalFFOptions.Current.BinaryFolder;
            bool missingFFProbe = true;

            string ffprobeInstallLocation = "";

            //if ffmpeg is gone, check if ffprobe is too because it's gonna show the not installed message anyway, so why prompt the user to show ffprobe?
            if (missingFFmpeg)
            {
                //missing == opposite of whether it's installed
                missingFFProbe = !Utils.IsToolInstalled(FFTool.FFProbe);
            }
            else
            {
                missingFFProbe = !IsUserInstalledFFmpeg(FFTool.FFProbe, ffmpegFileDialog);
                ffprobeInstallLocation = GlobalFFOptions.Current.BinaryFolder;

            }

           

            if (missingFFmpeg || missingFFProbe)
            {
                string missings = (missingFFmpeg == true ? "\nFFmpeg" : "") + (missingFFProbe == true ? "\nFFProbe" : "");
                MessageBox.Show("You can't use this program without FFmpeg or FFProbe.\nMissing dependencies: " + missings, "Unable to start V2MC: Missing Dependencies");
                return false;
            }
            else if (ffprobeInstallLocation != ffmpegInstallLocation)
            {
                MessageBox.Show("Unable to start V2MC:\nFFmpeg and FFProbe must exist within the same directory.", "Unable to start V2MC: Mismatched Directories");
                return false;
            }
            else
            {
                if (!File.Exists("ffmpegSetupLocation.txt"))
                {
                    FileStream st = File.Create("ffmpegSetupLocation.txt");
                    st.Close();
                }


                using (StreamWriter sw = new StreamWriter(Path.GetFullPath("ffmpegSetupLocation.txt")))
                {
                    sw.WriteLine(GlobalFFOptions.Current.BinaryFolder);
                    sw.Close();
                    sw.Dispose();
                }
                return true;
            }
        }
    }
}

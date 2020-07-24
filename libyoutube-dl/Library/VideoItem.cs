using System;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Net;
using System.IO;

namespace libyoutube_dl
{
    /// <summary>
    /// Represents a video from the web that has features such as to query its informations and even download it in various formats.
    /// </summary>
    public class VideoItem
    {
        /// <summary>The title of the video.</summary>
        public string VideoTitle { get; private set; }

        /// <summary>The URL of the video.</summary>
        public string VideoUrl { get; private set; }

        /// <summary>The Format of the video.</summary>
        public string VideoFormat { get; private set; }

        /// <summary>The length of the video.</summary>
        public string VideoLength { get; private set; }

        /// <summary>The path of the video file. Available when the downloading started.</summary>
        public string VideoFilePath { get; private set; }

        /// <summary>The path of the original video file if the conversion is complete this file is being deleted. Available when the downloading and conversion is completed.</summary>
        public string OriginalVideoFilePath { get; private set; }

        /// <summary>An identifier when an error happens during the download. Available when the StatusCode = Error.</summary>
        public string ErrorID { get; private set; }

        /// <summary>If the video is resuming downloading it gives back the position where the download was interrupted.</summary>
        public int ResumedAtByte { get; private set; } = 0;

        /// <summary>Returns the percentage completed of the download.</summary>
        public int Download_Percent { get; private set; } = 0;

        /// <summary>Returns the actual speed of download while download is progress.</summary>
        public string Download_Speed { get; private set; } = "";

        /// <summary>Returns the remaining time of the downloading progress.</summary>
        public string Download_ETA { get; private set; } = "";

        /// <summary>The size of the video file. Available when the downloading started.</summary>
        public string FileSize { get; private set; }

        /// <summary>The item's zero-based index in the collection.</summary>
        public int ListIndex { get; set; }

        /// <summary>Returns true if the informations of the video was queried.</summary>
        public bool InfoQueried { get; private set; } = false;

        /// <summary>Returns true if the querying of informations of the video is in progress.</summary>
        public bool InfoQuerying { get; private set; } = false;

        /// <summary>Returns true if the formatlist of the video was queried.</summary>
        public bool FormatQueried { get; private set; } = false;

        /// <summary>Returns true if the querying of formatlist of the video is in progress.</summary>
        public bool FormatQuerying { get; private set; } = false;

        /// <summary>Returns true if the video was already downloaded.</summary>
        public bool VideoQueried { get; private set; } = false;

        /// <summary>Returns true if downloading of the video is in progress.</summary>
        public bool VideoQuerying { get; private set; } = false;

        /// <summary>If the video's information query is required set this property true to indicate to the scheduler to deal with it.</summary>
        public bool ToQueryInfo { get; set; } = false;

        /// <summary>If the video's formatlist query is required set this property true to indicate to the scheduler to deal with it.</summary>
        public bool ToQueryFormat { get; set; } = false;

        private bool toQueryVideo;

        /// <summary>If the video's download is required set this property true to indicate to the scheduler to deal with it.</summary>
        public bool ToQueryVideo { get { return toQueryVideo; } set { if (value && !VideoQueried) StatusCode = DownloadingStatusCode.Pending; toQueryVideo = value; } }

        private DownloadingStatusCode statusCode;

        /// <summary>Gets the current status of the video downloading.</summary>
        public DownloadingStatusCode StatusCode { get { return statusCode; } private set { statusCode = value; OnStatusCodeChanged(StatusChangeArgs); } }

        /// <summary>Status codes during the downloading.</summary>
        public enum DownloadingStatusCode
        {
            /// <summary>No activity.</summary>
            Idle = 0,
            /// <summary>Downloading not started yet, but marked for downloading for the scheduler.</summary>
            Pending = 1,
            /// <summary>The external downloader has started, waiting for the the progress data from it.</summary>
            Starting = 2,
            /// <summary>The external downloader reported the file downloading is aborted previously and now continuing.</summary>
            Resuming = 3,
            /// <summary>The external downloader reported the file already exists in the output directory.</summary>
            Already = 4,
            /// <summary>The external downloader is sending downloading status information.</summary>
            Downloading = 5,
            /// <summary>The external downloader is using the converter program.</summary>
            Converting = 6,
            /// <summary>The external downloader is deleting the original file.</summary>
            Deletingoriginal = 7,
            /// <summary>The external downloader is embedding the cover art image to the file.</summary>
            Addingthumbnail = 8,
            /// <summary>The aborting of the download has requested.</summary>
            Aborting = 9,
            /// <summary>The aborting process is finished.</summary>
            Aborted = 10,
            /// <summary>The external downloader reported an error during the downloading. The error code can be read from ErrorID property.</summary>
            Error = 11,
            /// <summary>The external downloader is successfully downloaded the file.</summary>
            Finished = 12
        }

        private GetInfoProcess GetInfoProcessObject;
        private GetFormatProcess GetFormatProcessObject;
        private GetVideoProcess GetVideoProcessObject;
        private Settings VideoSettings;
        private bool InterruptingVDownload = false;

        /// <summary>The thumbnail image of the video. Can be used as album cover.</summary>
        public Bitmap ThumbnailImage { get; private set; }

        /// <summary>List of available formats of the video.</summary>
        public VideoFormatList FormatList;

        /// <summary>Initializes a new instance of the VideoItem.</summary>
        /// <param name="videourl">The Url of the Video.</param>
        /// <param name="settings">An existing instance of Settings class must be declared within your application. This contains many setting option for the downloader.</param>
        public VideoItem(string videourl, ref Settings settings)
        {
            VideoUrl = videourl;
            VideoSettings = settings; // References to the original settings object in the main program. Not a new instance.
            InfoQueryArgs = new InfoQueryEventArgs();
            FormatQueryArgs = new EventArgs();
            VideoArgs = new EventArgs();
            FormatList = new VideoFormatList();
            FormatList.SelectedIndexChanged += FormatList_SelectedIndexChanged;
        }

        private void FormatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoFormat = FormatList[FormatList.SelectedIndex].Note;
        }

        // Downloading image. If fails the ThumbnailImage remains null.
        private void DownloadImage(string url)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                Stream stream = req.GetResponse().GetResponseStream();
                string contenttype = req.GetResponse().ContentType;
                switch (contenttype)
                {
                    case "image/png":
                        ThumbnailImage = (Bitmap)Image.FromStream(stream);
                        break;
                    case "image/webp":
                        WebPWrapper.WebP webpformat = new WebPWrapper.WebP();
                        MemoryStream memstream = new MemoryStream();
                        stream.CopyTo(memstream);
                        ThumbnailImage = webpformat.Decode(memstream.ToArray());
                        break;
                    case "image/jpeg":
                        ThumbnailImage = (Bitmap)Image.FromStream(stream);
                        break;
                }
            }
            catch {  }
        }

        private string MakeGIParameters()
        {
            string Paramstr = "--get-title --get-duration --get-format --get-thumbnail --no-warnings ";
            if (VideoSettings.Network_ProxyEnabled) Paramstr += $"--proxy { VideoSettings.Network_ProxyAddress} ";
            Paramstr += $"--socket-timeout {VideoSettings.Network_Timeout} ";
            return Paramstr;
        }

        private string MakeGVParameters()
        {
            string Paramstr = "-o \"" + VideoSettings.Location_Output + "\\" + VideoSettings.Location_FileNameTemplate + "\"" + " "; // "\\%(title)s.%(ext)s\" ";
            if (VideoSettings.Format_ConvertEnabled)
            {
                if (VideoSettings.Format_ConvertAudio)
                    Paramstr += "-x" +
                                " --audio-format " + VideoSettings.Format_ConvertFormat +
                                " --audio-quality " + VideoSettings.Format_Quality +
                                " ";
                if (VideoSettings.Format_ConvertVideo)
                    Paramstr += "--recode-video " + VideoSettings.Format_ConvertFormat +
                                " ";
                if (VideoSettings.Format_KeepOrigin) Paramstr += "-k ";
                if (VideoSettings.Format_EmbedThumbnail && VideoSettings.Format_ConvertAudio) Paramstr += "--embed-thumbnail ";
            }
            Paramstr += "--no-warnings ";
            if (VideoSettings.Network_ProxyEnabled) Paramstr += "--proxy " + VideoSettings.Network_ProxyAddress + " ";
            if (VideoSettings.Credentials_Enabled)
            {
                Paramstr += "-u \"" + VideoSettings.Credentials_Username + "\" -p \"" + VideoSettings.Credentials_Password + "\" ";
                if (VideoSettings.Credentials_TwoFactor_Enabled) Paramstr += "-2 \"" + VideoSettings.Credentials_TwoFactor + "\" ";
            }
            if (VideoSettings.Credentials_VideoPasswordEnabled) Paramstr += "--video-password \"" + VideoSettings.Credentials_VideoPassword + "\" ";
            if (VideoSettings.Network_Ratelimit_Enabled) Paramstr += "-r " + Convert.ToString(VideoSettings.Network_RateLimit) + VideoSettings.Network_RateLimitUnit + " ";
            if (FormatQueried && FormatList[FormatList.SelectedIndex].FormatCode != "default")
            {
                Paramstr += "-f " + FormatList[FormatList.SelectedIndex].FormatCode + " ";
            }
            if ((FormatQueried && FormatList[FormatList.SelectedIndex].FormatCode != "default")||VideoSettings.Format_ConvertEnabled)
            {
                Paramstr += "--socket-timeout " + VideoSettings.Network_Timeout + " ";
                Paramstr += "--ffmpeg-location \"" + VideoSettings.Location_FFmpeg + "\" ";
            }
            return Paramstr;
        }

        private string MakeGFParameters()
        {
            string Paramstr = "-F ";
            if (VideoSettings.Network_ProxyEnabled) Paramstr += $"--proxy {VideoSettings.Network_ProxyAddress} ";
            return Paramstr;
        }

        /// <summary>Start retrieving the informations of the video.</summary>
        /// <returns>True if the process has not run yet before, isn't running and the starting is successful.</returns>
        public bool StartInfoQuery()
        {
            if (!InfoQueried && !InfoQuerying)
            {
                GetInfoProcessObject = new GetInfoProcess(VideoSettings.Location_Downloader, MakeGIParameters() + " " + VideoUrl);
                GetInfoProcessObject.GetInfo += GetInfoProcessObject_GetInfo;
                if (GetInfoProcessObject.StartProcess())
                {
                    InfoQuerying = true;
                    OnInfoQueryStart(InfoQueryStartArgs);
                    return true;
                }
                else { return false; }
            }
            else return false;
        }

        /// <summary>Start retrieving the list of available formats of the video.</summary>
        /// <returns>Returns true if the process has not run yet before, isn't running and the starting is successful.</returns>
        public bool StartFormatQuery()
        {
            if (!FormatQueried && !FormatQuerying)
            {
                GetFormatProcessObject = new GetFormatProcess(VideoSettings.Location_Downloader, MakeGFParameters() + " " + VideoUrl);
                GetFormatProcessObject.GetFormat += GetFormatProcessObject_GetFormat;
                if (GetFormatProcessObject.StartProcess())
                {
                    FormatQuerying = true;
                    return true;
                }
                else { return false; }
            }
            else return false;
        }

        /// <summary>Start the downloading of the video.</summary>
        /// <returns>True if the process has not run yet before, isn't running and the starting is successful.</returns>
        public bool StartVideoQuery()
        {
            if (!VideoQueried && !VideoQuerying)
            {
                GetVideoProcessObject = new GetVideoProcess(VideoSettings.Location_Downloader, MakeGVParameters() + " " + VideoUrl);
                GetVideoProcessObject.GetVideo += GetVideoProcessObject_GetVideo;
                GetVideoProcessObject.DownloadFinished += GetVideoProcessObject_DownloadFinished;
                if (GetVideoProcessObject.StartProcess())
                {
                    VideoQuerying = true;
                    StatusCode = DownloadingStatusCode.Starting;
                    return true;
                }
                else
                    return false;
            }
            else return false;
        }

        /// <summary>Terminates the querying of information of the video and waits until the process stops. It runs asynchronously.</summary>
        /// <returns>True if the operation completed and successful.</returns>
        public async Task<bool> StopInfoQueryAsync()
        {
            if (GetInfoProcessObject != null)
            {
                try { GetInfoProcessObject.Kill(); } catch { return false; } //Terminates the process.
                await Task.Run(() =>
                {
                    while (InfoQuerying) { Thread.Sleep(50); } //Waits for the process completely exit.
                });
                InfoQueried = false;
                return true;
            }
            else return true;
        }

        /// <summary>Terminates the querying of information of the video and waits until the process stops.</summary>
        /// <returns>True if the operation completed and successful.</returns>
        public bool StopInfoQuery()
        {
            if (GetInfoProcessObject != null)
            {
                try { GetInfoProcessObject.Kill(); } catch { return false; } //Terminates the process.
                while (InfoQuerying) { Thread.Sleep(50); } //Waits for the process completely exit.
                InfoQueried = false;
                return true;
            }
            else return true;
        }

        /// <summary>Terminates the querying of formatlist of the video and waits until the process stops. It runs asynchronously.</summary>
        /// <returns>True if the operation completed and successful.</returns>
        public async Task<bool> StopFormatQueryAsync()
        {
            if (GetFormatProcessObject != null)
            {
                try { GetFormatProcessObject.Kill(); } catch { return false; } //Terminates the process.
                await Task.Run(() =>
                {
                    while (FormatQuerying) { Thread.Sleep(50); } //Waits for the process completely exit.
                });
                FormatQueried = false;
                return true;
            }
            else return true;
        }

        /// <summary>Terminates the querying of formatlist of the video and waits until the process stops.</summary>
        /// <returns>True if the operation completed and successful.</returns>
        public bool StopFormatQuery()
        {
            if (GetFormatProcessObject != null)
            {
                try { GetFormatProcessObject.Kill(); } catch { return false; } //Terminates the process.
                while (FormatQuerying) { Thread.Sleep(50); } //Waits for the process completely exit.
                FormatQueried = false;
                return true;
            }
            else return true;
        }

        /// <summary>Stops the downloading of the video and waits until the process stops. It runs asynchronously.</summary>
        /// <returns>True if the operation completed and successful.</returns>
        public async Task<bool> StopVideoQueryAsync()
        {
            if (GetVideoProcessObject != null)
            {
                StatusCode = DownloadingStatusCode.Aborting;
                InterruptingVDownload = true;
                try { GetVideoProcessObject.Kill(); } catch { return false; } //Terminates the process.
                await Task.Run(() =>
                {
                    while (VideoQuerying) { Thread.Sleep(50); } //Waits for the process completely exit.
                });
                VideoQueried = false;
                StatusCode = DownloadingStatusCode.Aborted;
                return true;
            }
            else return true;
        }

        /// <summary>Stops the downloading of the video and waits until the process stops.</summary>
        /// <returns>True if the operation completed and successful.</returns>
        public bool StopVideoQuery()
        {
            if (GetVideoProcessObject != null)
            {
                StatusCode = DownloadingStatusCode.Aborting;
                InterruptingVDownload = true;
                try { GetVideoProcessObject.Kill(); } catch { return false; }   //Terminates the process.
                while (VideoQuerying) { Thread.Sleep(50); } //Waits for the process completely exit.
                VideoQueried = false;
                StatusCode = DownloadingStatusCode.Aborted;
                return true;
            }
            else return true;
        }

        // Get video information event
        private void GetInfoProcessObject_GetInfo(object sender, GetInfoProcess.GetInfoEventArgs e)
        {
            VideoTitle = e.Title;
            VideoFormat = e.Format;
            VideoLength = e.Length;
            DownloadImage(e.ThumbnailUrl);
            if (e.ErrorID == "") InfoQueried = true;
            InfoQueryArgs.ErrorID = e.ErrorID;
            InfoQuerying = false;
            OnInfoQueryFinished(InfoQueryArgs);
        }

        private InfoQueryEventArgs InfoQueryArgs;

        /// <summary>Occurs when the video information query process ends.</summary>
        public event InfoQueryFinishedEventHandler GetInfo;

        /// <summary>Represents the method that handles the VideoItem.GetInfo event.</summary>
        /// <param name="sender">The calling object.</param>
        /// <param name="e">Contains the event data.</param>
        public delegate void InfoQueryFinishedEventHandler(object sender, InfoQueryEventArgs e);

        /// <summary>Raises the GetInfo event.</summary>
        /// <param name="e">Contains the event data.</param>
        protected virtual void OnInfoQueryFinished(InfoQueryEventArgs e)
        {
            GetInfo?.Invoke(this, e);
        }

        /// <summary>Argument class of the GetInfoEventHandler.</summary>
        public class InfoQueryEventArgs : EventArgs
        {
            /// <summary>ID of the error message sent by the downloader. The ID is defined within the definitions file.</summary>
            public string ErrorID { get; set; }
        }


        // Get video format list event
        private void GetFormatProcessObject_GetFormat(object sender, GetFormatProcess.GetFormatEventArgs e)
        {
            string[] f = { "default", "bestvideo+bestaudio/best", "worst" };
            string[] n = { "Youtube-dl default format settings.", "Autoselection of the best quality.", "Autoselection of the worst quality." };
            if (e.ErrorMessage == "")
                for (int i = 0; i < f.Length; i++)
                {
                    FormatProperty PresetItem = new FormatProperty
                    {
                        FormatCode = f[i],
                        Extension = "",
                        Resolution = "",
                        Note = n[i]
                    };
                    FormatList.Add(PresetItem);
                }
            foreach (FormatProperty i in e.FormatProperties)
            {
                FormatList.Add(i);
            }
            if (e.FormatProperties.Count > 0) FormatList.SelectedIndex = 0;
            if (e.ErrorMessage == "") FormatQueried = true;
            FormatQuerying = false;
            OnFormatQueryFinished(FormatQueryArgs);
        }

        private EventArgs FormatQueryArgs;
        /// <summary>Occurs when the video formatlist query process ends.</summary>
        public event GetFormatEventHandler GetFormat;

        /// <summary>Represents the method that handles the VideoItem.GetFormat event.</summary>
        /// <param name="sender">The calling object.</param>
        /// <param name="e">Contains the event data.</param>
        public delegate void GetFormatEventHandler(object sender, EventArgs e);

        /// <summary>Raises the GetFormat event.</summary>
        /// <param name="e">Contains the event data.</param>
        protected virtual void OnFormatQueryFinished(EventArgs e)
        {
            GetFormat?.Invoke(this, e);
        }


        // Video download events
        private void GetVideoProcessObject_GetVideo(object sender, GetVideoProcess.GetVideoEventArgs e)
        {
            try
            {
                string t = e.DLMessageID;
                string[] m = e.DLMessageValues.ToArray();
                switch (t)
                {
                    case "Download_in_progress":
                        Download_Percent = Convert.ToInt32(m[0].Substring(0, m[0].IndexOf('.')));
                        FileSize = m[1];
                        Download_Speed = m[2];
                        Download_ETA = m[3];
                        StatusCode = DownloadingStatusCode.Downloading;
                        break;
                    case "Download_destination":
                        VideoFilePath = m[0];
                        StatusCode = DownloadingStatusCode.Downloading;
                        break;
                    case "Resuming_download":
                        ResumedAtByte = Convert.ToInt32(m[0]);
                        StatusCode = DownloadingStatusCode.Resuming;
                        break;
                    case "Ffmpeg_destination":
                        VideoFilePath = m[0];
                        StatusCode = DownloadingStatusCode.Converting;
                        break;
                    case "Ffmpeg_merging":
                        VideoFilePath = m[0];
                        StatusCode = DownloadingStatusCode.Converting;
                        break;
                    case "Deleting_original":
                        OriginalVideoFilePath = m[0];
                        StatusCode = DownloadingStatusCode.Deletingoriginal;
                        break;
                    case "Download_complete":
                        StatusCode = DownloadingStatusCode.Finished;
                        break;
                    case "Ffmpeg_add_thumbnail":
                        StatusCode = DownloadingStatusCode.Addingthumbnail;
                        break;
                    case "Download_already":
                        VideoFilePath = m[0];
                        Download_Percent = 100;
                        StatusCode = DownloadingStatusCode.Already;
                        break;
                    case "Download_already_size":
                        FileSize = m[0];
                        OnStatusCodeChanged(StatusChangeArgs);
                        break;
                }
                if (t.Contains("Error"))
                {
                    ErrorID = t;
                    StatusCode = DownloadingStatusCode.Error;
                }
                else ErrorID = "Error_general";
            }
            catch { }
            OnVideoDownload(VideoArgs);
        }

        private void GetVideoProcessObject_DownloadFinished(object sender, EventArgs e)
        {
            VideoQuerying = false;
            if (!InterruptingVDownload && StatusCode != DownloadingStatusCode.Already && StatusCode != DownloadingStatusCode.Error)
            {
                VideoQueried = true;
                StatusCode = DownloadingStatusCode.Finished; //if finished normally then set "finished" statuscode.
            }
            else
            {
                if (StatusCode == DownloadingStatusCode.Already) VideoQueried = true;
                //if interrupted then statuscode remain aborted state, Restore default value for the next run.
                //This is needed because this event handler run regardless the finishing mode.
                InterruptingVDownload = false;
            }
            OnVideoDownloadFinished(VideoArgs);
            GetVideoProcessObject.Close();
            GetVideoProcessObject = null;
        }

        private EventArgs VideoArgs;

        /// <summary>Occurs when the external downloader is sending data.</summary>
        public event VideoDownloadEventHandler DownloadingVideo;

        /// <summary>Occurs when the external downloader process ends.</summary>
        public event VideoDownloadFinishedEventHandler DownloadingVideoFinished;

        /// <summary>Represents the method that handles the VideoItem.DownloadingVideo event.</summary>
        /// <param name="sender">The calling object.</param>
        /// <param name="e">Contains the event data.</param>
        public delegate void VideoDownloadEventHandler(object sender, EventArgs e);

        /// <summary>Represents the method that handles the VideoItem.DownloadingVideoFinished event.</summary>
        /// <param name="sender">The calling object.</param>
        /// <param name="e">Contains the event data.</param>
        public delegate void VideoDownloadFinishedEventHandler(object sender, EventArgs e);

        /// <summary>Raises the DownloadingVideo event.</summary>
        /// <param name="e">Contains the event data.</param>
        protected virtual void OnVideoDownload(EventArgs e)
        {
            DownloadingVideo?.Invoke(this, e);
        }

        /// <summary>Raises the DownloadingVideoFinished event.</summary>
        /// <param name="e">Contains the event data.</param>
        protected virtual void OnVideoDownloadFinished(EventArgs e)
        {
            DownloadingVideoFinished?.Invoke(this, e);
        }

        // StatusCodeChanged event
        private EventArgs StatusChangeArgs = new EventArgs();

        /// <summary>Occurs when the StatusCode is changed during the download.</summary>
        public event StatusCodeChangedEventHandler StatusCodeChanged;

        /// <summary>Represents the method that handles the VideoItem.StatusCodeChanged event.</summary>
        /// <param name="sender">The calling object.</param>
        /// <param name="e">Contains the event data.</param>
        public delegate void StatusCodeChangedEventHandler(object sender, EventArgs e);

        /// <summary>Raises the StatusCodeChanged event.</summary>
        /// <param name="e">Contains the event data.</param>
        protected virtual void OnStatusCodeChanged(EventArgs e)
        {
            StatusCodeChanged?.Invoke(this, e);
        }


        // Video information query start event
        // You may needed this event when using this class with VideoItemCollection and use scheduler to query information.
        private EventArgs InfoQueryStartArgs = new EventArgs();

        /// <summary>Occurs when the querying of the video's information starts.</summary>
        public event InfoQueryStartEventHandler InfoQueryStart;

        /// <summary>Represents the method that handles the VideoItem.InfoQueryStart event.</summary>
        /// <param name="sender">The calling object.</param>
        /// <param name="e">Contains the event data.</param>
        public delegate void InfoQueryStartEventHandler(object sender, EventArgs e);

        /// <summary>Raises the InfoQueryStart event.</summary>
        /// <param name="e">Contains the event data.</param>
        protected virtual void OnInfoQueryStart(EventArgs e)
        {
            InfoQueryStart?.Invoke(this, e);
        }
    }
}

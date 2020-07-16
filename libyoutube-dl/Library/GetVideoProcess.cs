using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace libyoutube_dl
{
    /// <summary>Provides access to the external dowloader. It can start, stop and get information from it during the process.</summary>
    /// <remarks>This class can be used to download a video. The location of executable file and the correct parameters must be specified.</remarks>
    internal class GetVideoProcess : Process
    {
        public bool IsCancelled = false;
        public string ErrorStatus;
        //public string URLText;
        private GetVideoEventArgs GVargs;
        public event GetVideoEventHandler GetVideo;
        public event FinishedEventHandler DownloadFinished;
        private ParseOutput ParseOutputLine = new ParseOutput();

        public GetVideoProcess(string ProgramName, string Parameters)
        {
            OutputDataReceived += DProcess_OutputDataReceived;
            ErrorDataReceived += DProcess_OutputDataReceived;
            Exited += DProcess_Exited;
            GVargs = new GetVideoEventArgs();
            GVargs.DLMessageValues = new List<string>();
            ErrorStatus = "";
            //URLText = VideoUrl;
            EnableRaisingEvents = true;
            StartInfo.UseShellExecute = false;
            StartInfo.CreateNoWindow = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.FileName = ProgramName;
            //StartInfo.Arguments = $"{Parameters} {VideoUrl}";
            StartInfo.Arguments = Parameters;
        }

        public bool StartProcess()
        {
            try
            { Start(); }
            catch (Exception e)
            {
                GVargs.DLMessageID = "Error_" + e.Message;
                GVargs.DLMessageValues.Add(e.Message);
                OnGetVideo(GVargs);
                return false;
            }
            BeginOutputReadLine();
            BeginErrorReadLine();
            return true;
        }

        private void DProcess_Exited(object sender, EventArgs e)
        {
            OnFinished(e);
        }

        private void DProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                ParseOutputLine.InputRow = e.Data;
                if (ParseOutputLine.GetMessageID.Contains("Error_"))
                    ErrorStatus = ParseOutputLine.GetMessageID;
                GVargs.DLMessageID = ParseOutputLine.GetMessageID;
                GVargs.DLMessageValues = ParseOutputLine.MessageValues;
                OnGetVideo(GVargs);
            }
        }

        protected virtual void OnGetVideo(GetVideoEventArgs e)
        {
            GetVideo?.Invoke(this, e);
        }

        protected virtual void OnFinished(EventArgs e)
        {
            DownloadFinished?.Invoke(this, e);
        }

        public class GetVideoEventArgs : EventArgs
        {
            public string DLMessageID { get; set; }
            public List<string> DLMessageValues { get; set; }
        }
        public delegate void GetVideoEventHandler(object sender, GetVideoEventArgs e);
        public delegate void FinishedEventHandler(object sender, EventArgs e);
    }
}

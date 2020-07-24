using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace libyoutube_dl
{
    /// <summary>Provides access to the external dowloader. It can start, stop and get information from it at the end of process.</summary>
    /// <remarks>This class can be used to gathering informations about a video. The location of executable file and the correct parameters must be specified.</remarks>
    internal class GetInfoProcess : Process
    {
        private List<string> OutputTexts;
        public string ErrorStatus;
        private GetInfoEventArgs GIargs;
        public event GetInfoEventHandler GetInfo;
        public event FinishedEventHandler GetInfoFinished;
        ParseOutput ParseOutputLine = new ParseOutput();

        public GetInfoProcess(string ProgramName, string Parameters)
        {
            OutputTexts = new List<string>();
            OutputDataReceived += GetinfoProcess_OutputDataReceived;
            ErrorDataReceived += GetinfoProcess_OutputDataReceived;
            Exited += GetInfoProcess_Exited;
            GIargs = new GetInfoEventArgs();
            ErrorStatus = "";
            EnableRaisingEvents = true;
            StartInfo.UseShellExecute = false;
            StartInfo.CreateNoWindow = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.FileName = ProgramName;
            StartInfo.Arguments = Parameters;
        }

        public bool StartProcess()
        {
            try
            { Start(); }
            catch (Exception e)
            {
                ErrorStatus = e.Message;
                GIargs.ErrorID = ErrorStatus;
                OnGetInfo(GIargs);
                return false;
            }
            BeginOutputReadLine();
            BeginErrorReadLine();
            return true;
        }

        private void GetInfoProcess_Exited(object sender, EventArgs e)
        {
            if (ErrorStatus == "" && OutputTexts.Count == 0) ErrorStatus = "No_output_data";
            GIargs.ErrorID = ErrorStatus;
            if (OutputTexts.Count > 0) GIargs.Title = OutputTexts[0]; else GIargs.Title = "Nincs adat";
            if (OutputTexts.Count > 1) GIargs.ThumbnailUrl = OutputTexts[1]; else GIargs.ThumbnailUrl = "Nincs adat";
            if (OutputTexts.Count > 2) GIargs.Length = OutputTexts[2]; else GIargs.Length = "Nincs adat";
            if (OutputTexts.Count > 3) GIargs.Format = OutputTexts[3]; else GIargs.Format = "Nincs adat";
            OnGetInfo(GIargs);
            OnFinished(e);
        }

        private void GetinfoProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                ParseOutputLine.InputRow = e.Data;
                if (ParseOutputLine.GetMessageID.Contains("Error_"))
                    ErrorStatus = ParseOutputLine.GetMessageID;
                else
                    OutputTexts.Add(e.Data);
            }
        }

        protected virtual void OnGetInfo(GetInfoEventArgs e)
        {
            GetInfo?.Invoke(this, e);
        }

        protected virtual void OnFinished(EventArgs e)
        {
            GetInfoFinished?.Invoke(this, e);
        }

        public class GetInfoEventArgs : EventArgs
        {
            public string Title { get; set; }
            public string ThumbnailUrl { get; set; }
            public string Length { get; set; }
            public string Format { get; set; }
            public string ErrorID { get; set; }
        }
        public delegate void GetInfoEventHandler(object sender, GetInfoEventArgs e);
        public delegate void FinishedEventHandler(object sender, EventArgs e);
    }
}

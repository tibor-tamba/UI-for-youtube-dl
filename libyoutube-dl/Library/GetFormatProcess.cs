using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace libyoutube_dl
{
    /// <summary>Provides access to the external dowloader. It can start, stop and get format information from it at the end of process.</summary>
    /// <remarks>This class can be used to query the format list of a video. The location of executable file and the correct parameters must be specified.</remarks>
    internal class GetFormatProcess : Process
    {
        private List<string> OutputTexts;
        public int ListIndex;
        private bool IsReceivingFormatInfo = false;
        int[] FieldOffsets = new int[4];
        //public string URLText;
        private GetFormatEventArgs GFargs;
        public event GetFormatEventHandler GetFormat;
        public event FinishedEventHandler GetFormatFinished;

        public GetFormatProcess(string ProgramName, string Parameters)
        {
            OutputTexts = new List<string>();
            OutputDataReceived += GetFormatProcess_OutputDataReceived;
            ErrorDataReceived += GetFormatProcess_OutputDataReceived;
            Exited += GetFormatProcess_Exited;
            GFargs = new GetFormatEventArgs();
            GFargs.FormatProperties = new List<FormatProperty>();
            //URLText = VideoUrl;
            ListIndex = 0;
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
                GFargs.ErrorMessage = e.Message;
                OnGetFormat(GFargs);
                return false;
            }
            BeginOutputReadLine();
            BeginErrorReadLine();
            return true;
        }

        private void GetFormatProcess_Exited(object sender, EventArgs e)
        {
            if (OutputTexts.Count > 0)
                for (int i = 0; i < OutputTexts.Count; i++)
                {
                    GFargs.FormatProperties.Add(ParseFormatData(OutputTexts[i]));
                }
            else GFargs.ErrorMessage = "No_output_data";
            OnGetFormat(GFargs);
            OnFinished(e);
        }

        private FormatProperty ParseFormatData(string InputStr)
        {
            FormatProperty s = new FormatProperty();
            s.FormatCode = InputStr.Substring(FieldOffsets[0], FieldOffsets[1] - FieldOffsets[0] - 1); s.FormatCode = s.FormatCode.Trim();
            s.Extension = InputStr.Substring(FieldOffsets[1], FieldOffsets[2] - FieldOffsets[1] - 1); s.Extension = s.Extension.Trim();
            s.Resolution = InputStr.Substring(FieldOffsets[2], FieldOffsets[3] - FieldOffsets[2] - 1); s.Resolution = s.Resolution.Trim();
            s.Note = InputStr.Substring(FieldOffsets[3]); s.Note = s.Note.Trim();
            return s;
        }

        private void GetFormatProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (IsReceivingFormatInfo) OutputTexts.Add(e.Data);
                if (e.Data.Contains("format code") && e.Data.Contains("extension") && e.Data.Contains("resolution") && e.Data.Contains("note"))
                {
                    IsReceivingFormatInfo = true;
                    FieldOffsets[0] = e.Data.IndexOf("format code");
                    FieldOffsets[1] = e.Data.IndexOf("extension");
                    FieldOffsets[2] = e.Data.IndexOf("resolution");
                    FieldOffsets[3] = e.Data.IndexOf("note");
                }
            }
        }

        protected virtual void OnGetFormat(GetFormatEventArgs e)
        {
            GetFormat?.Invoke(this, e);
        }

        protected virtual void OnFinished(EventArgs e)
        {
            GetFormatFinished?.Invoke(this, e);
        }

        public class GetFormatEventArgs : EventArgs
        {
            public List<FormatProperty> FormatProperties { get; set; }
            public string ErrorMessage { get; set; } = "";
        }

        public delegate void GetFormatEventHandler(object sender, GetFormatEventArgs e);
        public delegate void FinishedEventHandler(object sender, EventArgs e);
    }
}

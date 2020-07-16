using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using libyoutube_dl;

namespace VideoDownloader
{
    static class Program
    {
        public static void SetDefaultDirectories()
        {
            if (AppSettings.Location_Output == "default") AppSettings.Location_Output = Environment.GetEnvironmentVariable("userprofile") + "\\Videos";
            if (AppSettings.Location_Downloader == "default") AppSettings.Location_Downloader = Application.StartupPath + "\\youtube-dl.exe";
            if (AppSettings.Location_FFmpeg == "default") AppSettings.Location_FFmpeg = Application.StartupPath + "\\ffmpeg";
        }

        public static Settings AppSettings = new Settings();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ThreadPool.GetMinThreads(out int wt_min, out int cpt_min);
            ThreadPool.SetMinThreads(60, cpt_min);
            // Checking whether the neccessary files are exists.
            int NotReady = 0;
            string[] Files = { "libyoutube-dl.dll", "Interop.WMPLib.dll", "AxInterop.WMPLib.dll", "Definitions.xml"};
            //string[] Files = {  };
            for (int i = 0; i < Files.Length; i++)
                if (!File.Exists(Application.StartupPath + "\\" + Files[i]))
                {
                    NotReady++;
                    // Inform the user about the missing files.
                    MessageBox.Show(Languages.Strings.ErrProgramStartMsg + " " + Files[i], Languages.Strings.ErrGeneralTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            // If every files are exists then starts the program.
            if (NotReady == 0)
            {
                AppSettings.Reload();
                SetDefaultDirectories();
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppSettings.Language_Code);
                Application.Run(new MainForm());
            }
        }
    }
}

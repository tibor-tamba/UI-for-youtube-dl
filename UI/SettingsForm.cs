using System;
using System.IO;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Forms;

namespace VideoDownloader
{
    public partial class SettingsForm : Form
    {
        private readonly string[] videof = new string[5] { "mp4", "flv", "webm", "mkv", "avi" };
        private readonly string[] audiof = new string[7] { "mp3", "aac", "flac", "m4a", "opus", "vorbis", "wav" };

        public SettingsForm()
        {
            InitializeComponent();
            LoadComponents();
        }
        private void ChangeFormatList(byte Format)
        {
            FormatBox.Items.Clear();
            string[] fmt;
            if (Format == 0) fmt = audiof; else fmt = videof;
            foreach (string i in fmt) FormatBox.Items.Add(i);
            FormatBox.SelectedIndex = 0;
            FormatBox_SelectionChangeCommitted(new object(), new EventArgs());
        }
        private void LoadComponents()
        {
            ConvertCheck.Checked = Program.AppSettings.Format_ConvertEnabled;
            AudioCheck.Checked = Program.AppSettings.Format_ConvertAudio;
            VideoCheck.Checked = Program.AppSettings.Format_ConvertVideo;
            FormatBox.SelectedItem = Program.AppSettings.Format_ConvertFormat;
            QualitySlider.Value = Program.AppSettings.Format_Quality; QualityTitleV.Text = QualitySlider.Value.ToString();
            KeepOrigCheck.Checked = Program.AppSettings.Format_KeepOrigin;
            ThumbnailCheck.Checked = Program.AppSettings.Format_EmbedThumbnail;

            OutputBox.Text = Program.AppSettings.Location_Output;
            OutputLocBrowser.SelectedPath = Program.AppSettings.Location_Output;
            FfmpegBox.Text = Program.AppSettings.Location_FFmpeg;
            FFmpegLocBrowser.SelectedPath = Program.AppSettings.Location_FFmpeg;
            DownloaderBox.Text = Program.AppSettings.Location_Downloader;
            YoutubedlLocBrowser.InitialDirectory = Program.AppSettings.Location_Downloader;
            FilenameTemplateBox.Text = Program.AppSettings.Location_FileNameTemplate;

            ProxyCheck.Checked = Program.AppSettings.Network_ProxyEnabled;
            ProxyBox.Text = Program.AppSettings.Network_ProxyAddress;
            TimeoutBox.Value = Program.AppSettings.Network_Timeout;
            SpeedLimitCheck.Checked = Program.AppSettings.Network_Ratelimit_Enabled;
            SpeedLimitBox.Value = Program.AppSettings.Network_RateLimit;
            LimitUnitBox.SelectedItem = Program.AppSettings.Network_RateLimitUnit;

            CredCheck.Checked = Program.AppSettings.Credentials_Enabled;
            UserBox.Text = Program.AppSettings.Credentials_Username;  //!!!!
            PassBox.Text = Program.AppSettings.Credentials_Password;  //!!!!
            TwoFactorCheck.Checked = Program.AppSettings.Credentials_TwoFactor_Enabled;
            TwoFactorBox.Text = Program.AppSettings.Credentials_TwoFactor; //!!!!
            VideoPassCheck.Checked = Program.AppSettings.Credentials_VideoPasswordEnabled;
            VideoPassBox.Text = Program.AppSettings.Credentials_VideoPassword; //!!!!

            foreach (string item in Program.AppSettings.Language_Names) { LanguageBox.Items.Add(item); }
            LanguageBox.SelectedItem = Program.AppSettings.Language_Names[Program.AppSettings.Language_Codes.IndexOf(Program.AppSettings.Language_Code)];
            VInfoThreadBox.Value = Program.AppSettings.Threads_VideoInfo;
            VFormatThreadBox.Value = Program.AppSettings.Threads_VideoFormat;
            VDownloadThreadBox.Value = Program.AppSettings.Threads_VideoDownload;
        }

        // ************* Event methods *************

        // Format tab
        private void ConvertCheck_CheckedChanged(object sender, EventArgs e) { ConvertGroup.Enabled = ConvertCheck.Checked; Program.AppSettings.Format_ConvertEnabled = ConvertCheck.Checked; }
        private void AudioCheck_CheckedChanged(object sender, EventArgs e) { if (AudioCheck.Checked) ChangeFormatList(0); Program.AppSettings.Format_ConvertAudio = AudioCheck.Checked; }
        private void VideoCheck_CheckedChanged(object sender, EventArgs e) { if (VideoCheck.Checked) ChangeFormatList(1);Program.AppSettings.Format_ConvertVideo = VideoCheck.Checked; }
        private void FormatBox_SelectionChangeCommitted(object sender, EventArgs e) { Program.AppSettings.Format_ConvertFormat = FormatBox.SelectedItem.ToString(); }
        private void QualitySlider_ValueChanged(object sender, EventArgs e) { QualityTitleV.Text = QualitySlider.Value.ToString(); Program.AppSettings.Format_Quality = Convert.ToByte(QualitySlider.Value); }
        private void KeepOrigCheck_CheckedChanged(object sender, EventArgs e) { Program.AppSettings.Format_KeepOrigin = KeepOrigCheck.Checked; }
        private void ThumbnailCheck_CheckedChanged(object sender, EventArgs e) { Program.AppSettings.Format_EmbedThumbnail = ThumbnailCheck.Checked; }

        // Output tab
        private void OutputButton_Click(object sender, EventArgs e)
        { if (OutputLocBrowser.ShowDialog() == DialogResult.OK) { OutputBox.Text = OutputLocBrowser.SelectedPath; Program.AppSettings.Location_Output = OutputLocBrowser.SelectedPath; } }
        private void FfmpegButton_Click(object sender, EventArgs e)
        { if (FFmpegLocBrowser.ShowDialog() == DialogResult.OK) { FfmpegBox.Text = FFmpegLocBrowser.SelectedPath; Program.AppSettings.Location_FFmpeg = FFmpegLocBrowser.SelectedPath;} }
        private void DownloaderButton_Click(object sender, EventArgs e)
        { { if (YoutubedlLocBrowser.ShowDialog() == DialogResult.OK) DownloaderBox.Text = YoutubedlLocBrowser.FileName; Program.AppSettings.Location_Downloader = YoutubedlLocBrowser.FileName; } }
        private void OutputBox_Leave(object sender, EventArgs e) { Program.AppSettings.Location_Output = OutputBox.Text; }
        private void FfmpegBox_Leave(object sender, EventArgs e) { Program.AppSettings.Location_FFmpeg = FfmpegBox.Text; }
        private void DownloaderBox_Leave(object sender, EventArgs e) { Program.AppSettings.Location_Downloader = DownloaderBox.Text; }
        private void FilenameTemplateBox_Leave(object sender, EventArgs e) { Program.AppSettings.Location_FileNameTemplate = FilenameTemplateBox.Text; }

        // Network tab
        private void ProxyCheck_CheckedChanged(object sender, EventArgs e) { ProxyGroup.Enabled = ProxyCheck.Checked; Program.AppSettings.Network_ProxyEnabled = ProxyCheck.Checked; }
        private void ProxyBox_Leave(object sender, EventArgs e) { Program.AppSettings.Network_ProxyAddress = ProxyBox.Text; }
        private void TimeoutBox_ValueChanged(object sender, EventArgs e) { Program.AppSettings.Network_Timeout = Convert.ToInt32(TimeoutBox.Value); }
        private void SpeedLimitCheck_CheckedChanged(object sender, EventArgs e)
        { SpeedLimitBox.Enabled = SpeedLimitCheck.Checked; LimitUnitBox.Enabled = SpeedLimitCheck.Checked; Program.AppSettings.Network_Ratelimit_Enabled = SpeedLimitCheck.Checked; }
        private void SpeedLimitBox_ValueChanged(object sender, EventArgs e) { Program.AppSettings.Network_RateLimit = Convert.ToInt32(SpeedLimitBox.Value); }
        private void LimitUnitBox_SelectionChangeCommitted(object sender, EventArgs e) { Program.AppSettings.Network_RateLimitUnit = LimitUnitBox.SelectedItem.ToString(); }

        // Login tab
        private void CredCheck_CheckedChanged(object sender, EventArgs e) { CredGroup.Enabled = CredCheck.Checked; Program.AppSettings.Credentials_Enabled = CredCheck.Checked; }
        // Warning: The storage of this field needs more security.
        private void UserBox_Leave(object sender, EventArgs e) { Program.AppSettings.Credentials_Username = UserBox.Text; }
        // Warning: The storage of this field needs more security.
        private void PassBox_Leave(object sender, EventArgs e) { Program.AppSettings.Credentials_Password = PassBox.Text; }
        private void TwoFactorCheck_CheckedChanged(object sender, EventArgs e) { TwoFactorBox.Enabled = TwoFactorCheck.Checked; Program.AppSettings.Credentials_TwoFactor_Enabled = TwoFactorCheck.Checked; }
        // Warning: The storage of this field needs more security.
        private void TwoFactorBox_Leave(object sender, EventArgs e) { Program.AppSettings.Credentials_TwoFactor = TwoFactorBox.Text; }
        private void VideoPassCheck_CheckedChanged(object sender, EventArgs e) { VideoPassBox.Enabled = VideoPassCheck.Checked; Program.AppSettings.Credentials_VideoPasswordEnabled = VideoPassCheck.Checked; }
        // Warning: The storage of this field needs more security.
        private void VideoPassBox_Leave(object sender, EventArgs e) { Program.AppSettings.Credentials_VideoPassword = VideoPassBox.Text; }

        // Other tab
        private void LanguageBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Program.AppSettings.Language_Code = Program.AppSettings.Language_Codes[LanguageBox.SelectedIndex];
            MessageBox.Show(Languages.Strings.WarnLanguageChanged, Languages.Strings.WarnGeneralTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void VInfoThreadBox_ValueChanged(object sender, EventArgs e) { Program.AppSettings.Threads_VideoInfo = Convert.ToInt32(VInfoThreadBox.Value); }
        private void VFormatThreadBox_ValueChanged(object sender, EventArgs e) { Program.AppSettings.Threads_VideoFormat = Convert.ToInt32(VFormatThreadBox.Value); }
        private void VDownloadThreadBox_ValueChanged(object sender, EventArgs e) { Program.AppSettings.Threads_VideoDownload = Convert.ToInt32(VDownloadThreadBox.Value); }
        private HttpClient hclient = new HttpClient();
        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateButton.Text = Languages.Strings.UpdateButtonTextUpdating;
            UpdateButton.Enabled = false;
            bool IsYTDLRunning;
            Process[] pr = Process.GetProcessesByName("youtube-dl");
            if (pr.Length == 0) IsYTDLRunning = false; else IsYTDLRunning = true;
            if (!IsYTDLRunning)
            {
                string p = Application.StartupPath + "\\";
                Stream stream = File.OpenWrite(p + "youtube-dl.tmp");
                bool DownloadSuccess;
                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    HttpResponseMessage r = await hclient.GetAsync(Program.AppSettings.Location_DownloaderURL); //https://yt-dl.org/latest/youtube-dl.exe
                    r.EnsureSuccessStatusCode();
                    await r.Content.CopyToAsync(stream);
                    stream.Close();
                    DownloadSuccess = true;
                }
                catch (Exception exc)
                {
                    DownloadSuccess = false;
                    stream.Close();
                    string excin = "";
                    if (exc.InnerException.Message != null) excin = exc.InnerException.Message;
                    MessageBox.Show(exc.Message + "\n" + excin, Languages.Strings.ErrGeneralTitle);
                    File.Delete("youtube-dl.tmp");
                }
                if (DownloadSuccess)
                    try
                    {
                        if (File.Exists(p + "youtube-dl.exe"))
                            File.Replace(p + "youtube-dl.tmp", p + "youtube-dl.exe", p + "youtube-dl.bak");
                        else
                            File.Move(p + "youtube-dl.tmp", p + "youtube-dl.exe");
                        MessageBox.Show(Languages.Strings.InfoUpdateSuccess, Languages.Strings.InfoGeneralTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exc)
                    { MessageBox.Show(exc.Message, Languages.Strings.ErrGeneralTitle, MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
                MessageBox.Show(Languages.Strings.ErrUpdateProgramInUse, Languages.Strings.ErrGeneralTitle);
            UpdateButton.Enabled = true;
            UpdateButton.Text = Languages.Strings.UpdateButtonTextNormal;
        }
        private void DefSettingsButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Languages.Strings.WarnRestoreSettings, Languages.Strings.WarnGeneralTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Program.AppSettings.Reset();
                Program.AppSettings.Reload();
                Program.SetDefaultDirectories();
                LoadComponents();
            }
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TempHintLabel_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://github.com/ytdl-org/youtube-dl#output-template"); } catch { }
        }
    }
}

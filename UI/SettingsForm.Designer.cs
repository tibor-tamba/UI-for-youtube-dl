namespace VideoDownloader
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.TabPages = new System.Windows.Forms.TabControl();
            this.FormatPage = new System.Windows.Forms.TabPage();
            this.ConvertCheck = new System.Windows.Forms.CheckBox();
            this.ConvertGroup = new System.Windows.Forms.GroupBox();
            this.QualityTitleV = new System.Windows.Forms.Label();
            this.ThumbnailCheck = new System.Windows.Forms.CheckBox();
            this.KeepOrigCheck = new System.Windows.Forms.CheckBox();
            this.QualitySlider = new System.Windows.Forms.TrackBar();
            this.QualityWorst = new System.Windows.Forms.Label();
            this.QualityRight = new System.Windows.Forms.Label();
            this.QualityTitle = new System.Windows.Forms.Label();
            this.FormatBox = new System.Windows.Forms.ComboBox();
            this.VideoCheck = new System.Windows.Forms.RadioButton();
            this.AudioCheck = new System.Windows.Forms.RadioButton();
            this.OutputPage = new System.Windows.Forms.TabPage();
            this.TemplateGroup = new System.Windows.Forms.GroupBox();
            this.TempHintLabel1 = new System.Windows.Forms.Label();
            this.FilenameTemplateBox = new System.Windows.Forms.TextBox();
            this.DownloaderGroup = new System.Windows.Forms.GroupBox();
            this.DownloaderBox = new System.Windows.Forms.TextBox();
            this.DownloaderButton = new System.Windows.Forms.Button();
            this.FfmpegGgroup = new System.Windows.Forms.GroupBox();
            this.FfmpegBox = new System.Windows.Forms.TextBox();
            this.FfmpegButton = new System.Windows.Forms.Button();
            this.OutputGroup = new System.Windows.Forms.GroupBox();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.OutputButton = new System.Windows.Forms.Button();
            this.NetworkPage = new System.Windows.Forms.TabPage();
            this.ProxyCheck = new System.Windows.Forms.CheckBox();
            this.LimitUnitBox = new System.Windows.Forms.ComboBox();
            this.SpeedLimitBox = new System.Windows.Forms.NumericUpDown();
            this.SpeedLimitCheck = new System.Windows.Forms.CheckBox();
            this.TimeoutBox = new System.Windows.Forms.NumericUpDown();
            this.TimeoutLabel = new System.Windows.Forms.Label();
            this.ProxyGroup = new System.Windows.Forms.GroupBox();
            this.ProxyExamples = new System.Windows.Forms.Label();
            this.ProxyBox = new System.Windows.Forms.TextBox();
            this.ProxyLabel = new System.Windows.Forms.Label();
            this.LoginPage = new System.Windows.Forms.TabPage();
            this.CredCheck = new System.Windows.Forms.CheckBox();
            this.VideoPassBox = new System.Windows.Forms.TextBox();
            this.VideoPassCheck = new System.Windows.Forms.CheckBox();
            this.CredGroup = new System.Windows.Forms.GroupBox();
            this.TwoFactorCheck = new System.Windows.Forms.CheckBox();
            this.TwoFactorBox = new System.Windows.Forms.TextBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.PassLabel = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.MiscPage = new System.Windows.Forms.TabPage();
            this.VDownloadThreadBox = new System.Windows.Forms.NumericUpDown();
            this.VDownloadThreadLabel = new System.Windows.Forms.Label();
            this.LanguageBox = new System.Windows.Forms.ComboBox();
            this.VFormatThreadBox = new System.Windows.Forms.NumericUpDown();
            this.VInfoThreadBox = new System.Windows.Forms.NumericUpDown();
            this.VFormatThreadLabel = new System.Windows.Forms.Label();
            this.VInfoThreadLabel = new System.Windows.Forms.Label();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.DefSettingsButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OutputLocBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.FFmpegLocBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.YoutubedlLocBrowser = new System.Windows.Forms.OpenFileDialog();
            this.TabPages.SuspendLayout();
            this.FormatPage.SuspendLayout();
            this.ConvertGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QualitySlider)).BeginInit();
            this.OutputPage.SuspendLayout();
            this.TemplateGroup.SuspendLayout();
            this.DownloaderGroup.SuspendLayout();
            this.FfmpegGgroup.SuspendLayout();
            this.OutputGroup.SuspendLayout();
            this.NetworkPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedLimitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutBox)).BeginInit();
            this.ProxyGroup.SuspendLayout();
            this.LoginPage.SuspendLayout();
            this.CredGroup.SuspendLayout();
            this.MiscPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VDownloadThreadBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VFormatThreadBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VInfoThreadBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPages
            // 
            this.TabPages.Controls.Add(this.FormatPage);
            this.TabPages.Controls.Add(this.OutputPage);
            this.TabPages.Controls.Add(this.NetworkPage);
            this.TabPages.Controls.Add(this.LoginPage);
            this.TabPages.Controls.Add(this.MiscPage);
            resources.ApplyResources(this.TabPages, "TabPages");
            this.TabPages.Multiline = true;
            this.TabPages.Name = "TabPages";
            this.TabPages.SelectedIndex = 0;
            // 
            // FormatPage
            // 
            this.FormatPage.Controls.Add(this.ConvertCheck);
            this.FormatPage.Controls.Add(this.ConvertGroup);
            resources.ApplyResources(this.FormatPage, "FormatPage");
            this.FormatPage.Name = "FormatPage";
            this.FormatPage.UseVisualStyleBackColor = true;
            // 
            // ConvertCheck
            // 
            resources.ApplyResources(this.ConvertCheck, "ConvertCheck");
            this.ConvertCheck.BackColor = System.Drawing.Color.White;
            this.ConvertCheck.Name = "ConvertCheck";
            this.ConvertCheck.UseVisualStyleBackColor = false;
            this.ConvertCheck.CheckedChanged += new System.EventHandler(this.ConvertCheck_CheckedChanged);
            // 
            // ConvertGroup
            // 
            this.ConvertGroup.Controls.Add(this.QualityTitleV);
            this.ConvertGroup.Controls.Add(this.ThumbnailCheck);
            this.ConvertGroup.Controls.Add(this.KeepOrigCheck);
            this.ConvertGroup.Controls.Add(this.QualitySlider);
            this.ConvertGroup.Controls.Add(this.QualityWorst);
            this.ConvertGroup.Controls.Add(this.QualityRight);
            this.ConvertGroup.Controls.Add(this.QualityTitle);
            this.ConvertGroup.Controls.Add(this.FormatBox);
            this.ConvertGroup.Controls.Add(this.VideoCheck);
            this.ConvertGroup.Controls.Add(this.AudioCheck);
            resources.ApplyResources(this.ConvertGroup, "ConvertGroup");
            this.ConvertGroup.Name = "ConvertGroup";
            this.ConvertGroup.TabStop = false;
            // 
            // QualityTitleV
            // 
            resources.ApplyResources(this.QualityTitleV, "QualityTitleV");
            this.QualityTitleV.Name = "QualityTitleV";
            // 
            // ThumbnailCheck
            // 
            resources.ApplyResources(this.ThumbnailCheck, "ThumbnailCheck");
            this.ThumbnailCheck.Name = "ThumbnailCheck";
            this.ThumbnailCheck.UseVisualStyleBackColor = true;
            this.ThumbnailCheck.CheckedChanged += new System.EventHandler(this.ThumbnailCheck_CheckedChanged);
            // 
            // KeepOrigCheck
            // 
            resources.ApplyResources(this.KeepOrigCheck, "KeepOrigCheck");
            this.KeepOrigCheck.Name = "KeepOrigCheck";
            this.KeepOrigCheck.UseVisualStyleBackColor = true;
            this.KeepOrigCheck.CheckedChanged += new System.EventHandler(this.KeepOrigCheck_CheckedChanged);
            // 
            // QualitySlider
            // 
            this.QualitySlider.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.QualitySlider, "QualitySlider");
            this.QualitySlider.Maximum = 9;
            this.QualitySlider.Name = "QualitySlider";
            this.QualitySlider.Value = 5;
            this.QualitySlider.ValueChanged += new System.EventHandler(this.QualitySlider_ValueChanged);
            // 
            // QualityWorst
            // 
            resources.ApplyResources(this.QualityWorst, "QualityWorst");
            this.QualityWorst.Name = "QualityWorst";
            // 
            // QualityRight
            // 
            resources.ApplyResources(this.QualityRight, "QualityRight");
            this.QualityRight.Name = "QualityRight";
            // 
            // QualityTitle
            // 
            resources.ApplyResources(this.QualityTitle, "QualityTitle");
            this.QualityTitle.Name = "QualityTitle";
            // 
            // FormatBox
            // 
            this.FormatBox.BackColor = System.Drawing.Color.White;
            this.FormatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatBox.FormattingEnabled = true;
            resources.ApplyResources(this.FormatBox, "FormatBox");
            this.FormatBox.Name = "FormatBox";
            this.FormatBox.SelectionChangeCommitted += new System.EventHandler(this.FormatBox_SelectionChangeCommitted);
            // 
            // VideoCheck
            // 
            resources.ApplyResources(this.VideoCheck, "VideoCheck");
            this.VideoCheck.Name = "VideoCheck";
            this.VideoCheck.TabStop = true;
            this.VideoCheck.UseVisualStyleBackColor = true;
            this.VideoCheck.CheckedChanged += new System.EventHandler(this.VideoCheck_CheckedChanged);
            // 
            // AudioCheck
            // 
            resources.ApplyResources(this.AudioCheck, "AudioCheck");
            this.AudioCheck.Name = "AudioCheck";
            this.AudioCheck.TabStop = true;
            this.AudioCheck.UseVisualStyleBackColor = true;
            this.AudioCheck.CheckedChanged += new System.EventHandler(this.AudioCheck_CheckedChanged);
            // 
            // OutputPage
            // 
            this.OutputPage.Controls.Add(this.TemplateGroup);
            this.OutputPage.Controls.Add(this.DownloaderGroup);
            this.OutputPage.Controls.Add(this.FfmpegGgroup);
            this.OutputPage.Controls.Add(this.OutputGroup);
            resources.ApplyResources(this.OutputPage, "OutputPage");
            this.OutputPage.Name = "OutputPage";
            this.OutputPage.UseVisualStyleBackColor = true;
            // 
            // TemplateGroup
            // 
            this.TemplateGroup.Controls.Add(this.TempHintLabel1);
            this.TemplateGroup.Controls.Add(this.FilenameTemplateBox);
            resources.ApplyResources(this.TemplateGroup, "TemplateGroup");
            this.TemplateGroup.Name = "TemplateGroup";
            this.TemplateGroup.TabStop = false;
            // 
            // TempHintLabel1
            // 
            resources.ApplyResources(this.TempHintLabel1, "TempHintLabel1");
            this.TempHintLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TempHintLabel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.TempHintLabel1.Name = "TempHintLabel1";
            this.TempHintLabel1.Click += new System.EventHandler(this.TempHintLabel_Click);
            // 
            // FilenameTemplateBox
            // 
            resources.ApplyResources(this.FilenameTemplateBox, "FilenameTemplateBox");
            this.FilenameTemplateBox.Name = "FilenameTemplateBox";
            this.FilenameTemplateBox.Leave += new System.EventHandler(this.FilenameTemplateBox_Leave);
            // 
            // DownloaderGroup
            // 
            this.DownloaderGroup.Controls.Add(this.DownloaderBox);
            this.DownloaderGroup.Controls.Add(this.DownloaderButton);
            resources.ApplyResources(this.DownloaderGroup, "DownloaderGroup");
            this.DownloaderGroup.Name = "DownloaderGroup";
            this.DownloaderGroup.TabStop = false;
            // 
            // DownloaderBox
            // 
            resources.ApplyResources(this.DownloaderBox, "DownloaderBox");
            this.DownloaderBox.Name = "DownloaderBox";
            this.DownloaderBox.Leave += new System.EventHandler(this.DownloaderBox_Leave);
            // 
            // DownloaderButton
            // 
            this.DownloaderButton.Image = global::VideoDownloader.Properties.Resources.open;
            resources.ApplyResources(this.DownloaderButton, "DownloaderButton");
            this.DownloaderButton.Name = "DownloaderButton";
            this.DownloaderButton.UseVisualStyleBackColor = true;
            this.DownloaderButton.Click += new System.EventHandler(this.DownloaderButton_Click);
            // 
            // FfmpegGgroup
            // 
            this.FfmpegGgroup.Controls.Add(this.FfmpegBox);
            this.FfmpegGgroup.Controls.Add(this.FfmpegButton);
            resources.ApplyResources(this.FfmpegGgroup, "FfmpegGgroup");
            this.FfmpegGgroup.Name = "FfmpegGgroup";
            this.FfmpegGgroup.TabStop = false;
            // 
            // FfmpegBox
            // 
            resources.ApplyResources(this.FfmpegBox, "FfmpegBox");
            this.FfmpegBox.Name = "FfmpegBox";
            this.FfmpegBox.Leave += new System.EventHandler(this.FfmpegBox_Leave);
            // 
            // FfmpegButton
            // 
            this.FfmpegButton.Image = global::VideoDownloader.Properties.Resources.open;
            resources.ApplyResources(this.FfmpegButton, "FfmpegButton");
            this.FfmpegButton.Name = "FfmpegButton";
            this.FfmpegButton.UseVisualStyleBackColor = true;
            this.FfmpegButton.Click += new System.EventHandler(this.FfmpegButton_Click);
            // 
            // OutputGroup
            // 
            this.OutputGroup.Controls.Add(this.OutputBox);
            this.OutputGroup.Controls.Add(this.OutputButton);
            resources.ApplyResources(this.OutputGroup, "OutputGroup");
            this.OutputGroup.Name = "OutputGroup";
            this.OutputGroup.TabStop = false;
            // 
            // OutputBox
            // 
            resources.ApplyResources(this.OutputBox, "OutputBox");
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Leave += new System.EventHandler(this.OutputBox_Leave);
            // 
            // OutputButton
            // 
            this.OutputButton.Image = global::VideoDownloader.Properties.Resources.open;
            resources.ApplyResources(this.OutputButton, "OutputButton");
            this.OutputButton.Name = "OutputButton";
            this.OutputButton.UseVisualStyleBackColor = true;
            this.OutputButton.Click += new System.EventHandler(this.OutputButton_Click);
            // 
            // NetworkPage
            // 
            this.NetworkPage.Controls.Add(this.ProxyCheck);
            this.NetworkPage.Controls.Add(this.LimitUnitBox);
            this.NetworkPage.Controls.Add(this.SpeedLimitBox);
            this.NetworkPage.Controls.Add(this.SpeedLimitCheck);
            this.NetworkPage.Controls.Add(this.TimeoutBox);
            this.NetworkPage.Controls.Add(this.TimeoutLabel);
            this.NetworkPage.Controls.Add(this.ProxyGroup);
            resources.ApplyResources(this.NetworkPage, "NetworkPage");
            this.NetworkPage.Name = "NetworkPage";
            this.NetworkPage.UseVisualStyleBackColor = true;
            // 
            // ProxyCheck
            // 
            resources.ApplyResources(this.ProxyCheck, "ProxyCheck");
            this.ProxyCheck.BackColor = System.Drawing.Color.White;
            this.ProxyCheck.Name = "ProxyCheck";
            this.ProxyCheck.UseVisualStyleBackColor = false;
            this.ProxyCheck.CheckedChanged += new System.EventHandler(this.ProxyCheck_CheckedChanged);
            // 
            // LimitUnitBox
            // 
            this.LimitUnitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.LimitUnitBox, "LimitUnitBox");
            this.LimitUnitBox.FormattingEnabled = true;
            this.LimitUnitBox.Items.AddRange(new object[] {
            resources.GetString("LimitUnitBox.Items"),
            resources.GetString("LimitUnitBox.Items1"),
            resources.GetString("LimitUnitBox.Items2")});
            this.LimitUnitBox.Name = "LimitUnitBox";
            this.LimitUnitBox.SelectionChangeCommitted += new System.EventHandler(this.LimitUnitBox_SelectionChangeCommitted);
            // 
            // SpeedLimitBox
            // 
            resources.ApplyResources(this.SpeedLimitBox, "SpeedLimitBox");
            this.SpeedLimitBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpeedLimitBox.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.SpeedLimitBox.Name = "SpeedLimitBox";
            this.SpeedLimitBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpeedLimitBox.ValueChanged += new System.EventHandler(this.SpeedLimitBox_ValueChanged);
            // 
            // SpeedLimitCheck
            // 
            resources.ApplyResources(this.SpeedLimitCheck, "SpeedLimitCheck");
            this.SpeedLimitCheck.Name = "SpeedLimitCheck";
            this.SpeedLimitCheck.UseVisualStyleBackColor = true;
            this.SpeedLimitCheck.CheckedChanged += new System.EventHandler(this.SpeedLimitCheck_CheckedChanged);
            // 
            // TimeoutBox
            // 
            this.TimeoutBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this.TimeoutBox, "TimeoutBox");
            this.TimeoutBox.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.TimeoutBox.Name = "TimeoutBox";
            this.TimeoutBox.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.TimeoutBox.ValueChanged += new System.EventHandler(this.TimeoutBox_ValueChanged);
            // 
            // TimeoutLabel
            // 
            resources.ApplyResources(this.TimeoutLabel, "TimeoutLabel");
            this.TimeoutLabel.Name = "TimeoutLabel";
            // 
            // ProxyGroup
            // 
            this.ProxyGroup.Controls.Add(this.ProxyExamples);
            this.ProxyGroup.Controls.Add(this.ProxyBox);
            this.ProxyGroup.Controls.Add(this.ProxyLabel);
            resources.ApplyResources(this.ProxyGroup, "ProxyGroup");
            this.ProxyGroup.Name = "ProxyGroup";
            this.ProxyGroup.TabStop = false;
            // 
            // ProxyExamples
            // 
            resources.ApplyResources(this.ProxyExamples, "ProxyExamples");
            this.ProxyExamples.Name = "ProxyExamples";
            // 
            // ProxyBox
            // 
            resources.ApplyResources(this.ProxyBox, "ProxyBox");
            this.ProxyBox.Name = "ProxyBox";
            this.ProxyBox.Leave += new System.EventHandler(this.ProxyBox_Leave);
            // 
            // ProxyLabel
            // 
            resources.ApplyResources(this.ProxyLabel, "ProxyLabel");
            this.ProxyLabel.Name = "ProxyLabel";
            // 
            // LoginPage
            // 
            this.LoginPage.Controls.Add(this.CredCheck);
            this.LoginPage.Controls.Add(this.VideoPassBox);
            this.LoginPage.Controls.Add(this.VideoPassCheck);
            this.LoginPage.Controls.Add(this.CredGroup);
            resources.ApplyResources(this.LoginPage, "LoginPage");
            this.LoginPage.Name = "LoginPage";
            this.LoginPage.UseVisualStyleBackColor = true;
            // 
            // CredCheck
            // 
            resources.ApplyResources(this.CredCheck, "CredCheck");
            this.CredCheck.BackColor = System.Drawing.Color.White;
            this.CredCheck.Name = "CredCheck";
            this.CredCheck.UseVisualStyleBackColor = false;
            this.CredCheck.CheckedChanged += new System.EventHandler(this.CredCheck_CheckedChanged);
            // 
            // VideoPassBox
            // 
            resources.ApplyResources(this.VideoPassBox, "VideoPassBox");
            this.VideoPassBox.Name = "VideoPassBox";
            this.VideoPassBox.Leave += new System.EventHandler(this.VideoPassBox_Leave);
            // 
            // VideoPassCheck
            // 
            resources.ApplyResources(this.VideoPassCheck, "VideoPassCheck");
            this.VideoPassCheck.Name = "VideoPassCheck";
            this.VideoPassCheck.UseVisualStyleBackColor = true;
            this.VideoPassCheck.CheckedChanged += new System.EventHandler(this.VideoPassCheck_CheckedChanged);
            // 
            // CredGroup
            // 
            this.CredGroup.Controls.Add(this.TwoFactorCheck);
            this.CredGroup.Controls.Add(this.TwoFactorBox);
            this.CredGroup.Controls.Add(this.PassBox);
            this.CredGroup.Controls.Add(this.UserBox);
            this.CredGroup.Controls.Add(this.PassLabel);
            this.CredGroup.Controls.Add(this.UserLabel);
            resources.ApplyResources(this.CredGroup, "CredGroup");
            this.CredGroup.Name = "CredGroup";
            this.CredGroup.TabStop = false;
            // 
            // TwoFactorCheck
            // 
            resources.ApplyResources(this.TwoFactorCheck, "TwoFactorCheck");
            this.TwoFactorCheck.Name = "TwoFactorCheck";
            this.TwoFactorCheck.UseVisualStyleBackColor = true;
            this.TwoFactorCheck.CheckedChanged += new System.EventHandler(this.TwoFactorCheck_CheckedChanged);
            // 
            // TwoFactorBox
            // 
            resources.ApplyResources(this.TwoFactorBox, "TwoFactorBox");
            this.TwoFactorBox.Name = "TwoFactorBox";
            this.TwoFactorBox.Leave += new System.EventHandler(this.TwoFactorBox_Leave);
            // 
            // PassBox
            // 
            resources.ApplyResources(this.PassBox, "PassBox");
            this.PassBox.Name = "PassBox";
            this.PassBox.Leave += new System.EventHandler(this.PassBox_Leave);
            // 
            // UserBox
            // 
            resources.ApplyResources(this.UserBox, "UserBox");
            this.UserBox.Name = "UserBox";
            this.UserBox.Leave += new System.EventHandler(this.UserBox_Leave);
            // 
            // PassLabel
            // 
            resources.ApplyResources(this.PassLabel, "PassLabel");
            this.PassLabel.Name = "PassLabel";
            // 
            // UserLabel
            // 
            resources.ApplyResources(this.UserLabel, "UserLabel");
            this.UserLabel.Name = "UserLabel";
            // 
            // MiscPage
            // 
            this.MiscPage.Controls.Add(this.VDownloadThreadBox);
            this.MiscPage.Controls.Add(this.VDownloadThreadLabel);
            this.MiscPage.Controls.Add(this.LanguageBox);
            this.MiscPage.Controls.Add(this.VFormatThreadBox);
            this.MiscPage.Controls.Add(this.VInfoThreadBox);
            this.MiscPage.Controls.Add(this.VFormatThreadLabel);
            this.MiscPage.Controls.Add(this.VInfoThreadLabel);
            this.MiscPage.Controls.Add(this.LanguageLabel);
            this.MiscPage.Controls.Add(this.DefSettingsButton);
            this.MiscPage.Controls.Add(this.UpdateButton);
            resources.ApplyResources(this.MiscPage, "MiscPage");
            this.MiscPage.Name = "MiscPage";
            this.MiscPage.UseVisualStyleBackColor = true;
            // 
            // VDownloadThreadBox
            // 
            resources.ApplyResources(this.VDownloadThreadBox, "VDownloadThreadBox");
            this.VDownloadThreadBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.VDownloadThreadBox.Name = "VDownloadThreadBox";
            this.VDownloadThreadBox.ValueChanged += new System.EventHandler(this.VDownloadThreadBox_ValueChanged);
            // 
            // VDownloadThreadLabel
            // 
            resources.ApplyResources(this.VDownloadThreadLabel, "VDownloadThreadLabel");
            this.VDownloadThreadLabel.Name = "VDownloadThreadLabel";
            // 
            // LanguageBox
            // 
            this.LanguageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageBox.FormattingEnabled = true;
            resources.ApplyResources(this.LanguageBox, "LanguageBox");
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.SelectionChangeCommitted += new System.EventHandler(this.LanguageBox_SelectionChangeCommitted);
            // 
            // VFormatThreadBox
            // 
            resources.ApplyResources(this.VFormatThreadBox, "VFormatThreadBox");
            this.VFormatThreadBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.VFormatThreadBox.Name = "VFormatThreadBox";
            this.VFormatThreadBox.ValueChanged += new System.EventHandler(this.VFormatThreadBox_ValueChanged);
            // 
            // VInfoThreadBox
            // 
            resources.ApplyResources(this.VInfoThreadBox, "VInfoThreadBox");
            this.VInfoThreadBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.VInfoThreadBox.Name = "VInfoThreadBox";
            this.VInfoThreadBox.ValueChanged += new System.EventHandler(this.VInfoThreadBox_ValueChanged);
            // 
            // VFormatThreadLabel
            // 
            resources.ApplyResources(this.VFormatThreadLabel, "VFormatThreadLabel");
            this.VFormatThreadLabel.Name = "VFormatThreadLabel";
            // 
            // VInfoThreadLabel
            // 
            resources.ApplyResources(this.VInfoThreadLabel, "VInfoThreadLabel");
            this.VInfoThreadLabel.Name = "VInfoThreadLabel";
            // 
            // LanguageLabel
            // 
            resources.ApplyResources(this.LanguageLabel, "LanguageLabel");
            this.LanguageLabel.Name = "LanguageLabel";
            // 
            // DefSettingsButton
            // 
            resources.ApplyResources(this.DefSettingsButton, "DefSettingsButton");
            this.DefSettingsButton.Name = "DefSettingsButton";
            this.DefSettingsButton.UseVisualStyleBackColor = true;
            this.DefSettingsButton.Click += new System.EventHandler(this.DefSettingsButton_Click);
            // 
            // UpdateButton
            // 
            resources.ApplyResources(this.UpdateButton, "UpdateButton");
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // YoutubedlLocBrowser
            // 
            this.YoutubedlLocBrowser.FileName = "youtube-dl.exe";
            resources.ApplyResources(this.YoutubedlLocBrowser, "YoutubedlLocBrowser");
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.CloseButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.TabPages);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.TopMost = true;
            this.TabPages.ResumeLayout(false);
            this.FormatPage.ResumeLayout(false);
            this.FormatPage.PerformLayout();
            this.ConvertGroup.ResumeLayout(false);
            this.ConvertGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QualitySlider)).EndInit();
            this.OutputPage.ResumeLayout(false);
            this.TemplateGroup.ResumeLayout(false);
            this.TemplateGroup.PerformLayout();
            this.DownloaderGroup.ResumeLayout(false);
            this.DownloaderGroup.PerformLayout();
            this.FfmpegGgroup.ResumeLayout(false);
            this.FfmpegGgroup.PerformLayout();
            this.OutputGroup.ResumeLayout(false);
            this.OutputGroup.PerformLayout();
            this.NetworkPage.ResumeLayout(false);
            this.NetworkPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedLimitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutBox)).EndInit();
            this.ProxyGroup.ResumeLayout(false);
            this.ProxyGroup.PerformLayout();
            this.LoginPage.ResumeLayout(false);
            this.LoginPage.PerformLayout();
            this.CredGroup.ResumeLayout(false);
            this.CredGroup.PerformLayout();
            this.MiscPage.ResumeLayout(false);
            this.MiscPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VDownloadThreadBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VFormatThreadBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VInfoThreadBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabPages;
        private System.Windows.Forms.TabPage FormatPage;
        private System.Windows.Forms.TabPage OutputPage;
        private System.Windows.Forms.TabPage NetworkPage;
        private System.Windows.Forms.TabPage LoginPage;
        private System.Windows.Forms.TabPage MiscPage;
        private System.Windows.Forms.GroupBox ConvertGroup;
        private System.Windows.Forms.CheckBox ThumbnailCheck;
        private System.Windows.Forms.CheckBox KeepOrigCheck;
        private System.Windows.Forms.TrackBar QualitySlider;
        private System.Windows.Forms.Label QualityWorst;
        private System.Windows.Forms.Label QualityRight;
        private System.Windows.Forms.Label QualityTitle;
        private System.Windows.Forms.ComboBox FormatBox;
        private System.Windows.Forms.RadioButton VideoCheck;
        private System.Windows.Forms.RadioButton AudioCheck;
        private System.Windows.Forms.CheckBox ConvertCheck;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox FfmpegGgroup;
        private System.Windows.Forms.GroupBox OutputGroup;
        private System.Windows.Forms.GroupBox TemplateGroup;
        private System.Windows.Forms.GroupBox DownloaderGroup;
        private System.Windows.Forms.TextBox FilenameTemplateBox;
        private System.Windows.Forms.TextBox DownloaderBox;
        private System.Windows.Forms.Button DownloaderButton;
        private System.Windows.Forms.TextBox FfmpegBox;
        private System.Windows.Forms.Button FfmpegButton;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.Button OutputButton;
        private System.Windows.Forms.ComboBox LimitUnitBox;
        private System.Windows.Forms.NumericUpDown SpeedLimitBox;
        private System.Windows.Forms.CheckBox SpeedLimitCheck;
        private System.Windows.Forms.NumericUpDown TimeoutBox;
        private System.Windows.Forms.Label TimeoutLabel;
        private System.Windows.Forms.GroupBox ProxyGroup;
        private System.Windows.Forms.Label ProxyExamples;
        private System.Windows.Forms.TextBox ProxyBox;
        private System.Windows.Forms.Label ProxyLabel;
        private System.Windows.Forms.CheckBox ProxyCheck;
        private System.Windows.Forms.TextBox VideoPassBox;
        private System.Windows.Forms.CheckBox VideoPassCheck;
        private System.Windows.Forms.GroupBox CredGroup;
        private System.Windows.Forms.CheckBox TwoFactorCheck;
        private System.Windows.Forms.TextBox TwoFactorBox;
        private System.Windows.Forms.TextBox UserBox;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.CheckBox CredCheck;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.NumericUpDown VDownloadThreadBox;
        private System.Windows.Forms.Label VDownloadThreadLabel;
        private System.Windows.Forms.ComboBox LanguageBox;
        private System.Windows.Forms.NumericUpDown VFormatThreadBox;
        private System.Windows.Forms.NumericUpDown VInfoThreadBox;
        private System.Windows.Forms.Label VFormatThreadLabel;
        private System.Windows.Forms.Label VInfoThreadLabel;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.Button DefSettingsButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.FolderBrowserDialog OutputLocBrowser;
        private System.Windows.Forms.FolderBrowserDialog FFmpegLocBrowser;
        private System.Windows.Forms.OpenFileDialog YoutubedlLocBrowser;
        private System.Windows.Forms.Label QualityTitleV;
        private System.Windows.Forms.Label TempHintLabel1;
    }
}
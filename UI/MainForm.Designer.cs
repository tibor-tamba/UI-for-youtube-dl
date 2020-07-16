namespace VideoDownloader
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainToolBar = new System.Windows.Forms.ToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.AddClipButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CheckAllButton = new System.Windows.Forms.ToolStripButton();
            this.CheckNoneButton = new System.Windows.Forms.ToolStripButton();
            this.InvCheckButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DelButton = new System.Windows.Forms.ToolStripButton();
            this.DelAllButton = new System.Windows.Forms.ToolStripButton();
            this.DownloadButton = new System.Windows.Forms.ToolStripButton();
            this.StopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenFolderButton = new System.Windows.Forms.ToolStripButton();
            this.PlayButton = new System.Windows.Forms.ToolStripButton();
            this.SettingsButton = new System.Windows.Forms.ToolStripButton();
            this.ConvertButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.FormatButton = new System.Windows.Forms.ToolStripButton();
            this.AboutButton = new System.Windows.Forms.ToolStripButton();
            this.MainListView = new System.Windows.Forms.ListView();
            this.TitleHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UrlHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FormatHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LengthHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PreviewImages = new System.Windows.Forms.ImageList(this.components);
            this.CheckImages = new System.Windows.Forms.ImageList(this.components);
            this.AddPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Add_UrlBox = new System.Windows.Forms.RichTextBox();
            this.Add_UrlCloseButton = new System.Windows.Forms.Button();
            this.Add_UrlButton = new System.Windows.Forms.Button();
            this.Add_UrlPasteButton = new System.Windows.Forms.Button();
            this.Add_UrlLabel = new System.Windows.Forms.Label();
            this.AddingVideoPanel = new System.Windows.Forms.Panel();
            this.AddingVideoLabel = new System.Windows.Forms.Label();
            this.Spinner1 = new System.Windows.Forms.PictureBox();
            this.FormatSelectPanel = new System.Windows.Forms.Panel();
            this.FormatListErrorLabel = new System.Windows.Forms.Label();
            this.FormatLoadingPicture = new System.Windows.Forms.PictureBox();
            this.FormatListView = new System.Windows.Forms.ListView();
            this.Fmt_Code_Col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fmt_Ext_Col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fmt_Res_Col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fmt_Note_Col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FormatListLabel = new System.Windows.Forms.Label();
            this.AboutPanel = new System.Windows.Forms.Panel();
            this.AboutPanel_Website2 = new System.Windows.Forms.Label();
            this.AboutPanel_Website1 = new System.Windows.Forms.Label();
            this.AboutClose = new System.Windows.Forms.Button();
            this.AboutPanel_Text2 = new System.Windows.Forms.Label();
            this.AboutPicture = new System.Windows.Forms.PictureBox();
            this.AboutPanel_Text = new System.Windows.Forms.Label();
            this.AboutPanel_Title = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelOverall = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MainToolBar.SuspendLayout();
            this.AddPanel.SuspendLayout();
            this.AddingVideoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spinner1)).BeginInit();
            this.FormatSelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormatLoadingPicture)).BeginInit();
            this.AboutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutPicture)).BeginInit();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainToolBar
            // 
            this.MainToolBar.BackColor = System.Drawing.Color.White;
            this.MainToolBar.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.MainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddButton,
            this.AddClipButton,
            this.toolStripSeparator1,
            this.CheckAllButton,
            this.CheckNoneButton,
            this.InvCheckButton,
            this.toolStripSeparator2,
            this.DelButton,
            this.DelAllButton,
            this.DownloadButton,
            this.StopButton,
            this.toolStripSeparator3,
            this.OpenFolderButton,
            this.PlayButton,
            this.SettingsButton,
            this.ConvertButton,
            this.toolStripSeparator4,
            this.FormatButton,
            this.AboutButton});
            resources.ApplyResources(this.MainToolBar, "MainToolBar");
            this.MainToolBar.Name = "MainToolBar";
            this.MainToolBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WindowKeyDown);
            // 
            // AddButton
            // 
            this.AddButton.CheckOnClick = true;
            this.AddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddButton.Image = global::VideoDownloader.Properties.Resources.Color_Add50;
            resources.ApplyResources(this.AddButton, "AddButton");
            this.AddButton.Name = "AddButton";
            this.AddButton.CheckStateChanged += new System.EventHandler(this.AddButton_CheckStateChanged);
            // 
            // AddClipButton
            // 
            this.AddClipButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddClipButton.Image = global::VideoDownloader.Properties.Resources.Color_Paste50;
            resources.ApplyResources(this.AddClipButton, "AddClipButton");
            this.AddClipButton.Name = "AddClipButton";
            this.AddClipButton.Click += new System.EventHandler(this.AddClipButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // CheckAllButton
            // 
            this.CheckAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CheckAllButton.Image = global::VideoDownloader.Properties.Resources.Color_Selectall50;
            resources.ApplyResources(this.CheckAllButton, "CheckAllButton");
            this.CheckAllButton.Name = "CheckAllButton";
            this.CheckAllButton.Click += new System.EventHandler(this.ItemSelection);
            // 
            // CheckNoneButton
            // 
            this.CheckNoneButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CheckNoneButton.Image = global::VideoDownloader.Properties.Resources.Color_Unselectall50;
            resources.ApplyResources(this.CheckNoneButton, "CheckNoneButton");
            this.CheckNoneButton.Name = "CheckNoneButton";
            this.CheckNoneButton.Click += new System.EventHandler(this.ItemSelection);
            // 
            // InvCheckButton
            // 
            this.InvCheckButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InvCheckButton.Image = global::VideoDownloader.Properties.Resources.Color_Invertselect50;
            resources.ApplyResources(this.InvCheckButton, "InvCheckButton");
            this.InvCheckButton.Name = "InvCheckButton";
            this.InvCheckButton.Click += new System.EventHandler(this.ItemSelection);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // DelButton
            // 
            this.DelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelButton.Image = global::VideoDownloader.Properties.Resources.Color_Delete50;
            resources.ApplyResources(this.DelButton, "DelButton");
            this.DelButton.Name = "DelButton";
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // DelAllButton
            // 
            this.DelAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelAllButton.Image = global::VideoDownloader.Properties.Resources.Color_Clearlist50;
            resources.ApplyResources(this.DelAllButton, "DelAllButton");
            this.DelAllButton.Name = "DelAllButton";
            this.DelAllButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DownloadButton.Image = global::VideoDownloader.Properties.Resources.Color_Download50;
            resources.ApplyResources(this.DownloadButton, "DownloadButton");
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StopButton.Image = global::VideoDownloader.Properties.Resources.Color_Stop50;
            resources.ApplyResources(this.StopButton, "StopButton");
            this.StopButton.Name = "StopButton";
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenFolderButton.Image = global::VideoDownloader.Properties.Resources.Color_Browse50;
            resources.ApplyResources(this.OpenFolderButton, "OpenFolderButton");
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PlayButton.Image = global::VideoDownloader.Properties.Resources.Color_play50;
            resources.ApplyResources(this.PlayButton, "PlayButton");
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsButton.Image = global::VideoDownloader.Properties.Resources.Color_Settings50;
            resources.ApplyResources(this.SettingsButton, "SettingsButton");
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ConvertButton
            // 
            this.ConvertButton.CheckOnClick = true;
            this.ConvertButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ConvertButton.Image = global::VideoDownloader.Properties.Resources.Color_Convertoff50;
            resources.ApplyResources(this.ConvertButton, "ConvertButton");
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.CheckedChanged += new System.EventHandler(this.ConvertButton_CheckedChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // FormatButton
            // 
            this.FormatButton.CheckOnClick = true;
            this.FormatButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.FormatButton, "FormatButton");
            this.FormatButton.Image = global::VideoDownloader.Properties.Resources.Color_Format50;
            this.FormatButton.Name = "FormatButton";
            this.FormatButton.CheckStateChanged += new System.EventHandler(this.FormatButton_CheckStateChanged);
            // 
            // AboutButton
            // 
            this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutButton.Image = global::VideoDownloader.Properties.Resources.Color_About50;
            resources.ApplyResources(this.AboutButton, "AboutButton");
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // MainListView
            // 
            this.MainListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainListView.CheckBoxes = true;
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TitleHeader,
            this.UrlHeader,
            this.FormatHeader,
            this.LengthHeader,
            this.SizeHeader,
            this.StatusHeader,
            this.PathHeader});
            resources.ApplyResources(this.MainListView, "MainListView");
            this.MainListView.FullRowSelect = true;
            this.MainListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MainListView.HideSelection = false;
            this.MainListView.MultiSelect = false;
            this.MainListView.Name = "MainListView";
            this.MainListView.SmallImageList = this.PreviewImages;
            this.MainListView.StateImageList = this.CheckImages;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.MainListView_ItemChecked);
            this.MainListView.SelectedIndexChanged += new System.EventHandler(this.MainListView_SelectedIndexChanged);
            this.MainListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WindowKeyDown);
            // 
            // TitleHeader
            // 
            resources.ApplyResources(this.TitleHeader, "TitleHeader");
            // 
            // UrlHeader
            // 
            resources.ApplyResources(this.UrlHeader, "UrlHeader");
            // 
            // FormatHeader
            // 
            resources.ApplyResources(this.FormatHeader, "FormatHeader");
            // 
            // LengthHeader
            // 
            resources.ApplyResources(this.LengthHeader, "LengthHeader");
            // 
            // SizeHeader
            // 
            resources.ApplyResources(this.SizeHeader, "SizeHeader");
            // 
            // StatusHeader
            // 
            resources.ApplyResources(this.StatusHeader, "StatusHeader");
            // 
            // PathHeader
            // 
            resources.ApplyResources(this.PathHeader, "PathHeader");
            // 
            // PreviewImages
            // 
            this.PreviewImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.PreviewImages, "PreviewImages");
            this.PreviewImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CheckImages
            // 
            this.CheckImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.CheckImages, "CheckImages");
            this.CheckImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // AddPanel
            // 
            this.AddPanel.BackColor = System.Drawing.Color.White;
            this.AddPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddPanel.Controls.Add(this.label1);
            this.AddPanel.Controls.Add(this.Add_UrlBox);
            this.AddPanel.Controls.Add(this.Add_UrlCloseButton);
            this.AddPanel.Controls.Add(this.Add_UrlButton);
            this.AddPanel.Controls.Add(this.Add_UrlPasteButton);
            this.AddPanel.Controls.Add(this.Add_UrlLabel);
            resources.ApplyResources(this.AddPanel, "AddPanel");
            this.AddPanel.Name = "AddPanel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Add_UrlBox
            // 
            this.Add_UrlBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Add_UrlBox.DetectUrls = false;
            resources.ApplyResources(this.Add_UrlBox, "Add_UrlBox");
            this.Add_UrlBox.Name = "Add_UrlBox";
            // 
            // Add_UrlCloseButton
            // 
            resources.ApplyResources(this.Add_UrlCloseButton, "Add_UrlCloseButton");
            this.Add_UrlCloseButton.Image = global::VideoDownloader.Properties.Resources.Color_Delete50;
            this.Add_UrlCloseButton.Name = "Add_UrlCloseButton";
            this.Add_UrlCloseButton.UseVisualStyleBackColor = true;
            this.Add_UrlCloseButton.Click += new System.EventHandler(this.Add_UrlCloseButton_Click);
            // 
            // Add_UrlButton
            // 
            resources.ApplyResources(this.Add_UrlButton, "Add_UrlButton");
            this.Add_UrlButton.Name = "Add_UrlButton";
            this.Add_UrlButton.UseVisualStyleBackColor = true;
            this.Add_UrlButton.Click += new System.EventHandler(this.Add_UrlButton_Click);
            // 
            // Add_UrlPasteButton
            // 
            resources.ApplyResources(this.Add_UrlPasteButton, "Add_UrlPasteButton");
            this.Add_UrlPasteButton.Image = global::VideoDownloader.Properties.Resources.paste;
            this.Add_UrlPasteButton.Name = "Add_UrlPasteButton";
            this.Add_UrlPasteButton.UseVisualStyleBackColor = true;
            this.Add_UrlPasteButton.Click += new System.EventHandler(this.Add_UrlPasteButton_Click);
            // 
            // Add_UrlLabel
            // 
            resources.ApplyResources(this.Add_UrlLabel, "Add_UrlLabel");
            this.Add_UrlLabel.Name = "Add_UrlLabel";
            // 
            // AddingVideoPanel
            // 
            this.AddingVideoPanel.BackColor = System.Drawing.Color.White;
            this.AddingVideoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddingVideoPanel.Controls.Add(this.AddingVideoLabel);
            this.AddingVideoPanel.Controls.Add(this.Spinner1);
            resources.ApplyResources(this.AddingVideoPanel, "AddingVideoPanel");
            this.AddingVideoPanel.Name = "AddingVideoPanel";
            // 
            // AddingVideoLabel
            // 
            resources.ApplyResources(this.AddingVideoLabel, "AddingVideoLabel");
            this.AddingVideoLabel.Name = "AddingVideoLabel";
            // 
            // Spinner1
            // 
            this.Spinner1.Image = global::VideoDownloader.Properties.Resources.BlueSpinner200x200;
            resources.ApplyResources(this.Spinner1, "Spinner1");
            this.Spinner1.Name = "Spinner1";
            this.Spinner1.TabStop = false;
            // 
            // FormatSelectPanel
            // 
            this.FormatSelectPanel.BackColor = System.Drawing.Color.White;
            this.FormatSelectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormatSelectPanel.Controls.Add(this.FormatListErrorLabel);
            this.FormatSelectPanel.Controls.Add(this.FormatLoadingPicture);
            this.FormatSelectPanel.Controls.Add(this.FormatListView);
            this.FormatSelectPanel.Controls.Add(this.FormatListLabel);
            resources.ApplyResources(this.FormatSelectPanel, "FormatSelectPanel");
            this.FormatSelectPanel.Name = "FormatSelectPanel";
            // 
            // FormatListErrorLabel
            // 
            resources.ApplyResources(this.FormatListErrorLabel, "FormatListErrorLabel");
            this.FormatListErrorLabel.Name = "FormatListErrorLabel";
            // 
            // FormatLoadingPicture
            // 
            this.FormatLoadingPicture.Image = global::VideoDownloader.Properties.Resources.BlueSpinner200x200;
            resources.ApplyResources(this.FormatLoadingPicture, "FormatLoadingPicture");
            this.FormatLoadingPicture.Name = "FormatLoadingPicture";
            this.FormatLoadingPicture.TabStop = false;
            // 
            // FormatListView
            // 
            this.FormatListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FormatListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Fmt_Code_Col,
            this.Fmt_Ext_Col,
            this.Fmt_Res_Col,
            this.Fmt_Note_Col});
            resources.ApplyResources(this.FormatListView, "FormatListView");
            this.FormatListView.FullRowSelect = true;
            this.FormatListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.FormatListView.HideSelection = false;
            this.FormatListView.MultiSelect = false;
            this.FormatListView.Name = "FormatListView";
            this.FormatListView.UseCompatibleStateImageBehavior = false;
            this.FormatListView.View = System.Windows.Forms.View.Details;
            this.FormatListView.SelectedIndexChanged += new System.EventHandler(this.FormatListView_SelectedIndexChanged);
            // 
            // Fmt_Code_Col
            // 
            resources.ApplyResources(this.Fmt_Code_Col, "Fmt_Code_Col");
            // 
            // Fmt_Ext_Col
            // 
            resources.ApplyResources(this.Fmt_Ext_Col, "Fmt_Ext_Col");
            // 
            // Fmt_Res_Col
            // 
            resources.ApplyResources(this.Fmt_Res_Col, "Fmt_Res_Col");
            // 
            // Fmt_Note_Col
            // 
            resources.ApplyResources(this.Fmt_Note_Col, "Fmt_Note_Col");
            // 
            // FormatListLabel
            // 
            resources.ApplyResources(this.FormatListLabel, "FormatListLabel");
            this.FormatListLabel.Name = "FormatListLabel";
            // 
            // AboutPanel
            // 
            this.AboutPanel.BackColor = System.Drawing.Color.White;
            this.AboutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AboutPanel.Controls.Add(this.AboutPanel_Website2);
            this.AboutPanel.Controls.Add(this.AboutPanel_Website1);
            this.AboutPanel.Controls.Add(this.AboutClose);
            this.AboutPanel.Controls.Add(this.AboutPanel_Text2);
            this.AboutPanel.Controls.Add(this.AboutPicture);
            this.AboutPanel.Controls.Add(this.AboutPanel_Text);
            this.AboutPanel.Controls.Add(this.AboutPanel_Title);
            resources.ApplyResources(this.AboutPanel, "AboutPanel");
            this.AboutPanel.Name = "AboutPanel";
            // 
            // AboutPanel_Website2
            // 
            resources.ApplyResources(this.AboutPanel_Website2, "AboutPanel_Website2");
            this.AboutPanel_Website2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AboutPanel_Website2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.AboutPanel_Website2.Name = "AboutPanel_Website2";
            this.AboutPanel_Website2.Click += new System.EventHandler(this.Websites_Click);
            // 
            // AboutPanel_Website1
            // 
            resources.ApplyResources(this.AboutPanel_Website1, "AboutPanel_Website1");
            this.AboutPanel_Website1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AboutPanel_Website1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.AboutPanel_Website1.Name = "AboutPanel_Website1";
            this.AboutPanel_Website1.Click += new System.EventHandler(this.Websites_Click);
            // 
            // AboutClose
            // 
            resources.ApplyResources(this.AboutClose, "AboutClose");
            this.AboutClose.Name = "AboutClose";
            this.AboutClose.UseVisualStyleBackColor = true;
            this.AboutClose.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // AboutPanel_Text2
            // 
            resources.ApplyResources(this.AboutPanel_Text2, "AboutPanel_Text2");
            this.AboutPanel_Text2.Name = "AboutPanel_Text2";
            // 
            // AboutPicture
            // 
            this.AboutPicture.Image = global::VideoDownloader.Properties.Resources.Appicon100x100;
            resources.ApplyResources(this.AboutPicture, "AboutPicture");
            this.AboutPicture.Name = "AboutPicture";
            this.AboutPicture.TabStop = false;
            // 
            // AboutPanel_Text
            // 
            resources.ApplyResources(this.AboutPanel_Text, "AboutPanel_Text");
            this.AboutPanel_Text.Name = "AboutPanel_Text";
            // 
            // AboutPanel_Title
            // 
            resources.ApplyResources(this.AboutPanel_Title, "AboutPanel_Title");
            this.AboutPanel_Title.Name = "AboutPanel_Title";
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StatusLabel,
            this.toolStripStatusLabel2,
            this.StatusLabelOverall,
            this.StatusProgressBar});
            this.StatusBar.Name = "StatusBar";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // StatusLabel
            // 
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.Name = "StatusLabel";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // StatusLabelOverall
            // 
            resources.ApplyResources(this.StatusLabelOverall, "StatusLabelOverall");
            this.StatusLabelOverall.Name = "StatusLabelOverall";
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Name = "StatusProgressBar";
            resources.ApplyResources(this.StatusProgressBar, "StatusProgressBar");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.AddPanel);
            this.Controls.Add(this.AddingVideoPanel);
            this.Controls.Add(this.AboutPanel);
            this.Controls.Add(this.FormatSelectPanel);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.MainToolBar);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WindowKeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MainToolBar.ResumeLayout(false);
            this.MainToolBar.PerformLayout();
            this.AddPanel.ResumeLayout(false);
            this.AddPanel.PerformLayout();
            this.AddingVideoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Spinner1)).EndInit();
            this.FormatSelectPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormatLoadingPicture)).EndInit();
            this.AboutPanel.ResumeLayout(false);
            this.AboutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutPicture)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MainToolBar;
        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ToolStripButton AddButton;
        private System.Windows.Forms.ToolStripButton AddClipButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CheckAllButton;
        private System.Windows.Forms.ToolStripButton CheckNoneButton;
        private System.Windows.Forms.ToolStripButton InvCheckButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton DelButton;
        private System.Windows.Forms.ToolStripButton DelAllButton;
        private System.Windows.Forms.ToolStripButton DownloadButton;
        private System.Windows.Forms.ToolStripButton StopButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton OpenFolderButton;
        private System.Windows.Forms.ToolStripButton PlayButton;
        private System.Windows.Forms.ToolStripButton ConvertButton;
        private System.Windows.Forms.ToolStripButton SettingsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton FormatButton;
        private System.Windows.Forms.ToolStripButton AboutButton;
        private System.Windows.Forms.ColumnHeader TitleHeader;
        private System.Windows.Forms.ColumnHeader UrlHeader;
        private System.Windows.Forms.ColumnHeader FormatHeader;
        private System.Windows.Forms.ColumnHeader LengthHeader;
        private System.Windows.Forms.ColumnHeader SizeHeader;
        private System.Windows.Forms.ColumnHeader StatusHeader;
        private System.Windows.Forms.ColumnHeader PathHeader;
        private System.Windows.Forms.ImageList PreviewImages;
        private System.Windows.Forms.Panel AddPanel;
        private System.Windows.Forms.Button Add_UrlCloseButton;
        private System.Windows.Forms.Button Add_UrlButton;
        private System.Windows.Forms.Button Add_UrlPasteButton;
        private System.Windows.Forms.Label Add_UrlLabel;
        private System.Windows.Forms.Panel AddingVideoPanel;
        private System.Windows.Forms.PictureBox Spinner1;
        private System.Windows.Forms.Label AddingVideoLabel;
        private System.Windows.Forms.Panel FormatSelectPanel;
        private System.Windows.Forms.Label FormatListLabel;
        private System.Windows.Forms.ImageList CheckImages;
        private System.Windows.Forms.ListView FormatListView;
        private System.Windows.Forms.ColumnHeader Fmt_Code_Col;
        private System.Windows.Forms.ColumnHeader Fmt_Ext_Col;
        private System.Windows.Forms.ColumnHeader Fmt_Res_Col;
        private System.Windows.Forms.ColumnHeader Fmt_Note_Col;
        private System.Windows.Forms.RichTextBox Add_UrlBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel AboutPanel;
        private System.Windows.Forms.PictureBox AboutPicture;
        private System.Windows.Forms.Label AboutPanel_Text;
        private System.Windows.Forms.Label AboutPanel_Title;
        private System.Windows.Forms.Button AboutClose;
        private System.Windows.Forms.Label AboutPanel_Text2;
        private System.Windows.Forms.Label AboutPanel_Website2;
        private System.Windows.Forms.Label AboutPanel_Website1;
        private System.Windows.Forms.PictureBox FormatLoadingPicture;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar StatusProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelOverall;
        private System.Windows.Forms.Label FormatListErrorLabel;
    }
}


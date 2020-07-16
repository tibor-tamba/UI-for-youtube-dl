namespace VideoDownloader
{
    partial class WMPForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WMPForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Closingpanel = new System.Windows.Forms.Panel();
            this.ClosingLabel = new System.Windows.Forms.Label();
            this.axWMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.ShowHideButton = new System.Windows.Forms.Button();
            this.PlaylistBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Closingpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ShowHideButton);
            this.splitContainer1.Panel1.Controls.Add(this.Closingpanel);
            this.splitContainer1.Panel1.Controls.Add(this.axWMP);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PlaylistBox);
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // Closingpanel
            // 
            this.Closingpanel.Controls.Add(this.ClosingLabel);
            resources.ApplyResources(this.Closingpanel, "Closingpanel");
            this.Closingpanel.Name = "Closingpanel";
            // 
            // ClosingLabel
            // 
            resources.ApplyResources(this.ClosingLabel, "ClosingLabel");
            this.ClosingLabel.Name = "ClosingLabel";
            // 
            // axWMP
            // 
            resources.ApplyResources(this.axWMP, "axWMP");
            this.axWMP.Name = "axWMP";
            this.axWMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWMP.OcxState")));
            // 
            // ShowHideButton
            // 
            resources.ApplyResources(this.ShowHideButton, "ShowHideButton");
            this.ShowHideButton.ForeColor = System.Drawing.Color.Black;
            this.ShowHideButton.Name = "ShowHideButton";
            this.ShowHideButton.UseVisualStyleBackColor = true;
            this.ShowHideButton.Click += new System.EventHandler(this.ShowHideButton_Click);
            // 
            // PlaylistBox
            // 
            resources.ApplyResources(this.PlaylistBox, "PlaylistBox");
            this.PlaylistBox.FormattingEnabled = true;
            this.PlaylistBox.Name = "PlaylistBox";
            this.PlaylistBox.DoubleClick += new System.EventHandler(this.PlaylistBox_DoubleClick);
            // 
            // WMPForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "WMPForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WMPForm_FormClosing);
            this.Load += new System.EventHandler(this.WMPForm_Load);
            this.SizeChanged += new System.EventHandler(this.WMPForm_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Closingpanel.ResumeLayout(false);
            this.Closingpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWMP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox PlaylistBox;
        private System.Windows.Forms.Button ShowHideButton;
        private System.Windows.Forms.Panel Closingpanel;
        private System.Windows.Forms.Label ClosingLabel;
        private AxWMPLib.AxWindowsMediaPlayer axWMP;
    }
}
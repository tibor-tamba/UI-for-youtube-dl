using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VideoDownloader
{
    public partial class WMPForm : Form
    {
        List<string> Titles;
        List<string> Paths;
        WMPLib.IWMPPlaylist playlist;

        public WMPForm(List<string> ListTitles, List<string> ListPaths)
        {
            InitializeComponent();
            axWMP.stretchToFit = true;
            playlist = axWMP.newPlaylist(Languages.Strings.PlayListName, "");
            WMPLib.IWMPMedia media;
            Titles = ListTitles;
            Paths = ListPaths;
            foreach (string p in Paths)
            {
                media = axWMP.newMedia(p);
                playlist.appendItem(media);
            }
            foreach (string p in Titles)
            {
                PlaylistBox.Items.Add(p);
            }
            axWMP.currentPlaylist = playlist;
            if (Titles.Count == 1) ShowHideButton_Click(new object(), new EventArgs());
        }

        private void WMPForm_Load(object sender, EventArgs e)
        {          
            WMPForm_SizeChanged(sender, e);
        }


        private void PlaylistBox_DoubleClick(object sender, EventArgs e)
        {
            if (PlaylistBox.SelectedIndex >= 0) axWMP.Ctlcontrols.currentItem = axWMP.currentPlaylist.Item[PlaylistBox.SelectedIndex];
            axWMP.Ctlcontrols.play();
        }

        private void WMPForm_SizeChanged(object sender, EventArgs e)
        {
            ShowHideButton.Left = splitContainer1.Panel1.Width - ShowHideButton.Width;
            ShowHideButton.Top = splitContainer1.Panel1.Height - ShowHideButton.Height;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ShowHideButton.Left = splitContainer1.Panel1.Width - ShowHideButton.Width;
            ShowHideButton.Top = splitContainer1.Panel1.Height - ShowHideButton.Height;
        }

        private void ShowHideButton_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            if (splitContainer1.Panel2Collapsed) ShowHideButton.Text = "▲"; else ShowHideButton.Text = "▼";
            WMPForm_SizeChanged(sender, e);
        }

        private void WMPForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Closingpanel.Left = axWMP.Width / 2 - Closingpanel.Width / 2;
            Closingpanel.Top = axWMP.Height / 2 - Closingpanel.Height / 2;
            Closingpanel.Visible = true;
            axWMP.Ctlcontrols.stop();
            axWMP.close();
            axWMP.Dispose();
        }

        private void axWMP_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            Text = axWMP.Ctlcontrols.currentItem.sourceURL;
            for (int i = 0; i < PlaylistBox.Items.Count; i++)
            {
                if (playlist.Item[i].sourceURL == axWMP.Ctlcontrols.currentItem.sourceURL) { PlaylistBox.SelectedIndex = i; break; }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //playlist = axWMP.playlistCollection.newPlaylist("Kijelölt videók");
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
            //ApplyLanguage();
        }

        //private void ApplyLanguage() => ClosingLabel.Text = Languages.Strings.ClosingLabel;

        private void PlaylistBox_DoubleClick(object sender, EventArgs e)
        {
            //WMPLib.WMPPlayState Playing = axWMP.playState;
            if (PlaylistBox.SelectedIndex >= 0) axWMP.Ctlcontrols.currentItem = axWMP.currentPlaylist.Item[PlaylistBox.SelectedIndex];
            //if (Playing == WMPLib.WMPPlayState.wmppsPlaying) axWMP.Ctlcontrols.play();
            axWMP.Ctlcontrols.play();
        }

        private void WMPForm_SizeChanged(object sender, EventArgs e)
        {
            //if (!splitContainer1.Panel2Collapsed && WindowState != FormWindowState.Minimized)
            //     if (PlaylistBox.Visible)
            //     {
            //         if (PlaylistBox.Width > 200) splitContainer1.SplitterDistance = Convert.ToInt32(Width * 0.7);
            //         //if (PlaylistBox.Width < 160) splitContainer1.SplitterDistance = Width - 160;
            //     } else splitContainer1.SplitterDistance = Width;
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
            //axWMP.playlistCollection.remove(playlist);
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

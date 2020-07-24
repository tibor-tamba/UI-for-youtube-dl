using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libyoutube_dl;

namespace VideoDownloader
{
    public partial class MainForm : Form
    {
        private VideoItemCollection VideoItems;
        private WMPForm WMP;
        private SettingsForm settingsForm;
        private Dictionary<string, string> ErrorStrings;
        private double[] ColumnSizes = new double[7] { 0.30, 0.10, 0.10, 0.09, 0.1, 0.16, 0.15 };
        private bool ItemCheckedStateDefault = true;
        private string FormTitle;

        public MainForm()
        {
            InitializeComponent();
            SetDoubleBuffering(MainListView, true);
            SetDoubleBuffering(FormatListView, true);
            ErrorStrings = new Dictionary<string, string>();
            VideoItems = new VideoItemCollection(ref Program.AppSettings);
            VideoItems.ItemRemoved += VideoItems_ItemRemoved;
            if (PatternFile.Initialized) ErrorsStringsFromRes();
            FormTitle = Text;
        }

        public static void SetDoubleBuffering(Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            controlProperty.SetValue(control, value, null);
        }

        // Retrieves the error strings from ErrorStrings field of strings.resx, and put them into the ErrorStrings dictionary along with Error ID-s.
        private void ErrorsStringsFromRes()
        {
            List<string> es = new List<string>();
            string s0 = Languages.Strings.ErrorStrings;
            string s;
            int c = 0;
            while (s0.IndexOf(';') > 0)
            {
                s = s0.Substring(0, s0.IndexOf(';'));
                es.Add(s);
                s0 = s0.Remove(0, s0.IndexOf(';')+1);
            }
            for (int i = 0; i < PatternFile.Definitions.Count; i++)
            {
                if (PatternFile.Definitions[i].Name.Contains("Error"))
                {
                    if (c >= es.Count)
                        es.Add("");
                    ErrorStrings.Add(PatternFile.Definitions[i].Name, es[c]);
                    c++;
                }
            }
       }
        private void AddVideoItem(string Url)
        {
            int c = VideoItems.Count;
            VideoItems.Add(Url);
            VideoItems[c].GetInfo += GetInfo_Event;
            VideoItems[c].GetFormat += GetFormat_Event;
            VideoItems[c].DownloadingVideo += DownloadingVideo_Event;
            VideoItems[c].DownloadingVideoFinished += DownloadingVideoFinished_Event;
            VideoItems[c].StatusCodeChanged += Downloading_StatusCodeChanged_Event;
            VideoItems[c].InfoQueryStart += InfoQueryStart_Event;
            VideoItems[c].ToQueryInfo = true;  //Indicates to the sheduler to start the query process.
            MainListView.Items.Add(Languages.Strings.ProgressBoxAdding + "...");
            MainListView.Items[c].Checked = ItemCheckedStateDefault;
            SetStatusBarText();
            SetStatusBarProgress();
        }
        private void AddVideoItems(string[] Lines)
        {
            if (Lines.Length>0)
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i] != "")
                {
                    if (!VideoItems.HasUrl(Lines[i])) AddVideoItem(Lines[i]);
                    else
                        MessageBox.Show(Languages.Strings.WarnUrlAlreadyAdded+" "+Lines[i], Languages.Strings.WarnGeneralTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else MessageBox.Show(Languages.Strings.ErrEmptyUrlBox, Languages.Strings.ErrGeneralTitle);
        }
        private void SynchronizeVideoList(ListView VList)
        {
            List<bool> checkstates = new List<bool>();
            for (int i = 0; i < VideoItems.Count; i++)
            {
                if (VideoItems.Count <= VList.Items.Count) checkstates.Add(VList.Items[i].Checked);
                else checkstates.Add(ItemCheckedStateDefault);
            }
            VList.Items.Clear();
            PreviewImages.Images.Clear();
            foreach (VideoItem item in VideoItems)
            {
                if (item.ThumbnailImage != null) PreviewImages.Images.Add(item.ThumbnailImage);
                else PreviewImages.Images.Add(Properties.Resources.NoImage80x80);
                VList.Items.Add(item.VideoTitle, item.ListIndex);
                VList.Items[item.ListIndex].SubItems.Add(item.VideoUrl);
                VList.Items[item.ListIndex].SubItems.Add(item.VideoFormat);
                VList.Items[item.ListIndex].SubItems.Add(item.VideoLength);
                VList.Items[item.ListIndex].SubItems.Add(item.FileSize);
                VList.Items[item.ListIndex].SubItems.Add("");
                VList.Items[item.ListIndex].SubItems.Add(item.VideoFilePath);
                Downloading_StatusCodeChanged_Event(item, new EventArgs()); //Rewrites the status columns based on the statuscodes.
                if (item.ListIndex <= checkstates.Count) VList.Items[item.ListIndex].Checked = checkstates[item.ListIndex];
                else VList.Items[item.ListIndex].Checked = ItemCheckedStateDefault;
            }
        }
        private void SynchronizeFormatList(ListView FList, int index)
        {
            FormatLoadingPicture.Visible = false;
            FList.Items.Clear();
            int i = 0;
            foreach (FormatProperty item in VideoItems[index].FormatList)
            {
                FList.Items.Add(item.FormatCode);
                FList.Items[i].SubItems.Add(item.Extension);
                FList.Items[i].SubItems.Add(item.Resolution);
                FList.Items[i].SubItems.Add(item.Note);
                if (item.IsSelected) FList.Items[i].Selected = true;
                i++;
            }
            FormatListLabel.Text = VideoItems[index].VideoTitle;
            if (!VideoItems[index].FormatQueried)
            {
                FormatListErrorLabel.Text = Languages.Strings.ErrFormatQuerying;
                FormatListErrorLabel.Show();
            }
            else FormatListErrorLabel.Hide();
        }
        // Writes which URL's information is querying.
        private void ShowVideoAddingBox()
        {
            AddingVideoPanel.Show();
            AddingVideoLabel.Text = "";
            for (int i = 0; i < VideoItems.Count; i++)
            {
                if (VideoItems[i].InfoQuerying)
                {
                    if (i > 0) AddingVideoLabel.Text += "\n"; // Adding new line symbol to the text if it's not the first URL.
                    AddingVideoLabel.Text += VideoItems[i].VideoUrl;
                }
            }
        }

        // *************** Event methods ***************

        private void InfoQueryStart_Event(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate ()
            {
                ShowVideoAddingBox();
            });
        }

        private void VideoItems_ItemRemoved(object sender, VideoItemCollection.ItemRemovedEventArgs e)
        {
            MainListView.Items.RemoveAt(e.ItemIndex);
            SetFormCaption();
            SetStatusBarText();
            SetStatusBarProgress();
        }

        private void DownloadingVideoFinished_Event(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate ()
            {
                SetFormCaption();
                SetStatusBarProgress();
            });
        }

        private void SetFormCaption()
        {
            if (MainListView.Items.Count > 0) Text = $"{Convert.ToString(VideoItems.FinishedCount)} / {Convert.ToString(VideoItems.Count)} ({StatusLabelOverall.Text}) - {FormTitle}";
            else Text = FormTitle;
        }

        private void SetStatusBarProgress()
        {
            try
            {
                double PercentSum = 0;
                for (int i = 0; i < VideoItems.Count; i++)
                {
                    PercentSum += VideoItems[i].Download_Percent;
                }
                double OverallPercent = PercentSum / (VideoItems.Count * 100);
                StatusProgressBar.Value = Convert.ToInt32(OverallPercent * 100);
            }
            catch { StatusProgressBar.Value = 0; }
            StatusLabelOverall.Text = Convert.ToString(StatusProgressBar.Value) + "%";
        }

        private void DownloadingVideo_Event(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate ()
            {
                SetStatusBarProgress();
                SetFormCaption();
            });
        }
        private void Downloading_StatusCodeChanged_Event(object sender, EventArgs e)
        {
            VideoItem v = (VideoItem)sender;
            string sizeText = v.FileSize;
            string statusText = "";
            string pathText = v.VideoFilePath;
            if (MainListView.Items.Count > 0)
                Invoke((MethodInvoker)delegate ()
                {
                    switch (v.StatusCode)
                    {
                        case VideoItem.DownloadingStatusCode.Pending:
                            statusText = Languages.Strings.Status_Pending;
                            break;
                        case VideoItem.DownloadingStatusCode.Starting:
                            statusText = Languages.Strings.Status_Starting;
                            break;
                        case VideoItem.DownloadingStatusCode.Resuming:
                            statusText = $"{Languages.Strings.Status_Resume0} {v.ResumedAtByte} {Languages.Strings.Status_Resume1}";
                            break;
                        case VideoItem.DownloadingStatusCode.Already:
                            statusText = Languages.Strings.Status_Already;
                            break;
                        case VideoItem.DownloadingStatusCode.Downloading:
                            statusText = $"{Languages.Strings.Status_Progress0} {Convert.ToString(v.Download_Percent)}%\n" +
                                         $"{Languages.Strings.Status_Progress1} {v.Download_Speed}\n" +
                                         $"{Languages.Strings.Status_Progress2} {v.Download_ETA}";
                            break;
                        case VideoItem.DownloadingStatusCode.Converting:
                            statusText = Languages.Strings.Status_Converting;
                            break;
                        case VideoItem.DownloadingStatusCode.Deletingoriginal:
                            statusText = Languages.Strings.Status_DelOriginal;
                            break;
                        case VideoItem.DownloadingStatusCode.Addingthumbnail:
                            statusText = Languages.Strings.Status_AddPicture;
                            break;
                        case VideoItem.DownloadingStatusCode.Aborting:
                            statusText = Languages.Strings.Status_Aborting;
                            break;
                        case VideoItem.DownloadingStatusCode.Aborted:
                            statusText = Languages.Strings.Status_Aborted;
                            break;
                        case VideoItem.DownloadingStatusCode.Error:
                            statusText = $"{Languages.Strings.Status_Error} {GetErrorString(v.ErrorID)}";
                            break;
                        case VideoItem.DownloadingStatusCode.Finished:
                            statusText = Languages.Strings.Status_Finished;
                            break;
                    }
                    MainListView.Items[v.ListIndex].SubItems[4].Text = sizeText;
                    MainListView.Items[v.ListIndex].SubItems[5].Text = statusText;
                    MainListView.Items[v.ListIndex].SubItems[6].Text = pathText;
                });
        }

        private string GetErrorString(string errorid)
        {
            string es;
            try
            { es = ErrorStrings[errorid]; }
            catch (Exception)
            { es = Languages.Strings.ErrUnknown; }
            return es;
        } 
        
        private void GetFormat_Event(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate ()
            {
                if (MainListView.SelectedItems.Count > 0)
                    if (MainListView.SelectedItems[0].Index == ((VideoItem)sender).ListIndex)
                        SynchronizeFormatList(FormatListView, ((VideoItem)sender).ListIndex);
            });
        }
        private void GetInfo_Event(object sender, VideoItem.InfoQueryEventArgs e)
        {
            Invoke((MethodInvoker)delegate ()
            {
                if (e.ErrorID != "")
                {
                    VideoItems.SuspendInfoQueryScheduler();
                    VideoItems.SuspendFormatQueryScheduler();
                    VideoItems.SuspendVideoQueryScheduler();
                    VideoItems.RemoveAt(((VideoItem)sender).ListIndex);
                    MessageBox.Show(GetErrorString(e.ErrorID), Languages.Strings.ErrGeneralTitle, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    VideoItems.ResumeInfoQueryScheduler();
                    VideoItems.ResumeFormatQueryScheduler();
                    VideoItems.ResumeVideoQueryScheduler();
                }
                else
                    if (VideoItems.GetCurrentInfoThreads() == 0)  SynchronizeVideoList(MainListView); // If the last process is done refresh the list. Prevents the list from unnecessary refreshing.
                ShowVideoAddingBox();
                if (VideoItems.GetCurrentInfoThreads() == 0) AddingVideoPanel.Hide();
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Resize(sender, e);
            CheckImages.Images.Add(Properties.Resources.Color_Checkbox_unchecked40);
            CheckImages.Images.Add(Properties.Resources.Color_Checkbox_checked40);
            WMP = new WMPForm(new List<string>(), new List<string>());
            ConvertButton.Checked = Program.AppSettings.Format_ConvertEnabled;
            //Begin testing.
            //AddVideoItem("https://www.youtube.com/watch?v=");
            // End testing.
        }
        // Sets the positions of the program's panels every time the window is resized.
        private void MainForm_Resize(object sender, EventArgs e)
        {
            MainListView.BeginUpdate();
            for (byte i = 0; i < 7; i++) MainListView.Columns[i].Width = Convert.ToInt32((MainListView.Width - 22) * ColumnSizes[i]);
            AddPanel.Left = MainListView.Width / 2 - (AddPanel.Width / 2);
            AddPanel.Top = MainListView.Height / 2 - (AddPanel.Height / 2) - 90;
            AboutPanel.Left = MainListView.Width / 2 - (AboutPanel.Width / 2);
            AboutPanel.Top = MainListView.Height / 2 - (AboutPanel.Height / 2);
            AddingVideoPanel.Left = MainListView.Width / 2 - (AddingVideoPanel.Width / 2);
            AddingVideoPanel.Top = MainListView.Height / 2 - (AddingVideoPanel.Height / 2) + 35;
            FormatSelectPanel.Left = MainListView.Width - FormatSelectPanel.Width - 20;
            FormatSelectPanel.Top = 60;
            MainListView.EndUpdate();
            MainListView.Refresh();
        }
        // Enables the using of Ctrl + V in the main window.
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            { AddClipButton_Click(new object(), new EventArgs()); }
        }

        private void FormatListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormatListView.SelectedItems.Count > 0)
            {
                VideoItems[MainListView.SelectedItems[0].Index].FormatList.SelectedIndex = FormatListView.SelectedItems[0].Index;
                MainListView.SelectedItems[0].SubItems[2].Text = VideoItems[MainListView.SelectedItems[0].Index].VideoFormat;
            }
        }
        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainListView.SelectedItems.Count > 0)
            {
                if (FormatButton.Checked)
                {
                    int si = MainListView.SelectedItems[0].Index;
                    if (VideoItems[si].FormatQueried) SynchronizeFormatList(FormatListView, si);
                    else
                    {
                        VideoItems[si].ToQueryFormat = true;
                        FormatLoadingPicture.Visible = true;
                        FormatListView.Items.Clear();
                        VideoItems.StartFormatQueryScheduler();
                    } 
                }
                FormatButton.Enabled = true;
                if (FormatButton.Checked) FormatSelectPanel.Show();
            }
            else
            {
                FormatButton.Enabled = false;
                FormatSelectPanel.Hide();
            }
        }

        private void MainListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            SetStatusBarText();
        }

        private void SetStatusBarText()
        {
            StatusLabel.Text = Convert.ToString(MainListView.CheckedItems.Count) + " / " + Convert.ToString(MainListView.Items.Count);
        }

        // Closes the Url adding panel.
        private void Add_UrlCloseButton_Click(object sender, EventArgs e) { AddButton.Checked = false; }
        // Pastes the text from the clipboard to the textbox of "Add URL panel".
        private void Add_UrlPasteButton_Click(object sender, EventArgs e)
        {
            Add_UrlBox.Text = Clipboard.GetText();
        }
        // Adds the URL from the textbox to the list. Checks whether it added before. Checks whether the textbox is not empty.
        private void Add_UrlButton_Click(object sender, EventArgs e)
        {
            AddVideoItems(Add_UrlBox.Lines);
            VideoItems.StartInfoQueryScheduler();
            Add_UrlBox.Clear();
            AddButton.Checked = false;
            MainListView.Focus();
        }

        private void AddButton_CheckStateChanged(object sender, EventArgs e)
        {
            if (AddButton.Checked) { AddPanel.Show(); AddPanel.BringToFront(); Add_UrlBox.Focus(); } else { AddPanel.Hide(); MainListView.Focus(); }
        }

        private void AddClipButton_Click(object sender, EventArgs e)
        {
            Add_UrlPasteButton_Click(sender, e);
            Add_UrlButton_Click(sender, e);
        }

        // Selects all item, clear selection or invert selection in the list, depends which buttons are clicked.
        private void ItemSelection(object sender, EventArgs e)
        {
            foreach (ListViewItem i in MainListView.Items)
            {
                switch (((ToolStripButton)sender).Text)
                {
                    case "SelAllBtn": i.Checked = true; break;
                    case "SelNoneBtn": i.Checked = false; break;
                    case "SelInvBtn": i.Checked = !i.Checked; break;
                }
            }
            MainListView.Focus();
        }

        // Removes the selected items from the list, or Removes all item from the list if the calling button is DelAllButton.
        private async void DelButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in MainListView.Items) { if (item.Checked||((ToolStripButton)sender).Name=="DelAllButton") await VideoItems.RemoveAtAsync(item.Index); }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainListView.Items.Count; i++)
            {
                VideoItems[i].ToQueryVideo = MainListView.Items[i].Checked;
            }
            VideoItems.StartVideoQueryScheduler();
            SetFormCaption(); // Write out the finished/count to the form caption.
            SetStatusBarProgress();
        }
        // Stops the download of the selected items in the list.
        private async void StopButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MainListView.Items.Count; i++)
            {
                if (MainListView.Items[i].Checked) await VideoItems[i].StopVideoQueryAsync();
            }
        }
        // Starts a Windows Explorer window with the destination folder.
        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            try { Process.Start(Program.AppSettings.Location_Output); } catch { }
        }

        // Creates a mediaplayer window using Windows Media Player ActiveX, and adds a list from downloaded and selected items.
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!WMP.Visible)
            {
                List<string> t = new List<string>();
                List<string> p = new List<string>();
                foreach (VideoItem i in VideoItems)
                {
                    if (MainListView.Items[i.ListIndex].Checked && ((i.StatusCode==VideoItem.DownloadingStatusCode.Finished)||(i.StatusCode==VideoItem.DownloadingStatusCode.Already)))
                    {
                        t.Add(i.VideoTitle);
                        p.Add(i.VideoFilePath);
                    }
                }
                if (t.Count > 0)
                { WMP = new WMPForm(t, p); WMP.Show(); }
            }
        }
        // Making visible of the Settings window.
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            settingsForm = new SettingsForm();
            settingsForm.FormClosing += SettingsForm_FormClosing;
            settingsForm.Show();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConvertButton.Checked = Program.AppSettings.Format_ConvertEnabled;
        }

        private void ConvertButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ConvertButton.Checked)
            {
                ConvertButton.Image = Properties.Resources.Color_Converton50;
                ConvertButton.ToolTipText = Languages.Strings.ConvertButton_Tooltiptext + ": " + Program.AppSettings.Format_ConvertFormat;
                Program.AppSettings.Format_ConvertEnabled = true;
            }
            else
            {
                ConvertButton.Image = Properties.Resources.Color_Convertoff50;
                ConvertButton.ToolTipText = Languages.Strings.ConvertButton_Tooltiptext;
                Program.AppSettings.Format_ConvertEnabled = false;
            }
        }

        private void FormatButton_CheckStateChanged(object sender, EventArgs e)
        {
            if (FormatButton.Checked)
            {
                FormatSelectPanel.Visible = true;
                MainListView_SelectedIndexChanged(sender, e);
            }
            else { FormatSelectPanel.Visible = false; }
        }
        // Shows the information window.
        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutButton.Checked = !AboutButton.Checked;
            AboutPanel.Visible = AboutButton.Checked;
        }
        private void Websites_Click(object sender, EventArgs e)
        {
            try {
                switch (((Label)sender).Name)
                {
                    case "AboutPanel_Website1": Process.Start("https://youtube-dl.org/"); break;
                    case "AboutPanel_Website2": Process.Start("http://ytdl-org.github.io/youtube-dl/supportedsites.html"); break;
                }
            }
            catch { }
        }
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                // Clearing sensitive data fields before saving the settings. 
                Program.AppSettings.Credentials_Username = "";
                Program.AppSettings.Credentials_Password = "";
                Program.AppSettings.Credentials_TwoFactor = "";
                Program.AppSettings.Credentials_VideoPassword = "";
                Program.AppSettings.Save();
                AddingVideoPanel.Show();
                AddingVideoLabel.Text = Languages.Strings.MainWindowsClosing;
                AddingVideoPanel.Refresh();
                VideoItems.StopInfoQueryScheduler();
                VideoItems.StopFormatQueryScheduler();
                VideoItems.StopVideoQueryScheduler();
                foreach (VideoItem item in VideoItems)
                {
                    await item.StopFormatQueryAsync();
                    await item.StopInfoQueryAsync();
                    await item.StopVideoQueryAsync();
                }
                Application.Exit();
            }
        }
    }
}

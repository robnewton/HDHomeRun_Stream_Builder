using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using System.Data.SQLite;
using System.Xml.Linq;
using Vlc.DotNet.Core.Medias;
using System.Net;
using System.Net.Sockets;

namespace HDHomerun_Stream_Builder
{
    public partial class Main : Form
    {
        List<Channel> channels = new List<Channel>();
        public Main()
        {
            InitializeComponent();
            OpenCachedSettings();
            device = device_tb.Text;
            tuner = tuner_cb.Text;
            if (OpenCachedChannels())
                RenderChannelList();
        }

        private string _strmDirectory;
        public string StrmDirectory
        {
            get
            {
                if ((_strmDirectory != "") && (_strmDirectory != null))
                    return _strmDirectory;
                else
                    return settings.StrmFilePath + @"\tuner" + tuner + @"\";
                    //return Path.GetDirectoryName(Application.ExecutablePath) + @"\strm\";
            }
            set
            {
                _strmDirectory = value;
            }
        }

        private string _chlPath;
        public string ChlPath
        {
            get
            {
                if ((_chlPath != "") && (_chlPath != null))
                    return _chlPath;
                else
                    return new FileInfo(settings.MC2XMLPath).Directory + @"\mc2xml.chl";
            }
            set
            {
                _chlPath = value;
            }
        }

        public delegate void AddChannelToLVDelegate(ListViewItem lv);
        public void AddChannelToLV(ListViewItem lv)
        {
            if (channelList.InvokeRequired)
                Invoke(new AddChannelToLVDelegate(AddChannelToLV), new object[] { lv });
            else
            {
                channelList.Items.Add(lv);
                this.Refresh();
            }
        }

        public delegate void LogDelegate(string msg);
        public void Log(string msg)
        {
            if (log.InvokeRequired)
                Invoke(new LogDelegate(Log), new object[] { msg });
            else
            {
                log.Text += msg + "\r\n";
                log.SelectionStart = log.Text.Length;
                log.ScrollToCaret();
            }
        }

        public void ClearChannelsAndCache()
        {
            System.IO.File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + @"\channel_cache.json");
            channels.Clear();
            RenderChannelList();
        }

        public bool CacheChannels()
        {
            try
            {
                string channelJson = JsonConvert.SerializeObject(channels);
                System.IO.File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath) + @"\channel_cache.json", channelJson);
            }
            catch (Exception) { return false; }
            return true;
        }

        public bool OpenCachedChannels()
        {
            try
            {
                string channelJson = System.IO.File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + @"\channel_cache.json");
                channels = JsonConvert.DeserializeObject<List<Channel>>(channelJson);
            }
            catch (Exception e) { return false; }
            if (channels.Count > 0)
                return true;
            else
                return false;
        }

        public void SortByVirtualNumber()
        {
            channels.Sort(delegate(Channel p1, Channel p2) { return p1.VirtualNumberAsInt.CompareTo(p2.VirtualNumberAsInt); });
        }

        public Channel GetChannelByVirtualNumber(string vnumber)
        {
            Channel result = null;
            result = channels.Find(
                 delegate(Channel channel)
                 {
                     return channel.VirtualNumber == vnumber;
                 }
             );
            return result;
        }

        public int GetChannelIndexByVirtualNumber(string vnumber)
        {
            int result = -1;
            result = channels.FindIndex(
                 delegate(Channel channel)
                 {
                     return channel.VirtualNumber == vnumber;
                 }
             );
            return result;
        }

        public void BuildFullXMLTVFile()
        {
            ProcessStartInfo xmltv = new ProcessStartInfo();
            xmltv.FileName = settings.MC2XMLPath;
            xmltv.UseShellExecute = false;
            xmltv.RedirectStandardOutput = true;
            xmltv.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            xmltv.CreateNoWindow = true;
            string[] args = { "-f", "-C", "none", "-o", "\"" + new FileInfo(settings.MC2XMLPath).Directory + @"\xmltv_full.xml" + "\"" };
            xmltv.Arguments = String.Join(" ", args);
            using (Process process = Process.Start(xmltv))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = "";
                    while ((result = reader.ReadLine()) != null)
                    {
                        Log(result);
                    }
                }
            }
        }

        public void BuildFavoritesXMLTVFile()
        {
            ProcessStartInfo xmltv = new ProcessStartInfo();
            xmltv.FileName = settings.MC2XMLPath;
            xmltv.UseShellExecute = false;
            xmltv.RedirectStandardOutput = true;
            xmltv.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            xmltv.CreateNoWindow = true;
            string[] args = { "-f", "-o", "\"" + new FileInfo(settings.MC2XMLPath).Directory + @"\xmltv.xml" + "\"" };
            xmltv.Arguments = String.Join(" ", args);
            using (Process process = Process.Start(xmltv))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = "";
                    while ((result = reader.ReadLine()) != null)
                    {
                        Log(result);
                    }
                }
            }
            Log("Done!");
        }

        public List<XMLTVChannel> xmltvChannels = new List<XMLTVChannel>();

        public void LoadFullXMLTVChannels()
        {
            Log("Loading XMLTV channel data");
            xmltvChannels = new List<XMLTVChannel>();
            string xmltvPath = new FileInfo(settings.MC2XMLPath).Directory + @"\xmltv_full.xml";
            XDocument doc = XDocument.Load(xmltvPath);
            foreach (XElement xe in doc.Descendants("tv"))
            {
                foreach (XElement xe1 in xe.Descendants())
                {
                    switch (xe1.Name.ToString())
                    {
                        case "channel":
                            xmltvChannels.Add(new XMLTVChannel(xe1));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        Dictionary<string, string> TVGuideSettings = new Dictionary<string, string>();

        public void LoadTVGuideSettings()
        {
            TVGuideSettings = new Dictionary<string, string>();
            string xmltvPath = new FileInfo(settings.TVGuidePath).Directory + @"\settings.xml";
            XDocument doc = XDocument.Load(xmltvPath);
            foreach (XElement xe in doc.Descendants("settings"))
            {
                foreach (XElement xe1 in xe.Descendants())
                {
                    TVGuideSettings.Add((string)xe1.Attribute("id"), (string)xe1.Attribute("value"));
                }
            }
        }

        public void SaveTVGuideSettings()
        {
            string xml = "<settings>\r\n";
            foreach (KeyValuePair<String, String> setting in TVGuideSettings)
            {
                xml += String.Format("    <setting id=\"{0}\" value=\"{1}\" />\r\n", setting.Key, setting.Value);
            }
            xml += "</settings>";
            string xmltvPath = new FileInfo(settings.TVGuidePath).Directory + @"\settings.xml";
            System.IO.File.WriteAllText(xmltvPath, xml);
        }

        public void UpdateTVGuideSettingXML()
        {
            Log("Updating TVGuide settings.xml");
            LoadTVGuideSettings();
            TVGuideSettings["source"] = "XMLTV";
            SaveTVGuideSettings();
        }

        public void EnhanceChannelsWithXMLTVData()
        {
            LoadFullXMLTVChannels();
            Log("Enhancing channels with XMLTV data");
            foreach (XMLTVChannel xmlChannel in xmltvChannels)
            {
                int index = GetChannelIndexByVirtualNumber(xmlChannel.VirtualNumber);
                if (index > -1)
                {
                    channels[index].Id = xmlChannel.Id;
                    channels[index].Name = xmlChannel.Fullname;
                    channels[index].Callsign = xmlChannel.Callsign;
                }
            }
        }

        public string device = "";
        public string tuner = "";

        public void ScanChannels()
        {
            Log("Starting scan...");

            tuner = tuner_cb.Text;
            string channel_number = "";

            ProcessStartInfo discover = new ProcessStartInfo();
            discover.FileName = settings.HDHRPath;
            discover.UseShellExecute = false;
            discover.RedirectStandardOutput = true;
            discover.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            discover.CreateNoWindow = true;
            string[] args = { "discover" };
            discover.Arguments = String.Join(" ", args);
            using (Process process = Process.Start(discover))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = "";
                    while ((result = reader.ReadLine()) != null)
                    {
                        Regex expression = new Regex(@"device (?<Identifier>.*) found");
                        var results = expression.Matches(result);
                        foreach (Match match in results)
                        {
                            Log("Found device: " + match.Groups["Identifier"].Value);
                            device = match.Groups["Identifier"].Value;
                            device_tb.Text = match.Groups["Identifier"].Value;
                        }
                    }
                }
            }
                    
            ProcessStartInfo scan = new ProcessStartInfo();
            scan.FileName = settings.HDHRPath;
            scan.UseShellExecute = false;
            scan.RedirectStandardOutput = true;
            scan.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            scan.CreateNoWindow = true;
            string[] args2 = { device, "scan", "/tuner" + tuner };
            scan.Arguments = String.Join(" ", args2);

            string lastChannelNumber = "";

            using (Process process = Process.Start(scan))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    this.Focus();

                    string result = "";
                    while ((result = reader.ReadLine()) != null)
                    {
                        //Look for the start of a channel (like 51) 
                        Regex expression = new Regex(@"SCANNING.*:(?<Identifier>[0-9]+)");
                        var results = expression.Matches(result);
                        foreach (Match match in results)
                        {
                            if (lastChannelNumber != match.Groups["Identifier"].Value)
                            {
                                channel_number = match.Groups["Identifier"].Value;
                                Log("Scanning channel code: " + match.Groups["Identifier"].Value);
                                this.Refresh();
                            }
                            lastChannelNumber = match.Groups["Identifier"].Value;
                        }

                        //Look for the program number (like 7.1) 
                        //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>.*):\s(?<Program>.*)\s(?<Name>.*)");
                        //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.[0-9]+):\s(?<Program>[0-9]+.[0-9]+)\s(?<Name>.*)");
                        //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.?[0-9]*):\s(?<Program>[0-9]+.[0-9]+)\s(?<Name>.*)");
                        //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.?[0-9]*):\s(?<Program>[0-9]+\.?[0-9]*)\s(?<Name>.*)(?<Encrypted>\(encrypted\))?");
                        //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.?[0-9]*):\s(?<Program>[0-9]+\.?[0-9]*)\s?(?<Name>.*)(?<Encrypted>\(.*\))?");
                        Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.?[0-9]*):\s(?<Program>[0-9]+\.?[0-9]*)\s?(?<Name>.*)");
                        var results2 = expression2.Matches(result);
                        foreach (Match match2 in results2)
                        {
                            if (device == "")
                            {
                                device = device_tb.Text;
                            }
                            if (tuner == "")
                            {
                                tuner = tuner_cb.Text;
                            }
                            bool encrypted = (match2.Groups["Name"].Value.ToLower().Contains("(encrypted)"));
                            if (encrypted && settings.IgnoreAllEncrypted)
                                continue;
                            if ((match2.Groups["Program"].Value == "0") && settings.IgnoreZeroProgram)
                                continue;
                            channels.Add(new Channel(channel_number, device, tuner));
                            int i = channels.Count - 1;
                            channels[i].ProxyProgram = match2.Groups["Proxy"].Value;
                            channels[i].VirtualNumber = match2.Groups["Program"].Value;
                            channels[i].Encrypted = encrypted;
                            channels[i].Name = match2.Groups["Name"].Value.Replace(" (encrypted)", "");
                            Log("   Found virtual channel: " + channels[i].VirtualNumber + " - " + channels[i].Name);
                        }
                    }

                    BuildFullXMLTVFile();
                    EnhanceChannelsWithXMLTVData();
                    SortByVirtualNumber();
                    RenderChannelList();
                    CacheChannels();
                    Log("Done!");
                }
            }
        }

        public static string FileDialogFilter = "Text Document (*.txt)|*.txt|All files (*.*)|*.*";
        public static string FileInitialDirectory = @"C:\";

        private void ScanFromTextFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = FileDialogFilter;
            dlg.InitialDirectory = FileInitialDirectory;

            DialogResult res = dlg.ShowDialog();

            if (res != DialogResult.OK)
                return;

            Log("Starting scan...");

            string device = "";
            string tuner = tuner_cb.Text;
            string channel_number = "";
            string lastChannelNumber = "";

            using (StreamReader reader = new System.IO.StreamReader(dlg.FileName))
            {
                this.Focus();

                string result = "";
                while ((result = reader.ReadLine()) != null)
                {
                    //Look for the start of a channel (like 51) 
                    Regex expression = new Regex(@"SCANNING.*:(?<Identifier>[0-9]+)");
                    var results = expression.Matches(result);
                    foreach (Match match in results)
                    {
                        if (lastChannelNumber != match.Groups["Identifier"].Value)
                        {
                            channel_number = match.Groups["Identifier"].Value;
                            Log("Scanning channel code: " + match.Groups["Identifier"].Value);
                            this.Refresh();
                        }
                        lastChannelNumber = match.Groups["Identifier"].Value;
                    }

                    //Look for the program number (like 7.1) 
                    //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>.*):\s(?<Program>.*)\s(?<Name>.*)");
                    //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.[0-9]+):\s(?<Program>[0-9]+.[0-9]+)\s(?<Name>.*)");
                    //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.?[0-9]*):\s(?<Program>[0-9]+.[0-9]+)\s(?<Name>.*)");
                    //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.?[0-9]*):\s(?<Program>[0-9]+\.?[0-9]*)\s(?<Name>.*)(?<Encrypted>\(encrypted\))?");
                    //Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.?[0-9]*):\s(?<Program>[0-9]+\.?[0-9]*)\s?(?<Name>.*)(?<Encrypted>\(.*\))?");
                    Regex expression2 = new Regex(@"PROGRAM\s(?<Proxy>[0-9]+.?[0-9]*):\s(?<Program>[0-9]+\.?[0-9]*)\s?(?<Name>.*)");
                    var results2 = expression2.Matches(result);
                    foreach (Match match2 in results2)
                    {
                        if (device == "")
                        {
                            device = device_tb.Text;
                        }
                        if (tuner == "")
                        {
                            tuner = tuner_cb.Text;
                        }
                        bool encrypted = (match2.Groups["Name"].Value.ToLower().Contains("(encrypted)"));
                        if (encrypted && settings.IgnoreAllEncrypted)
                            continue;
                        if ((match2.Groups["Program"].Value == "0") && settings.IgnoreZeroProgram)
                            continue;
                        channels.Add(new Channel(channel_number, device, tuner));
                        int i = channels.Count - 1;
                        channels[i].ProxyProgram = match2.Groups["Proxy"].Value;
                        channels[i].VirtualNumber = match2.Groups["Program"].Value;
                        channels[i].Encrypted = encrypted;
                        channels[i].Name = match2.Groups["Name"].Value.Replace(" (encrypted)","");
                        Log("   Found virtual channel: " + channels[i].VirtualNumber + " - " + channels[i].Name);
                    }
                }

                SortByVirtualNumber();
                RenderChannelList();
                CacheChannels();
                Log("Done!");
            }
        }

        private void RenderChannelList()
        {
            Log("Refreshing channels on the screen");
            channelList.Items.Clear();
            for (int i = 0; i < channels.Count; i++)
            {
                //Update the list view
                ListViewItem lvi = new ListViewItem();
                lvi.Text = channels[i].VirtualNumber + " - " + channels[i].Name;
                lvi.Tag = channels[i];
                lvi.SubItems.AddRange(new string[] { channels[i].Id, channels[i].StreamUrl });
                lvi.ToolTipText = channels[i].StreamUrl;
                lvi.Checked = channels[i].Checked;
                AddChannelToLV(lvi);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CacheChannels();
        }

        private void FilterHDOnly()
        {
            foreach (ListViewItem item in channelList.Items)
            {
                if (item.Text.Contains("HD"))
                    item.Checked = true;
                else
                    item.Checked = false;
            }
        }

        public void ConfigureTVGuide()
        {
            Log("Checking for the source.db and settings.xml files");

            if (!System.IO.File.Exists(settings.TVGuidePath))
            {
                Log("   source.db file not found at: " + settings.TVGuidePath);
                Log("Failed TVGuide configuration");
                return;
            }
            else
            {
                Log("   source.db found at: " + settings.TVGuidePath);
            }

            if (!System.IO.File.Exists(settings.TVGuidePath))
            {
                Log("   settings.xml file not found at: " + new FileInfo(settings.TVGuidePath).Directory + @"\settings.xml");
                Log("Failed TVGuide configuration");
                return;
            }
            else
            {
                Log("   settings.xml file found at: " + new FileInfo(settings.TVGuidePath).Directory + @"\settings.xml");
            }

            Log("Rewriting TVGuide channels from favorites (including strm file references)");

            Log("   Clearing any existing channel configurations");
            SQLiteDatabase db = new SQLiteDatabase(settings.TVGuidePath);
            try
            {
                db.ClearTable("CUSTOM_STREAM_URL");
                db.ClearTable("CHANNELS");
            }
            catch (Exception crap)
            {
                Log(crap.Message);
                return;
            }

            int i = 0;
            foreach (Channel channel in channels)
            {
                if (channel.Checked)
                {
                    db = new SQLiteDatabase(settings.TVGuidePath);

                    //Channel insert data
                    Dictionary<String, String> channelData = new Dictionary<String, String>();
                    channelData.Add("ID", channel.Id);
                    channelData.Add("TITLE", channel.VirtualNumber + " " + channel.Callsign);
                    channelData.Add("SOURCE", "xmltv");
                    channelData.Add("VISIBLE", "1");
                    channelData.Add("WEIGHT", i.ToString());

                    //Custom streams insert data
                    Dictionary<String, String> streamData = new Dictionary<String, String>();
                    streamData.Add("CHANNEL", channel.Id);
                    streamData.Add("STREAM_URL", StrmDirectory + channel.Filename);

                    //Sources update
                    Dictionary<String, String> xmltvSourceUpdate = new Dictionary<String, String> { { "CHANNELS_UPDATED", "current_timestamp" } };
                    db.Update("SOURCES", xmltvSourceUpdate, "ID=\"xmltv\"");

                    try
                    {
                        db.Insert("CHANNELS", channelData);
                        db.Insert("CUSTOM_STREAM_URL", streamData);
                        Log("   Wrote channel: " + channel.VirtualNumber + " - " + channel.Callsign + " With stream path: " + StrmDirectory + channel.Filename);
                    }
                    catch (Exception crap)
                    {
                        Log(crap.Message);
                    }

                    i++;
                }
            }

            Log("Updating settings and last updated timestamps");

            UpdateTVGuideSettingXML();

            //Custom streams insert data
            DataTable updateMax;
            String query = "select max(id) + 1 as next_id from UPDATES;";
            updateMax = db.GetDataTable(query);
            string nextId = "";
            foreach (DataRow dRow in updateMax.Rows)
            {
                nextId = dRow["next_id"].ToString();
            }
            Dictionary<String, String> updatesData = new Dictionary<String, String>();
            updatesData.Add("ID", nextId);
            updatesData.Add("SOURCE", "xmltv");
            updatesData.Add("DATE", DateTime.UtcNow.ToString("yyyy-MM-dd"));
            updatesData.Add("PROGRAMS_UPDATED", "current_timestamp");
            db.Insert("UPDATES", updatesData);

            //Settings update data
            Dictionary<String, String> sourceSetting = new Dictionary<String, String> { { "VALUE", "XMLTV" } };
            db.Update("SETTINGS", sourceSetting, String.Format("KEY = {0}", "\"source\""));
            Dictionary<String, String> xmltvFileSetting = new Dictionary<String, String> { { "VALUE", new FileInfo(settings.MC2XMLPath).Directory + @"\xmltv.xml" } };
            db.Update("SETTINGS", xmltvFileSetting, String.Format("KEY = {0}", "\"xmltv.file\""));

            Log("Done updating TVGuide!");
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterHDOnly();
        }

        private void exportToStrmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(StrmDirectory))
                System.IO.Directory.CreateDirectory(StrmDirectory);
            foreach (ListViewItem item in channelList.Items)
            {
                Channel channel = (Channel)item.Tag;
                if (item.Checked)
                {
                    System.IO.File.WriteAllText(StrmDirectory + channel.Filename, channel.StreamUrl);
                    Log(item.Text + " strm file writen to: " + StrmDirectory + channel.Filename);
                }
            }
            Log("Done!");
        }

        private void scanChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanChannels();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FilterHDOnly();
        }

        private void channelList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Channel c = (Channel)e.Item.Tag;
            c.Checked = e.Item.Checked;
        }

        private void FilterByChannelRange(int start, int end, bool clearOthers = false)
        {
            foreach (ListViewItem item in channelList.Items)
            {
                Channel c = (Channel)item.Tag;
                if ((c.VirtualNumberAsInt >= start) && (c.VirtualNumberAsInt <= end))
                    item.Checked = true;
                else if (clearOthers)
                    item.Checked = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            SelectionRange selRange = new SelectionRange();
            dr = selRange.ShowDialog();
            if (dr == DialogResult.OK)
                FilterByChannelRange(selRange.Start, selRange.End, selRange.ClearOtherChecked);
        }

        private void checkSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in channelList.SelectedItems)
            {
                item.Checked = true;
            }
        }

        private void uncheckSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in channelList.SelectedItems)
            {
                item.Checked = false;
            }
        }

        private void updateTVGuideAddonStreamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CacheChannels();
            ConfigureTVGuide();
        }

        private void writeCHLFavoritesFile()
        {
            CacheChannels();
            Log("Writing favorites channel list to: " + ChlPath);
            string output = "";
            foreach (Channel channel in channels)
            {
                if (channel.Checked)
                    output += channel.VirtualNumber + "\r\n";
            }
            System.IO.File.WriteAllText(ChlPath, output);
            Log("Favorites written");
        }

        private void writeXML2CLchlFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            writeCHLFavoritesFile();
        }

        public bool CacheSettings()
        {
            try
            {
                string settingsJson = JsonConvert.SerializeObject(settings);
                System.IO.File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath) + @"\settings.json", settingsJson);
            }
            catch (Exception) { return false; }
            return true;
        }

        public bool OpenCachedSettings()
        {
            try
            {
                string settingsJson = System.IO.File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + @"\settings.json");
                settings = JsonConvert.DeserializeObject<Settings>(settingsJson);
                tuner_cb.Text = settings.Tuner;
                device_tb.Text = settings.Device;
            }
            catch (Exception e) { return false; }
            if (settings.HDHRPath != "")
                return true;
            else
                return false;
        }

        Settings settings = new Settings();

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            SettingsDlg settingsDlg = new SettingsDlg(settings);
            dr = settingsDlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (settings == null)
                {
                    settings = new Settings();
                }
                settings.HDHRPath = settingsDlg.HDHRInstallPath;
                settings.MC2XMLPath = settingsDlg.MC2XMLInstallPath;
                settings.TVGuidePath = settingsDlg.TVGuideInstallPath;
                settings.IgnoreAllEncrypted = settingsDlg.IgnoreAllEncrypted;
                settings.IgnoreZeroProgram = settingsDlg.IgnoreZeroProgram;
                settings.StrmFilePath = settingsDlg.StrmFilePath;
                CacheSettings();
            }
        }

        private void buildXMLTVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CacheChannels();
            writeCHLFavoritesFile();
            BuildFavoritesXMLTVFile();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutDlg = new About();
            aboutDlg.ShowDialog();
        }

        private void refreshChannelDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnhanceChannelsWithXMLTVData();
            CacheChannels();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTVGuideSettingXML();
        }

        private void scanFromScanOutputTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanFromTextFile();
        }

        private void addAChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            AddChannelDlg addChannelDlg = new AddChannelDlg();
            dr = addChannelDlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (device == "")
                {
                    device = device_tb.Text;
                }
                if (tuner == "")
                {
                    tuner = tuner_cb.Text;
                }
                Channel c = new Channel(addChannelDlg.Number, device, tuner);
                c.Callsign = addChannelDlg.Callsign;
                c.Name = addChannelDlg.Name;
                c.ProxyProgram = addChannelDlg.Proxy;
                c.VirtualNumber = addChannelDlg.VirtualNumber;
                channels.Add(c);
                RenderChannelList();
                CacheChannels();
            }
        }

        private void clearChannelsAndCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearChannelsAndCache();
        }

        private void device_tb_TextChanged(object sender, EventArgs e)
        {
            foreach (Channel c in channels)
            {
                c.Device = device_tb.Text;
            }
            device = device_tb.Text;
            settings.Device = device_tb.Text;
            CacheSettings();
            RenderChannelList();
        }

        private void tuner_cb_TextChanged(object sender, EventArgs e)
        {
            foreach (Channel c in channels)
            {
                c.Tuner = tuner_cb.Text;
            }
            tuner = tuner_cb.Text;
            settings.Tuner = tuner_cb.Text;
            CacheSettings();
            //RenderChannelList();
        }

        private void modifyChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = channelList.SelectedItems[0];
            if (item == null)
                return;
            DialogResult dr = new DialogResult();
            Channel c = (Channel)item.Tag;
            AddChannelDlg addChannelDlg = new AddChannelDlg(c.Number, c.VirtualNumber, c.ProxyProgram, c.Name, c.Callsign);
            dr = addChannelDlg.ShowDialog();
            if (dr == DialogResult.OK)
            {
                c.Number = addChannelDlg.Number;
                c.Callsign = addChannelDlg.Callsign;
                c.Name = addChannelDlg.Name;
                c.ProxyProgram = addChannelDlg.Proxy;
                c.VirtualNumber = addChannelDlg.VirtualNumber;
                //RenderChannelList();
                CacheChannels();
            }
        }

        private void channelList_MouseDown(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;

            if (e.Button == MouseButtons.Right)
            {
                listView.SelectedItems.Clear();
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !(splitContainer2.Panel2Collapsed);
        }

        public string GetLocalIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    return ip.ToString();
                }
            }
            return localIP;
        }

        public void TuneToChannel(Channel channel, bool popup = false)
        {
            Log("Tuning to channel: " + channel.VirtualNumber + " - " + channel.Name);

            ProcessStartInfo tune = new ProcessStartInfo();
            tune.FileName = settings.HDHRPath;
            tune.UseShellExecute = false;
            tune.RedirectStandardOutput = true;
            tune.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            tune.CreateNoWindow = true;

            //hdhomerun_config FFFFFFFF set /tuner0/channel none
            string[] args = { device, "set", "/tuner" + tuner + "/channel", "none" };
            tune.Arguments = String.Join(" ", args);
            Log("  exec: \"" + settings.HDHRPath + "\" " + tune.Arguments);
            using (Process process = Process.Start(tune))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = "";
                    while ((result = reader.ReadLine()) != null)
                    {
                        Log(result);
                    }
                }
            }

            //hdhomerun_config FFFFFFFF set /tuner0/channel none
            string[] args3 = { device, "set", "/tuner" + tuner + "/channel", "auto:" + channel.Number };
            tune.Arguments = String.Join(" ", args3);
            Log("  exec: \"" + settings.HDHRPath + "\" " + tune.Arguments);
            using (Process process3 = Process.Start(tune))
            {
                using (StreamReader reader = process3.StandardOutput)
                {
                    string result = "";
                    while ((result = reader.ReadLine()) != null)
                    {
                        Log(result);
                    }
                }
            }

            //hdhomerun_config FFFFFFFF set /tuner0/channel none
            string[] args2 = { device, "set", "/tuner" + tuner + "/program", channel.ProxyProgram };
            tune.Arguments = String.Join(" ", args2);
            Log("  exec: \"" + settings.HDHRPath + "\" " + tune.Arguments);
            using (Process process2 = Process.Start(tune))
            {
                using (StreamReader reader = process2.StandardOutput)
                {
                    string result = "";
                    while ((result = reader.ReadLine()) != null)
                    {
                        Log(result);
                    }
                }
            }

            ///tuner0/target rtp://192.168.1.6:5000
            string[] args4 = { device, "set", "/tuner" + tuner + "/target", "rtp://" + GetLocalIP() + ":500" + tuner };
            tune.Arguments = String.Join(" ", args4);
            Log("  exec: \"" + settings.HDHRPath + "\" " + tune.Arguments);
            using (Process process4 = Process.Start(tune))
            {
                using (StreamReader reader = process4.StandardOutput)
                {
                    string result = "";
                    while ((result = reader.ReadLine()) != null)
                    {
                        Log(result);
                    }
                }
            }

            if (popup)
            {
                ProcessStartInfo vlc = new ProcessStartInfo();
                vlc.FileName = @"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe";
                tune.UseShellExecute = false;
                tune.RedirectStandardOutput = true;
                string[] args5 = { "-vvv", "rtp://" + GetLocalIP() + ":500" + tuner };
                vlc.Arguments = String.Join(" ", args5);
                Log("  exec: \"" + vlc.FileName + "\" " + vlc.Arguments);
                Process process = Process.Start(vlc);
            }
        }

        private void previewChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = channelList.SelectedItems[0];
                if (item == null)
                    return;
                splitContainer2.Panel2Collapsed = false;
                //vlcControl1.Stop();
                Channel c = (Channel)item.Tag;
                TuneToChannel(c);
                if (vlcControl1.Media != null) vlcControl1.Media.Dispose();
                MediaBase media = new PathMedia(string.Format("rtp://@{0}", GetLocalIP() + ":500" + tuner));
                vlcControl1.Media = media;
                vlcControl1.Play();
            }
            catch (Exception ex)
            {
                Log("Failed to start internal preview for the channel: " + ex.Message);
            }
        }

        private void previewChannelexternalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = channelList.SelectedItems[0];
                if (item == null)
                    return;
                splitContainer2.Panel2Collapsed = true;
                Channel c = (Channel)item.Tag;
                TuneToChannel(c, true);
            }
            catch (Exception ex)
            {
                Log("Failed to start external preview for the channel: " + ex.Message);
            }
        }
    }
}

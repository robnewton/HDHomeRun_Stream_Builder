using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HDHomerun_Stream_Builder
{
    public partial class SettingsDlg : Form
    {
        Settings Settings = new Settings();
        public SettingsDlg(Settings inbound)
        {
            InitializeComponent();

            Settings = inbound;
            if (!Utils.Empty(Settings.HDHRPath))
                hdhrInstallPath.Text = Settings.HDHRPath;
            else
                hdhrInstallPath.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + @"\Silicondust\HDHomeRun\hdhomerun_config.exe";

            if (!Utils.Empty(Settings.MC2XMLPath))
                mc2xmlInstallPath.Text = Settings.MC2XMLPath;
            else
                mc2xmlInstallPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (!Utils.Empty(Settings.TVGuidePath))
                tvguideInstallPath.Text = Settings.TVGuidePath;
            else
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\XBMC\userdata\addon_data\script.tvguide\source.db";
                if (new FileInfo(path).Exists)
                    tvguideInstallPath.Text = path;
                else
                    tvguideInstallPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }

            if (!Utils.Empty(Settings.StrmFilePath))
                strmFileDirectory.Text = Settings.StrmFilePath;
            else
                strmFileDirectory.Text = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)).Parent.FullName;

            if (!Utils.Empty(Settings.PseudoTVSettingsPath))
                pseudotvSettingsPath.Text = Settings.PseudoTVSettingsPath;
            else
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\XBMC\userdata\addon_data\script.pseudotv\settings2.xml";
                if (new FileInfo(path).Exists)
                    pseudotvSettingsPath.Text = path;
                else
                    pseudotvSettingsPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }

            ignoreAllEncrypted.Checked = Settings.IgnoreAllEncrypted;
            ignoreZeroProgram.Checked = Settings.IgnoreZeroProgram;
        }

        public string HDHRInstallPath
        {
            get
            {
                return hdhrInstallPath.Text;
            }
            private set { }
        }


        public string MC2XMLInstallPath
        {
            get
            {
                return mc2xmlInstallPath.Text;
            }
            private set { }
        }


        public string TVGuideInstallPath
        {
            get
            {
                return tvguideInstallPath.Text;
            }
            private set { }
        }


        public string StrmFilePath
        {
            get
            {
                return strmFileDirectory.Text;
            }
            private set { }
        }


        public string PseudoTVSettingsPath
        {
            get
            {
                return pseudotvSettingsPath.Text;
            }
            private set { }
        }


        public bool IgnoreAllEncrypted
        {
            get
            {
                return ignoreAllEncrypted.Checked;
            }
            private set { }
        }


        public bool IgnoreZeroProgram
        {
            get
            {
                return ignoreZeroProgram.Checked;
            }
            private set { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = new FileInfo(hdhrInstallPath.Text).DirectoryName;
            }
            catch (Exception) { }
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                hdhrInstallPath.Text = openFileDialog1.FileName; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = new FileInfo(mc2xmlInstallPath.Text).DirectoryName;
            }
            catch (Exception) { }
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                mc2xmlInstallPath.Text = openFileDialog1.FileName; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = new FileInfo(tvguideInstallPath.Text).DirectoryName;
            }
            catch (Exception ex) { }
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                tvguideInstallPath.Text = openFileDialog1.FileName; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog1.SelectedPath = new FileInfo(strmFileDirectory.Text + "\\").DirectoryName;
            }
            catch (Exception ex) { }
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
                strmFileDirectory.Text = folderBrowserDialog1.SelectedPath; 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = new FileInfo(pseudotvSettingsPath.Text).DirectoryName;
            }
            catch (Exception ex) { }
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                pseudotvSettingsPath.Text = openFileDialog1.FileName; 
        }
    }
}

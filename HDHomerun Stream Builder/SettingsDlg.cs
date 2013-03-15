using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ManagedUPnP;

namespace HDHomerun_Stream_Builder
{
    public partial class SettingsDlg : Form
    {
        /// <summary>
        /// Handles discovery of the services.
        /// </summary>
        private AutoEventedDiscoveryServices<Service> mdsServices;

        HashSet<String> ldDevices = new HashSet<String>();

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

            if (!Utils.Empty(Settings.HDHRDMS))
                hdhrDmsDevice.Text = Settings.HDHRDMS;
            else
            {
                hdhrDmsDevice.Text = "";
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

        public string HDHRDMS
        {
            get
            {
                return hdhrDmsDevice.Text;
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

        private void button6_Click(object sender, EventArgs e)
        {
            ldDevices = new HashSet<String>();

            // Create discovery for all service and device types
            mdsServices = new AutoEventedDiscoveryServices<Service>(null);

            // Try to resolve network interfaces if OS supports it
            mdsServices.ResolveNetworkInterfaces = true;

            // Assign events
            mdsServices.CanCreateServiceFor += new AutoEventedDiscoveryServices<Service>.
                CanCreateServiceForEventHandler(dsServices_CanCreateServiceFor);

            mdsServices.CreateServiceFor += new AutoEventedDiscoveryServices<Service>.
                CreateServiceForEventHandler(dsServices_CreateServiceFor);

            mdsServices.StatusNotifyAction += new AutoEventedDiscoveryServices<Service>.
                StatusNotifyActionEventHandler(dsServices_StatusNotifyAction);

            ManagedUPnP.WindowsFirewall.CheckUPnPFirewallRules(null);

            // Start async discovery
            mdsServices.ReStartAsync();
        }

        /// <summary>
        /// Occurs when the discovery object needs to determine if an auto service can be created.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="a">The event arguments.</param>
        private void dsServices_CanCreateServiceFor(object sender, AutoEventedDiscoveryServices<Service>.CanCreateServiceForEventArgs a)
        {
            a.CanCreate = true;
        }

        /// <summary>
        /// Occurs when the discovery object wants a new auto service created.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="a">The event arguments.</param>
        private void dsServices_CreateServiceFor(object sender, AutoEventedDiscoveryServices<Service>.CreateServiceForEventArgs a)
        {
            a.CreatedAutoService = a.Service;
        }

        /// <summary>
        /// Occurs when a notify action occurs for the dicovery object.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="a">The event arguments.</param>
        private void dsServices_StatusNotifyAction(object sender, AutoEventedDiscoveryServices<Service>.StatusNotifyActionEventArgs a)
        {
            switch (a.NotifyAction)
            {
                case AutoDiscoveryServices<Service>.NotifyAction.ServiceAdded:
                    // A new service was found, add it
                    Service s = (Service)(a.Data);
                    if (ldDevices.Add(s.Device.UniqueDeviceName))
                    {
                        hdhrDmsDevice.Items.Add(s.Device.FriendlyName + "|" + s.Device.UniqueDeviceName.Replace("uuid:",""));
                    }
                    break;
            }
        }
    }
}

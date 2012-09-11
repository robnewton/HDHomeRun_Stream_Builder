namespace HDHomerun_Stream_Builder
{
    partial class Main
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Channel Name Here",
            "ID Here",
            "True",
            "URL Here"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.channelList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewChannelexternalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tuner_cb = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.device_tb = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelProcessButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamFilesstrmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.xmlTVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeFavoriteChannelsFilechlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildXMLTVFileForFavoritesOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tVGuideAddonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rewriteChannelStreamPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshChannelDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanFromScanOutputTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearChannelsAndCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanForBroadcastingChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.log = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // channelList
            // 
            this.channelList.CheckBoxes = true;
            this.channelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader2});
            this.channelList.ContextMenuStrip = this.contextMenuStrip1;
            this.channelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channelList.FullRowSelect = true;
            listViewItem1.StateImageIndex = 0;
            this.channelList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.channelList.Location = new System.Drawing.Point(0, 0);
            this.channelList.Name = "channelList";
            this.channelList.Size = new System.Drawing.Size(275, 325);
            this.channelList.TabIndex = 0;
            this.channelList.UseCompatibleStateImageBehavior = false;
            this.channelList.View = System.Windows.Forms.View.Details;
            this.channelList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.channelList_ItemChecked);
            this.channelList.SelectedIndexChanged += new System.EventHandler(this.channelList_SelectedIndexChanged);
            this.channelList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.channelList_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Channel";
            this.columnHeader1.Width = 256;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            this.columnHeader3.Width = 132;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Broadcasting";
            this.columnHeader4.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stream URL";
            this.columnHeader2.Width = 700;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkSelectionToolStripMenuItem,
            this.uncheckSelectionToolStripMenuItem,
            this.modifyChannelToolStripMenuItem,
            this.previewChannelToolStripMenuItem,
            this.previewChannelexternalToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 114);
            // 
            // checkSelectionToolStripMenuItem
            // 
            this.checkSelectionToolStripMenuItem.Name = "checkSelectionToolStripMenuItem";
            this.checkSelectionToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.checkSelectionToolStripMenuItem.Text = "Check Selection";
            this.checkSelectionToolStripMenuItem.Click += new System.EventHandler(this.checkSelectionToolStripMenuItem_Click);
            // 
            // uncheckSelectionToolStripMenuItem
            // 
            this.uncheckSelectionToolStripMenuItem.Name = "uncheckSelectionToolStripMenuItem";
            this.uncheckSelectionToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.uncheckSelectionToolStripMenuItem.Text = "Uncheck Selection";
            this.uncheckSelectionToolStripMenuItem.Click += new System.EventHandler(this.uncheckSelectionToolStripMenuItem_Click);
            // 
            // modifyChannelToolStripMenuItem
            // 
            this.modifyChannelToolStripMenuItem.Name = "modifyChannelToolStripMenuItem";
            this.modifyChannelToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.modifyChannelToolStripMenuItem.Text = "Modify Channel";
            this.modifyChannelToolStripMenuItem.Click += new System.EventHandler(this.modifyChannelToolStripMenuItem_Click);
            // 
            // previewChannelToolStripMenuItem
            // 
            this.previewChannelToolStripMenuItem.Name = "previewChannelToolStripMenuItem";
            this.previewChannelToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.previewChannelToolStripMenuItem.Text = "Preview Channel (internal)";
            this.previewChannelToolStripMenuItem.Click += new System.EventHandler(this.previewChannelToolStripMenuItem_Click);
            // 
            // previewChannelexternalToolStripMenuItem
            // 
            this.previewChannelexternalToolStripMenuItem.Name = "previewChannelexternalToolStripMenuItem";
            this.previewChannelexternalToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.previewChannelexternalToolStripMenuItem.Text = "Preview Channel (external)";
            this.previewChannelexternalToolStripMenuItem.Click += new System.EventHandler(this.previewChannelexternalToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.tuner_cb,
            this.toolStripLabel1,
            this.toolStripButton2,
            this.toolStripSeparator4,
            this.device_tb,
            this.toolStripLabel2,
            this.toolStripSeparator5,
            this.toolStripButton4,
            this.toolStripSeparator6,
            this.cancelProcessButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(869, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton1.Text = "HD";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton3.Text = "Preview";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tuner_cb
            // 
            this.tuner_cb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tuner_cb.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.tuner_cb.Name = "tuner_cb";
            this.tuner_cb.Size = new System.Drawing.Size(75, 25);
            this.tuner_cb.Text = "0";
            this.tuner_cb.TextChanged += new System.EventHandler(this.tuner_cb_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel1.Text = "Tuner:";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton2.Text = "Range";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // device_tb
            // 
            this.device_tb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.device_tb.Name = "device_tb";
            this.device_tb.Size = new System.Drawing.Size(100, 25);
            this.device_tb.Text = "1314D5C5";
            this.device_tb.TextChanged += new System.EventHandler(this.device_tb_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel2.Text = "Device";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(96, 22);
            this.toolStripButton4.Text = "Broadcasting";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click_1);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // cancelProcessButton
            // 
            this.cancelProcessButton.Enabled = false;
            this.cancelProcessButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelProcessButton.Image")));
            this.cancelProcessButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelProcessButton.Name = "cancelProcessButton";
            this.cancelProcessButton.Size = new System.Drawing.Size(106, 22);
            this.cancelProcessButton.Text = "Cancel Process";
            this.cancelProcessButton.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(135, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.streamFilesstrmToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exportToolStripMenuItem.Text = "&Export";
            // 
            // streamFilesstrmToolStripMenuItem
            // 
            this.streamFilesstrmToolStripMenuItem.Name = "streamFilesstrmToolStripMenuItem";
            this.streamFilesstrmToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.streamFilesstrmToolStripMenuItem.Text = "Stream Files (*.strm)";
            this.streamFilesstrmToolStripMenuItem.Click += new System.EventHandler(this.exportToStrmToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanChannelsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.xmlTVToolStripMenuItem,
            this.tVGuideAddonToolStripMenuItem,
            this.toolStripMenuItem3,
            this.advancedToolStripMenuItem,
            this.toolStripMenuItem4,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // scanChannelsToolStripMenuItem
            // 
            this.scanChannelsToolStripMenuItem.Name = "scanChannelsToolStripMenuItem";
            this.scanChannelsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.scanChannelsToolStripMenuItem.Text = "Scan Channels";
            this.scanChannelsToolStripMenuItem.Click += new System.EventHandler(this.scanChannelsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 6);
            // 
            // xmlTVToolStripMenuItem
            // 
            this.xmlTVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeFavoriteChannelsFilechlToolStripMenuItem,
            this.buildXMLTVFileForFavoritesOnlyToolStripMenuItem});
            this.xmlTVToolStripMenuItem.Name = "xmlTVToolStripMenuItem";
            this.xmlTVToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.xmlTVToolStripMenuItem.Text = "XMLTV";
            // 
            // writeFavoriteChannelsFilechlToolStripMenuItem
            // 
            this.writeFavoriteChannelsFilechlToolStripMenuItem.Name = "writeFavoriteChannelsFilechlToolStripMenuItem";
            this.writeFavoriteChannelsFilechlToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.writeFavoriteChannelsFilechlToolStripMenuItem.Text = "Write Favorite Channels File (*.chl)";
            this.writeFavoriteChannelsFilechlToolStripMenuItem.Click += new System.EventHandler(this.writeXML2CLchlFileToolStripMenuItem_Click);
            // 
            // buildXMLTVFileForFavoritesOnlyToolStripMenuItem
            // 
            this.buildXMLTVFileForFavoritesOnlyToolStripMenuItem.Name = "buildXMLTVFileForFavoritesOnlyToolStripMenuItem";
            this.buildXMLTVFileForFavoritesOnlyToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.buildXMLTVFileForFavoritesOnlyToolStripMenuItem.Text = "Build XMLTV File For Favorites Only";
            this.buildXMLTVFileForFavoritesOnlyToolStripMenuItem.Click += new System.EventHandler(this.buildXMLTVFileToolStripMenuItem_Click);
            // 
            // tVGuideAddonToolStripMenuItem
            // 
            this.tVGuideAddonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rewriteChannelStreamPathsToolStripMenuItem});
            this.tVGuideAddonToolStripMenuItem.Name = "tVGuideAddonToolStripMenuItem";
            this.tVGuideAddonToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.tVGuideAddonToolStripMenuItem.Text = "TVGuide Addon";
            // 
            // rewriteChannelStreamPathsToolStripMenuItem
            // 
            this.rewriteChannelStreamPathsToolStripMenuItem.Name = "rewriteChannelStreamPathsToolStripMenuItem";
            this.rewriteChannelStreamPathsToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.rewriteChannelStreamPathsToolStripMenuItem.Text = "Configure Using Favorite Channels";
            this.rewriteChannelStreamPathsToolStripMenuItem.Click += new System.EventHandler(this.updateTVGuideAddonStreamsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(155, 6);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshChannelDataToolStripMenuItem,
            this.scanFromScanOutputTXTToolStripMenuItem,
            this.addAChannelToolStripMenuItem,
            this.clearChannelsAndCacheToolStripMenuItem,
            this.scanForBroadcastingChannelsToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // refreshChannelDataToolStripMenuItem
            // 
            this.refreshChannelDataToolStripMenuItem.Name = "refreshChannelDataToolStripMenuItem";
            this.refreshChannelDataToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.refreshChannelDataToolStripMenuItem.Text = "Refresh Channel Data";
            this.refreshChannelDataToolStripMenuItem.ToolTipText = "Not a rescan, but remerge the data from XMLTV";
            this.refreshChannelDataToolStripMenuItem.Click += new System.EventHandler(this.refreshChannelDataToolStripMenuItem_Click);
            // 
            // scanFromScanOutputTXTToolStripMenuItem
            // 
            this.scanFromScanOutputTXTToolStripMenuItem.Name = "scanFromScanOutputTXTToolStripMenuItem";
            this.scanFromScanOutputTXTToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.scanFromScanOutputTXTToolStripMenuItem.Text = "Scan Channels From Output TXT";
            this.scanFromScanOutputTXTToolStripMenuItem.Click += new System.EventHandler(this.scanFromScanOutputTXTToolStripMenuItem_Click);
            // 
            // addAChannelToolStripMenuItem
            // 
            this.addAChannelToolStripMenuItem.Name = "addAChannelToolStripMenuItem";
            this.addAChannelToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.addAChannelToolStripMenuItem.Text = "Add a Channel Manually";
            this.addAChannelToolStripMenuItem.Click += new System.EventHandler(this.addAChannelToolStripMenuItem_Click);
            // 
            // clearChannelsAndCacheToolStripMenuItem
            // 
            this.clearChannelsAndCacheToolStripMenuItem.Name = "clearChannelsAndCacheToolStripMenuItem";
            this.clearChannelsAndCacheToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.clearChannelsAndCacheToolStripMenuItem.Text = "Clear Channels and Cache";
            this.clearChannelsAndCacheToolStripMenuItem.Click += new System.EventHandler(this.clearChannelsAndCacheToolStripMenuItem_Click);
            // 
            // scanForBroadcastingChannelsToolStripMenuItem
            // 
            this.scanForBroadcastingChannelsToolStripMenuItem.Name = "scanForBroadcastingChannelsToolStripMenuItem";
            this.scanForBroadcastingChannelsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.scanForBroadcastingChannelsToolStripMenuItem.Text = "Scan for Broadcasting Channels";
            this.scanForBroadcastingChannelsToolStripMenuItem.Click += new System.EventHandler(this.scanForBroadcastingChannelsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(155, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.optionsToolStripMenuItem.Text = "Settings";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.Location = new System.Drawing.Point(0, 0);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(869, 132);
            this.log.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.log);
            this.splitContainer1.Size = new System.Drawing.Size(869, 461);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.channelList);
            this.splitContainer2.Panel1MinSize = 275;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.vlcControl1);
            this.splitContainer2.Size = new System.Drawing.Size(869, 325);
            this.splitContainer2.SplitterDistance = 275;
            this.splitContainer2.TabIndex = 1;
            // 
            // vlcControl1
            // 
            this.vlcControl1.BackColor = System.Drawing.SystemColors.ControlText;
            this.vlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl1.Location = new System.Drawing.Point(0, 0);
            this.vlcControl1.Name = "vlcControl1";
            this.vlcControl1.Rate = 0F;
            this.vlcControl1.Size = new System.Drawing.Size(590, 325);
            this.vlcControl1.TabIndex = 0;
            this.vlcControl1.Text = "vlcControl1";
            this.vlcControl1.Playing += new Vlc.DotNet.Core.VlcEventHandler<Vlc.DotNet.Forms.VlcControl, System.EventArgs>(this.vlcControl1_Playing);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.StatusMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 510);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(869, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // StatusMessage
            // 
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 532);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "HDHomerun Stream Builder";
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView channelList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem scanChannelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripComboBox tuner_cb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem checkSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamFilesstrmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xmlTVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeFavoriteChannelsFilechlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildXMLTVFileForFavoritesOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tVGuideAddonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewriteChannelStreamPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshChannelDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem scanFromScanOutputTXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearChannelsAndCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox device_tb;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripMenuItem modifyChannelToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem previewChannelToolStripMenuItem;
        private Vlc.DotNet.Forms.VlcControl vlcControl1;
        private System.Windows.Forms.ToolStripMenuItem previewChannelexternalToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem scanForBroadcastingChannelsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel StatusMessage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton cancelProcessButton;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}


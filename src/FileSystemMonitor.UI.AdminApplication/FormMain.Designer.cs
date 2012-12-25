namespace FileSystemMonitor.UI.AdminApplication
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveProfileAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbMain = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridTraces = new System.Windows.Forms.DataGridView();
            this.colTraceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTraceState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTraceFolderCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTraceEventCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsTraceGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsExistingTrace = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblDefinedTraces = new System.Windows.Forms.Label();
            this.gridTraceFolders = new System.Windows.Forms.DataGridView();
            this.colFolderIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.colFolderPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolderIncludeSubfolders = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsFolderGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsExistingFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblTracedFolders = new System.Windows.Forms.Label();
            this.gridEvents = new System.Windows.Forms.DataGridView();
            this.colEventIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEventLog = new System.Windows.Forms.Label();
            this.dlgFolderPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.cmsTraceGridAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExistingTraceAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExistingTraceDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExistingTraceStart = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExistingTraceStop = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFolderGridAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExistingFolderAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExistingFolderRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNewProfile = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenProfile = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveProfile = new System.Windows.Forms.ToolStripButton();
            this.tsbExportToWord = new System.Windows.Forms.ToolStripButton();
            this.tsbExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbRefreshEventGrid = new System.Windows.Forms.ToolStripButton();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.menuFileNewProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpenProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsExportToText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsRefreshLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsStartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsStopServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsDatabaseCleanup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTraces)).BeginInit();
            this.cmsTraceGrid.SuspendLayout();
            this.cmsExistingTrace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTraceFolders)).BeginInit();
            this.cmsFolderGrid.SuspendLayout();
            this.cmsExistingFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTools,
            this.menuHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(856, 24);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNewProfile,
            this.menuFileOpenProfile,
            this.menuFileSaveProfile,
            this.menuFileSaveProfileAs,
            this.menuFileSeparator,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileSaveProfileAs
            // 
            this.menuFileSaveProfileAs.Name = "menuFileSaveProfileAs";
            this.menuFileSaveProfileAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.menuFileSaveProfileAs.Size = new System.Drawing.Size(236, 22);
            this.menuFileSaveProfileAs.Text = "Save profile as...";
            this.menuFileSaveProfileAs.Click += new System.EventHandler(this.menuFileSaveProfileAs_Click);
            // 
            // menuFileSeparator
            // 
            this.menuFileSeparator.Name = "menuFileSeparator";
            this.menuFileSeparator.Size = new System.Drawing.Size(233, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuFileExit.Size = new System.Drawing.Size(236, 22);
            this.menuFileExit.Text = "Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolsExportToText,
            this.menuToolsExportToExcel,
            this.toolStripMenuItem1,
            this.menuToolsRefreshLog,
            this.menuToolsStartServer,
            this.menuToolsStopServer,
            this.menuToolsDatabaseCleanup,
            this.toolStripMenuItem2,
            this.menuToolsOptions});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(44, 20);
            this.menuTools.Text = "Tools";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(241, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(241, 6);
            this.toolStripMenuItem2.Visible = false;
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(40, 20);
            this.menuHelp.Text = "Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(126, 22);
            this.menuHelpAbout.Text = "About...";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // tsMain
            // 
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewProfile,
            this.tsbOpenProfile,
            this.tsbSaveProfile,
            this.tsSeparator1,
            this.tsbExportToWord,
            this.tsbExportToExcel,
            this.tsSeparator2,
            this.tsbRefreshEventGrid,
            this.tsbOptions});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.tsMain.Size = new System.Drawing.Size(856, 25);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsSeparator2
            // 
            this.tsSeparator2.Name = "tsSeparator2";
            this.tsSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // sbMain
            // 
            this.sbMain.Location = new System.Drawing.Point(0, 570);
            this.sbMain.Name = "sbMain";
            this.sbMain.Size = new System.Drawing.Size(856, 22);
            this.sbMain.TabIndex = 3;
            this.sbMain.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridEvents);
            this.splitContainer1.Panel2.Controls.Add(this.lblEventLog);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.splitContainer1.Size = new System.Drawing.Size(856, 521);
            this.splitContainer1.SplitterDistance = 382;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridTraces);
            this.splitContainer2.Panel1.Controls.Add(this.lblDefinedTraces);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(1, 5, 1, 1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridTraceFolders);
            this.splitContainer2.Panel2.Controls.Add(this.lblTracedFolders);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(1, 5, 1, 1);
            this.splitContainer2.Size = new System.Drawing.Size(382, 521);
            this.splitContainer2.SplitterDistance = 191;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridTraces
            // 
            this.gridTraces.AllowUserToAddRows = false;
            this.gridTraces.AllowUserToDeleteRows = false;
            this.gridTraces.AllowUserToResizeRows = false;
            this.gridTraces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTraces.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.gridTraces.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTraces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTraces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTraceName,
            this.colTraceState,
            this.colTraceFolderCount,
            this.colTraceEventCount});
            this.gridTraces.ContextMenuStrip = this.cmsTraceGrid;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTraces.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridTraces.Location = new System.Drawing.Point(4, 21);
            this.gridTraces.MultiSelect = false;
            this.gridTraces.Name = "gridTraces";
            this.gridTraces.RowHeadersVisible = false;
            this.gridTraces.RowTemplate.ContextMenuStrip = this.cmsExistingTrace;
            this.gridTraces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTraces.Size = new System.Drawing.Size(370, 162);
            this.gridTraces.TabIndex = 1;
            this.gridTraces.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTraces_CellValueChanged);
            this.gridTraces.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridTraces_CellMouseDown);
            this.gridTraces.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTraces_CellEndEdit);
            this.gridTraces.SelectionChanged += new System.EventHandler(this.gridTraces_SelectionChanged);
            // 
            // colTraceName
            // 
            this.colTraceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colTraceName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTraceName.FillWeight = 50F;
            this.colTraceName.HeaderText = "Name";
            this.colTraceName.Name = "colTraceName";
            // 
            // colTraceState
            // 
            this.colTraceState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colTraceState.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTraceState.FillWeight = 20F;
            this.colTraceState.HeaderText = "State";
            this.colTraceState.Name = "colTraceState";
            this.colTraceState.Width = 75;
            // 
            // colTraceFolderCount
            // 
            this.colTraceFolderCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTraceFolderCount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTraceFolderCount.FillWeight = 15F;
            this.colTraceFolderCount.HeaderText = "Folders";
            this.colTraceFolderCount.Name = "colTraceFolderCount";
            this.colTraceFolderCount.Width = 56;
            // 
            // colTraceEventCount
            // 
            this.colTraceEventCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTraceEventCount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTraceEventCount.FillWeight = 15F;
            this.colTraceEventCount.HeaderText = "Events";
            this.colTraceEventCount.Name = "colTraceEventCount";
            this.colTraceEventCount.Width = 56;
            // 
            // cmsTraceGrid
            // 
            this.cmsTraceGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsTraceGridAdd});
            this.cmsTraceGrid.Name = "cmsExistingTrace";
            this.cmsTraceGrid.Size = new System.Drawing.Size(156, 26);
            // 
            // cmsExistingTrace
            // 
            this.cmsExistingTrace.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsExistingTraceAdd,
            this.cmsExistingTraceDelete,
            this.cmsExistingTraceStart,
            this.cmsExistingTraceStop});
            this.cmsExistingTrace.Name = "cmsExistingTrace";
            this.cmsExistingTrace.Size = new System.Drawing.Size(156, 92);
            // 
            // lblDefinedTraces
            // 
            this.lblDefinedTraces.AutoSize = true;
            this.lblDefinedTraces.Location = new System.Drawing.Point(4, 5);
            this.lblDefinedTraces.Name = "lblDefinedTraces";
            this.lblDefinedTraces.Size = new System.Drawing.Size(81, 13);
            this.lblDefinedTraces.TabIndex = 0;
            this.lblDefinedTraces.Text = "Defined traces:";
            // 
            // gridTraceFolders
            // 
            this.gridTraceFolders.AllowUserToAddRows = false;
            this.gridTraceFolders.AllowUserToDeleteRows = false;
            this.gridTraceFolders.AllowUserToResizeRows = false;
            this.gridTraceFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTraceFolders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.gridTraceFolders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTraceFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTraceFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFolderIcon,
            this.colFolderPath,
            this.colFolderIncludeSubfolders});
            this.gridTraceFolders.ContextMenuStrip = this.cmsFolderGrid;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTraceFolders.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridTraceFolders.Location = new System.Drawing.Point(4, 20);
            this.gridTraceFolders.MultiSelect = false;
            this.gridTraceFolders.Name = "gridTraceFolders";
            this.gridTraceFolders.RowHeadersVisible = false;
            this.gridTraceFolders.RowTemplate.ContextMenuStrip = this.cmsExistingFolder;
            this.gridTraceFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTraceFolders.Size = new System.Drawing.Size(370, 298);
            this.gridTraceFolders.TabIndex = 2;
            this.gridTraceFolders.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridTraceFolders_CellMouseDown);
            // 
            // colFolderIcon
            // 
            this.colFolderIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFolderIcon.FillWeight = 5F;
            this.colFolderIcon.HeaderText = " ";
            this.colFolderIcon.Name = "colFolderIcon";
            this.colFolderIcon.ReadOnly = true;
            this.colFolderIcon.Width = 25;
            // 
            // colFolderPath
            // 
            this.colFolderPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFolderPath.HeaderText = "Path";
            this.colFolderPath.Name = "colFolderPath";
            this.colFolderPath.ReadOnly = true;
            // 
            // colFolderIncludeSubfolders
            // 
            this.colFolderIncludeSubfolders.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFolderIncludeSubfolders.FillWeight = 20F;
            this.colFolderIncludeSubfolders.HeaderText = "Subfolders";
            this.colFolderIncludeSubfolders.Name = "colFolderIncludeSubfolders";
            this.colFolderIncludeSubfolders.ReadOnly = true;
            this.colFolderIncludeSubfolders.Width = 75;
            // 
            // cmsFolderGrid
            // 
            this.cmsFolderGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsFolderGridAdd});
            this.cmsFolderGrid.Name = "cmsExistingTrace";
            this.cmsFolderGrid.Size = new System.Drawing.Size(136, 26);
            this.cmsFolderGrid.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFolderGrid_Opening);
            // 
            // cmsExistingFolder
            // 
            this.cmsExistingFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsExistingFolderAdd,
            this.cmsExistingFolderRemove});
            this.cmsExistingFolder.Name = "cmsExistingTrace";
            this.cmsExistingFolder.Size = new System.Drawing.Size(156, 48);
            this.cmsExistingFolder.Opening += new System.ComponentModel.CancelEventHandler(this.cmsExistingFolder_Opening);
            // 
            // lblTracedFolders
            // 
            this.lblTracedFolders.AutoSize = true;
            this.lblTracedFolders.Location = new System.Drawing.Point(4, 5);
            this.lblTracedFolders.Name = "lblTracedFolders";
            this.lblTracedFolders.Size = new System.Drawing.Size(80, 13);
            this.lblTracedFolders.TabIndex = 2;
            this.lblTracedFolders.Text = "Traced folders:";
            // 
            // gridEvents
            // 
            this.gridEvents.AllowUserToAddRows = false;
            this.gridEvents.AllowUserToDeleteRows = false;
            this.gridEvents.AllowUserToResizeRows = false;
            this.gridEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEvents.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.gridEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEventIcon,
            this.colEventDate,
            this.colEventType,
            this.colEventFileName});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridEvents.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridEvents.Location = new System.Drawing.Point(4, 21);
            this.gridEvents.MultiSelect = false;
            this.gridEvents.Name = "gridEvents";
            this.gridEvents.ReadOnly = true;
            this.gridEvents.RowHeadersVisible = false;
            this.gridEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEvents.Size = new System.Drawing.Size(458, 492);
            this.gridEvents.TabIndex = 0;
            // 
            // colEventIcon
            // 
            this.colEventIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEventIcon.HeaderText = " ";
            this.colEventIcon.Name = "colEventIcon";
            this.colEventIcon.ReadOnly = true;
            this.colEventIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEventIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEventIcon.Width = 25;
            // 
            // colEventDate
            // 
            this.colEventDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEventDate.HeaderText = "Date";
            this.colEventDate.Name = "colEventDate";
            this.colEventDate.ReadOnly = true;
            this.colEventDate.Width = 150;
            // 
            // colEventType
            // 
            this.colEventType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colEventType.DefaultCellStyle = dataGridViewCellStyle7;
            this.colEventType.HeaderText = "Event type";
            this.colEventType.Name = "colEventType";
            this.colEventType.ReadOnly = true;
            this.colEventType.Width = 85;
            // 
            // colEventFileName
            // 
            this.colEventFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEventFileName.HeaderText = "File name";
            this.colEventFileName.Name = "colEventFileName";
            this.colEventFileName.ReadOnly = true;
            // 
            // lblEventLog
            // 
            this.lblEventLog.AutoSize = true;
            this.lblEventLog.Location = new System.Drawing.Point(4, 5);
            this.lblEventLog.Name = "lblEventLog";
            this.lblEventLog.Size = new System.Drawing.Size(56, 13);
            this.lblEventLog.TabIndex = 0;
            this.lblEventLog.Text = "Event log:";
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.Filter = "FileSystemMonitor trace profiles (*.fsmprofile)|*.fsmprofile";
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.Filter = "FileSystemMonitor trace profiles (*.fsmprofile)|*.fsmprofile";
            this.dlgOpenFile.ShowReadOnly = true;
            // 
            // cmsTraceGridAdd
            // 
            this.cmsTraceGridAdd.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.RowInsertBitmap;
            this.cmsTraceGridAdd.Name = "cmsTraceGridAdd";
            this.cmsTraceGridAdd.Size = new System.Drawing.Size(155, 22);
            this.cmsTraceGridAdd.Text = "Add new trace";
            this.cmsTraceGridAdd.Click += new System.EventHandler(this.cmsTraceGridAdd_Click);
            // 
            // cmsExistingTraceAdd
            // 
            this.cmsExistingTraceAdd.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.RowInsertBitmap;
            this.cmsExistingTraceAdd.Name = "cmsExistingTraceAdd";
            this.cmsExistingTraceAdd.Size = new System.Drawing.Size(155, 22);
            this.cmsExistingTraceAdd.Text = "Add new trace";
            this.cmsExistingTraceAdd.Click += new System.EventHandler(this.cmsExistingTraceAdd_Click);
            // 
            // cmsExistingTraceDelete
            // 
            this.cmsExistingTraceDelete.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.RowDeleteBitmap;
            this.cmsExistingTraceDelete.Name = "cmsExistingTraceDelete";
            this.cmsExistingTraceDelete.Size = new System.Drawing.Size(155, 22);
            this.cmsExistingTraceDelete.Text = "Delete trace";
            this.cmsExistingTraceDelete.Click += new System.EventHandler(this.cmsExistingTraceDelete_Click);
            // 
            // cmsExistingTraceStart
            // 
            this.cmsExistingTraceStart.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.StartBitmap;
            this.cmsExistingTraceStart.Name = "cmsExistingTraceStart";
            this.cmsExistingTraceStart.Size = new System.Drawing.Size(155, 22);
            this.cmsExistingTraceStart.Text = "Start";
            this.cmsExistingTraceStart.Click += new System.EventHandler(this.cmsExistingTraceStart_Click);
            // 
            // cmsExistingTraceStop
            // 
            this.cmsExistingTraceStop.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.StopBitmap;
            this.cmsExistingTraceStop.Name = "cmsExistingTraceStop";
            this.cmsExistingTraceStop.Size = new System.Drawing.Size(155, 22);
            this.cmsExistingTraceStop.Text = "Stop";
            this.cmsExistingTraceStop.Click += new System.EventHandler(this.cmsExistingTraceStop_Click);
            // 
            // cmsFolderGridAdd
            // 
            this.cmsFolderGridAdd.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.FolderInsertBitmap;
            this.cmsFolderGridAdd.Name = "cmsFolderGridAdd";
            this.cmsFolderGridAdd.Size = new System.Drawing.Size(135, 22);
            this.cmsFolderGridAdd.Text = "Add folder";
            this.cmsFolderGridAdd.Click += new System.EventHandler(this.cmsFolderGridAdd_Click);
            // 
            // cmsExistingFolderAdd
            // 
            this.cmsExistingFolderAdd.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.FolderInsertBitmap;
            this.cmsExistingFolderAdd.Name = "cmsExistingFolderAdd";
            this.cmsExistingFolderAdd.Size = new System.Drawing.Size(155, 22);
            this.cmsExistingFolderAdd.Text = "Add folder";
            this.cmsExistingFolderAdd.Click += new System.EventHandler(this.cmsExistingFolderAdd_Click);
            // 
            // cmsExistingFolderRemove
            // 
            this.cmsExistingFolderRemove.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.FolderDeleteBitmap;
            this.cmsExistingFolderRemove.Name = "cmsExistingFolderRemove";
            this.cmsExistingFolderRemove.Size = new System.Drawing.Size(155, 22);
            this.cmsExistingFolderRemove.Text = "Remove folder";
            this.cmsExistingFolderRemove.Click += new System.EventHandler(this.cmsExistingFolderRemove_Click);
            // 
            // tsbNewProfile
            // 
            this.tsbNewProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewProfile.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.NewBitmap;
            this.tsbNewProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewProfile.Name = "tsbNewProfile";
            this.tsbNewProfile.Size = new System.Drawing.Size(23, 22);
            this.tsbNewProfile.Text = "New profile";
            this.tsbNewProfile.Click += new System.EventHandler(this.tsbNewProfile_Click);
            // 
            // tsbOpenProfile
            // 
            this.tsbOpenProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenProfile.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.OpenBitmap;
            this.tsbOpenProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenProfile.Name = "tsbOpenProfile";
            this.tsbOpenProfile.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenProfile.Text = "Open profile";
            this.tsbOpenProfile.Click += new System.EventHandler(this.tsbOpenProfile_Click);
            // 
            // tsbSaveProfile
            // 
            this.tsbSaveProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveProfile.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.SaveBitmap;
            this.tsbSaveProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveProfile.Name = "tsbSaveProfile";
            this.tsbSaveProfile.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveProfile.Text = "Save profile";
            this.tsbSaveProfile.Click += new System.EventHandler(this.tsbSaveProfile_Click);
            // 
            // tsbExportToWord
            // 
            this.tsbExportToWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportToWord.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.WordBitmap;
            this.tsbExportToWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportToWord.Name = "tsbExportToWord";
            this.tsbExportToWord.Size = new System.Drawing.Size(23, 22);
            this.tsbExportToWord.Text = "Export to Microsoft Word";
            this.tsbExportToWord.Click += new System.EventHandler(this.tsbExportToWord_Click);
            // 
            // tsbExportToExcel
            // 
            this.tsbExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportToExcel.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.ExcelBitmap;
            this.tsbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportToExcel.Name = "tsbExportToExcel";
            this.tsbExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.tsbExportToExcel.Text = "Export to Microsoft Excel";
            this.tsbExportToExcel.Click += new System.EventHandler(this.tsbExportToExcel_Click);
            // 
            // tsbRefreshEventGrid
            // 
            this.tsbRefreshEventGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshEventGrid.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.RefreshGridBitmap;
            this.tsbRefreshEventGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshEventGrid.Name = "tsbRefreshEventGrid";
            this.tsbRefreshEventGrid.Size = new System.Drawing.Size(23, 22);
            this.tsbRefreshEventGrid.Text = "Refresh data";
            this.tsbRefreshEventGrid.Click += new System.EventHandler(this.tsbRefreshEventGrid_Click);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOptions.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.OptionsBitmap;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(23, 22);
            this.tsbOptions.Text = "toolStripButton5";
            this.tsbOptions.Visible = false;
            this.tsbOptions.Click += new System.EventHandler(this.tsbOptions_Click);
            // 
            // menuFileNewProfile
            // 
            this.menuFileNewProfile.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.NewBitmap;
            this.menuFileNewProfile.Name = "menuFileNewProfile";
            this.menuFileNewProfile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuFileNewProfile.Size = new System.Drawing.Size(236, 22);
            this.menuFileNewProfile.Text = "New profile";
            this.menuFileNewProfile.Click += new System.EventHandler(this.menuFileNewProfile_Click);
            // 
            // menuFileOpenProfile
            // 
            this.menuFileOpenProfile.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.OpenBitmap;
            this.menuFileOpenProfile.Name = "menuFileOpenProfile";
            this.menuFileOpenProfile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFileOpenProfile.Size = new System.Drawing.Size(236, 22);
            this.menuFileOpenProfile.Text = "Open profile...";
            this.menuFileOpenProfile.Click += new System.EventHandler(this.menuFileOpenProfile_Click);
            // 
            // menuFileSaveProfile
            // 
            this.menuFileSaveProfile.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.SaveBitmap;
            this.menuFileSaveProfile.Name = "menuFileSaveProfile";
            this.menuFileSaveProfile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSaveProfile.Size = new System.Drawing.Size(236, 22);
            this.menuFileSaveProfile.Text = "Save profile";
            this.menuFileSaveProfile.Click += new System.EventHandler(this.menuFileSaveProfile_Click);
            // 
            // menuToolsExportToText
            // 
            this.menuToolsExportToText.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.WordBitmap;
            this.menuToolsExportToText.Name = "menuToolsExportToText";
            this.menuToolsExportToText.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuToolsExportToText.Size = new System.Drawing.Size(244, 22);
            this.menuToolsExportToText.Text = "Export to Microsoft Word";
            this.menuToolsExportToText.Click += new System.EventHandler(this.menuToolsExportToText_Click);
            // 
            // menuToolsExportToExcel
            // 
            this.menuToolsExportToExcel.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.ExcelBitmap;
            this.menuToolsExportToExcel.Name = "menuToolsExportToExcel";
            this.menuToolsExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.menuToolsExportToExcel.Size = new System.Drawing.Size(244, 22);
            this.menuToolsExportToExcel.Text = "Export to Microsoft Excel";
            this.menuToolsExportToExcel.Click += new System.EventHandler(this.menuToolsExportToExcel_Click);
            // 
            // menuToolsRefreshLog
            // 
            this.menuToolsRefreshLog.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.RefreshGridBitmap;
            this.menuToolsRefreshLog.Name = "menuToolsRefreshLog";
            this.menuToolsRefreshLog.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuToolsRefreshLog.Size = new System.Drawing.Size(244, 22);
            this.menuToolsRefreshLog.Text = "Refresh event log";
            this.menuToolsRefreshLog.Click += new System.EventHandler(this.menuToolsRefreshLog_Click);
            // 
            // menuToolsStartServer
            // 
            this.menuToolsStartServer.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.StartBitmap;
            this.menuToolsStartServer.Name = "menuToolsStartServer";
            this.menuToolsStartServer.Size = new System.Drawing.Size(244, 22);
            this.menuToolsStartServer.Text = "Start server";
            this.menuToolsStartServer.Click += new System.EventHandler(this.menuToolsStartServer_Click);
            // 
            // menuToolsStopServer
            // 
            this.menuToolsStopServer.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.StopBitmap;
            this.menuToolsStopServer.Name = "menuToolsStopServer";
            this.menuToolsStopServer.Size = new System.Drawing.Size(244, 22);
            this.menuToolsStopServer.Text = "Stop server";
            this.menuToolsStopServer.Click += new System.EventHandler(this.menuToolsStopServer_Click);
            // 
            // menuToolsDatabaseCleanup
            // 
            this.menuToolsDatabaseCleanup.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.DatabaseCleanupBitmap;
            this.menuToolsDatabaseCleanup.Name = "menuToolsDatabaseCleanup";
            this.menuToolsDatabaseCleanup.Size = new System.Drawing.Size(244, 22);
            this.menuToolsDatabaseCleanup.Text = "Database cleanup";
            this.menuToolsDatabaseCleanup.Click += new System.EventHandler(this.menuToolsDatabaseCleanup_Click);
            // 
            // menuToolsOptions
            // 
            this.menuToolsOptions.Image = global::FileSystemMonitor.UI.AdminApplication.Properties.Resources.OptionsBitmap;
            this.menuToolsOptions.Name = "menuToolsOptions";
            this.menuToolsOptions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuToolsOptions.Size = new System.Drawing.Size(244, 22);
            this.menuToolsOptions.Text = "Options...";
            this.menuToolsOptions.Visible = false;
            this.menuToolsOptions.Click += new System.EventHandler(this.menuToolsOptions_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 592);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sbMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "FormMain";
            this.Text = "File System Monitor Admin";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTraces)).EndInit();
            this.cmsTraceGrid.ResumeLayout(false);
            this.cmsExistingTrace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTraceFolders)).EndInit();
            this.cmsFolderGrid.ResumeLayout(false);
            this.cmsExistingFolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileNewProfile;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveProfile;
        private System.Windows.Forms.ToolStripSeparator menuFileSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuToolsExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem menuToolsOptions;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpenProfile;
        private System.Windows.Forms.ToolStripButton tsbNewProfile;
        private System.Windows.Forms.ToolStripButton tsbOpenProfile;
        private System.Windows.Forms.ToolStripButton tsbSaveProfile;
        private System.Windows.Forms.ToolStripButton tsbExportToExcel;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.StatusStrip sbMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblDefinedTraces;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveProfileAs;
        private System.Windows.Forms.DataGridView gridTraces;
        private System.Windows.Forms.Label lblTracedFolders;
        private System.Windows.Forms.DataGridView gridEvents;
        private System.Windows.Forms.Label lblEventLog;
        private System.Windows.Forms.DataGridView gridTraceFolders;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuToolsExportToText;
        private System.Windows.Forms.ToolStripButton tsbExportToWord;
        private System.Windows.Forms.ToolStripSeparator tsSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmsExistingTrace;
        private System.Windows.Forms.ToolStripMenuItem cmsExistingTraceAdd;
        private System.Windows.Forms.ToolStripMenuItem cmsExistingTraceDelete;
        private System.Windows.Forms.ContextMenuStrip cmsTraceGrid;
        private System.Windows.Forms.ToolStripMenuItem cmsTraceGridAdd;
        private System.Windows.Forms.ToolStripMenuItem cmsExistingTraceStart;
        private System.Windows.Forms.ToolStripMenuItem cmsExistingTraceStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraceState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraceFolderCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraceEventCount;
        private System.Windows.Forms.ContextMenuStrip cmsExistingFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsExistingFolderAdd;
        private System.Windows.Forms.ToolStripMenuItem cmsExistingFolderRemove;
        private System.Windows.Forms.ContextMenuStrip cmsFolderGrid;
        private System.Windows.Forms.ToolStripMenuItem cmsFolderGridAdd;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderPicker;
        private System.Windows.Forms.DataGridViewImageColumn colFolderIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolderPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFolderIncludeSubfolders;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuToolsDatabaseCleanup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuToolsStopServer;
        private System.Windows.Forms.ToolStripMenuItem menuToolsStartServer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton tsbRefreshEventGrid;
        private System.Windows.Forms.ToolStripMenuItem menuToolsRefreshLog;
        private System.Windows.Forms.DataGridViewImageColumn colEventIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventFileName;
    }
}


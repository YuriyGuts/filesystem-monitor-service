namespace FileSystemMonitor.UI.TrayApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.cmdIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiStartService = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiStopService = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiLaunchAdminApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrPollingInterval = new System.Windows.Forms.Timer(this.components);
            this.cmdIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdIconContextMenu
            // 
            this.cmdIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiStartService,
            this.cmiStopService,
            this.cmiLaunchAdminApplication,
            this.cmiSeparator,
            this.cmiExit});
            this.cmdIconContextMenu.Name = "cmdIconContextMenu";
            this.cmdIconContextMenu.Size = new System.Drawing.Size(205, 98);
            // 
            // cmiStartService
            // 
            this.cmiStartService.Image = global::FileSystemMonitor.UI.TrayApplication.Properties.Resources.ServiceStartBitmap;
            this.cmiStartService.Name = "cmiStartService";
            this.cmiStartService.Size = new System.Drawing.Size(204, 22);
            this.cmiStartService.Text = "Start server";
            this.cmiStartService.Click += new System.EventHandler(this.cmiStartService_Click);
            // 
            // cmiStopService
            // 
            this.cmiStopService.Image = global::FileSystemMonitor.UI.TrayApplication.Properties.Resources.ServiceStopBitmap;
            this.cmiStopService.Name = "cmiStopService";
            this.cmiStopService.Size = new System.Drawing.Size(204, 22);
            this.cmiStopService.Text = "Stop server";
            this.cmiStopService.Click += new System.EventHandler(this.cmiStopService_Click);
            // 
            // cmiLaunchAdminApplication
            // 
            this.cmiLaunchAdminApplication.Name = "cmiLaunchAdminApplication";
            this.cmiLaunchAdminApplication.Size = new System.Drawing.Size(204, 22);
            this.cmiLaunchAdminApplication.Text = "Launch admin application";
            this.cmiLaunchAdminApplication.Click += new System.EventHandler(this.cmiLaunchAdminApplication_Click);
            // 
            // cmiSeparator
            // 
            this.cmiSeparator.Name = "cmiSeparator";
            this.cmiSeparator.Size = new System.Drawing.Size(201, 6);
            // 
            // cmiExit
            // 
            this.cmiExit.Name = "cmiExit";
            this.cmiExit.Size = new System.Drawing.Size(204, 22);
            this.cmiExit.Text = "Exit";
            this.cmiExit.Click += new System.EventHandler(this.cmiExit_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.cmdIconContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "FileSystemMonitor Tray Monitor";
            this.trayIcon.Visible = true;
            // 
            // tmrPollingInterval
            // 
            this.tmrPollingInterval.Interval = 20000;
            this.tmrPollingInterval.Tick += new System.EventHandler(this.tmrPollingInterval_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 25);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.Text = "FileSystemMonitor Tray Monitor";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.cmdIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmdIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmiStartService;
        private System.Windows.Forms.ToolStripMenuItem cmiStopService;
        private System.Windows.Forms.ToolStripMenuItem cmiLaunchAdminApplication;
        private System.Windows.Forms.ToolStripSeparator cmiSeparator;
        private System.Windows.Forms.ToolStripMenuItem cmiExit;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Timer tmrPollingInterval;
    }
}


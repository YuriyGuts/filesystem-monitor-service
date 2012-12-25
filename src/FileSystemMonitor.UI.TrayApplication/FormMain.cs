using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using FileSystemMonitor.Core;
using FileSystemMonitor.Common;
using FileSystemMonitor.Common.Logging;
using FileSystemMonitor.UI.TrayApplication.Properties;

namespace FileSystemMonitor.UI.TrayApplication
{
    public partial class FormMain : Form
    {
        private ServerState currentServerState;

        public FormMain()
        {
            InitializeComponent();
            Hide();
            UpdateState(false);
            tmrPollingInterval.Interval = Settings.Default.PollingInterval * 1000;
            tmrPollingInterval.Enabled = true;
        }

        private ServerState UpdateState()
        {
            return UpdateState(true);
        }

        private ServerState UpdateState(bool displayBalloonTips)
        {
            try
            {
                if (DataProvider.Server.ServerTestProperty == null)
                {
                    throw new Exception();
                }
                cmiStartService.Enabled = false;
                cmiStopService.Enabled = true;
                trayIcon.Icon = Resources.StartedIcon;
                if (displayBalloonTips && currentServerState != ServerState.Running)
                {
                    trayIcon.ShowBalloonTip(5000, "Service started", "The File System Monitor service has been started", ToolTipIcon.Info);
                }
                currentServerState = ServerState.Running;
                return ServerState.Running;
            }
            catch (Exception)
            {
                cmiStartService.Enabled = true;
                cmiStopService.Enabled = false;
                trayIcon.Icon = Resources.StoppedIcon;
                if (displayBalloonTips && currentServerState != ServerState.Stopped)
                {
                    trayIcon.ShowBalloonTip(5000, "Service stopped", "The File System Monitor service has been stopped", ToolTipIcon.Warning);
                }
                currentServerState = ServerState.Stopped;
                return ServerState.Stopped;
            }
        }

        private void cmiStartService_Click(object sender, EventArgs e)
        {
            try
            {
                EventLogger.RecordEvent(Constants.TrayApplicationEventSource, LogEventType.Information, "Start request received. Starting the service...");
                Process.Start("net", "start fsmonsvc");
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.TrayApplicationEventSource, ex, "Failed to start the service: ");
                FormHelper.ShowErrorMessage("Failed to start the service: " + ex.Message, "Error");
            }
        }

        private void cmiStopService_Click(object sender, EventArgs e)
        {
            try
            {
                EventLogger.RecordEvent(Constants.TrayApplicationEventSource, LogEventType.Information, "Stop request received. Stopping the service...");
                Process.Start("net", "stop fsmonsvc");
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.TrayApplicationEventSource, ex, "Failed to stop the service: ");
                FormHelper.ShowErrorMessage("Failed to stop the service: " + ex.Message, "Error");
            }
        }

        private void cmiLaunchAdminApplication_Click(object sender, EventArgs e)
        {
            LaunchAdminApplication();
        }

        private void LaunchAdminApplication()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string assemblyLocation = (executingAssembly != null) ? executingAssembly.Location : null;
            if (assemblyLocation != null)
            {
                DirectoryInfo assemblyDirectoryInfo = new DirectoryInfo(assemblyLocation).Parent;
                if (assemblyDirectoryInfo != null)
                {
                    string adminApplicationExeName = string.Format(@"{0}\{1}", assemblyDirectoryInfo.FullName, Constants.AdminApplicationAssemblyName);
                    try
                    {
                        Process.Start(adminApplicationExeName);
                    }
                    catch (Exception ex)
                    {
                        EventLogger.RecordException(Constants.TrayApplicationEventSource, ex,
                            string.Format("Failed to start admin application at {0} because of:", adminApplicationExeName));
                        FormHelper.ShowErrorMessage("Failed to start admin application. The executable file has probably been deleted or damaged.", "Error");
                    }
                }
            }
        }

        private void cmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tmrPollingInterval_Tick(object sender, EventArgs e)
        {
            UpdateState();
        }
    }
}
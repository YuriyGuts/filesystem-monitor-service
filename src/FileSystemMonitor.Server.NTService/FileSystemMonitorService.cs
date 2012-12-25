using System;
using System.ServiceProcess;
using System.Threading;
using FileSystemMonitor.Common;
using FileSystemMonitor.Common.Logging;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using FileSystemMonitor.Server.NTService.Properties;
using System.Security.Principal;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using FileSystemMonitor.Core;

namespace FileSystemMonitor.Server.NTService
{
    public partial class FileSystemMonitorService : ServiceBase
    {
        private Thread workerThread;
        private volatile IpcServerChannel ipcChannel;

        public FileSystemMonitorService()
        {
            InitializeComponent();
            if (!DataProvider.IsInitialized)
            {
                DataProvider.Initialize(Settings.Default.DBConnectionString);
            }
        }

        public void ServiceEntryPoint()
        {
            try
            {
                RegisterIpcChannel();
                StartIpcChannel();

                do
                {
                    Thread.Sleep(1000);
                }
                while (true);
            }
            catch (ThreadAbortException)
            {
            }
        }

        private void RegisterIpcChannel()
        {
            const string ipcPortNameProperty = "portName";
            const string ipcAuthorizedGroupProperty = "authorizedGroup";
            const string exclusiveAddressUseProperty = "exclusiveAddressUse";

            try
            {
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Registering IPC channel...");

                SecurityIdentifier securityId = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                NTAccount ntAccount = (NTAccount)securityId.Translate(typeof(NTAccount));

                Hashtable properties = new Hashtable();
                properties[ipcPortNameProperty] = Settings.Default.IpcChannelPort;
                properties[ipcAuthorizedGroupProperty] = ntAccount.Value;
                properties[exclusiveAddressUseProperty] = false;

                BinaryServerFormatterSinkProvider serverBinarySinkProvider = new BinaryServerFormatterSinkProvider();
                serverBinarySinkProvider.TypeFilterLevel = TypeFilterLevel.Full;

                ipcChannel = new IpcServerChannel(properties, serverBinarySinkProvider);
                ChannelServices.RegisterChannel(ipcChannel, false);
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Channel registered successfully");

                RemotingConfiguration.RegisterWellKnownServiceType
                    (
                        typeof(FileSystemMonitorServer),
                        Settings.Default.ServerObjectUri,
                        WellKnownObjectMode.Singleton
                    );

                EventLogger.RecordEvent
                    (
                        Constants.NTServiceEventSource,
                        LogEventType.Information,
                        string.Format("Object '{0}' registered", Settings.Default.ServerObjectUri)
                    );
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.NTServiceEventSource, ex, "Failed to register IPC channel: ");
            }
        }

        private void UnregisterIpcChannel()
        {
            try
            {
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Unregistering IPC channel...");
                ChannelServices.UnregisterChannel(ipcChannel);
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Channel unregistered successfully");
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.NTServiceEventSource, ex, "Failed to unregister channel: ");
            }
        }

        private void StartIpcChannel()
        {
            try
            {
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Starting channel...");
                ipcChannel.StartListening(null);
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Now listening on " + ipcChannel.GetChannelUri());
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.NTServiceEventSource, ex, "Failed to start channel: ");
            }
        }

        private void StopIpcChannel()
        {
            try
            {
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Stopping channel...");
                ipcChannel.StopListening(null);
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Channel " + ipcChannel.GetChannelUri() + " stopped");
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.NTServiceEventSource, ex, "Failed to stop channel: ");
            }
        }

        protected override void OnStart(string[] args)
        {
            ThreadStart threadStart = ServiceEntryPoint;
            workerThread = new Thread(threadStart);
            workerThread.Start();

            EventLogger.RecordNonEvent(Constants.NTServiceEventSource, string.Empty.PadRight(75, '-') + Environment.NewLine);
            EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Service started");
        }

        protected override void OnStop()
        {
            EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Stop request received! Stopping the service...");
            try
            {
                if (workerThread != null)
                {
                    StopIpcChannel();
                    UnregisterIpcChannel();
                    workerThread.Abort();
                    EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Service stopped");
                }
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.NTServiceEventSource, ex, "Worker thread abort exception: ");
            }
        }

        protected override void OnPause()
        {
            EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Pause request received! Suspending the service...");
            EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Service suspended");
        }

        protected override void OnContinue()
        {
            EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Continue request received! Resuming the service...");
            EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Service resumed");
        }
    }
}

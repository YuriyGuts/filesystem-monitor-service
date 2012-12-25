namespace FileSystemMonitor.Common
{
    public static class Constants
    {
        public const string CommonLibraryEventSource = "fsmoncore";
        public const string NTServiceEventSource = "fsmonsvc";
        public const string DataAccessLayerEventSource = "fsmondal";
        public const string AdminApplicationEventSource = "fsmonadmin";
        public const string TrayApplicationEventSource = "fsmontray";

        public const string IpcProtocolPrefix = "ipc://";
        public const string IpcChannelName = "FileSystemMonitor";
        public const string IpcChannelPort = "FileSystemMonitor:9090";
        public const string ServerObjectUri = "Server.rem";

        public const string AdminApplicationAssemblyName = "fsmonadmin.exe";
    }
}

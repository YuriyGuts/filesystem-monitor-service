namespace FileSystemMonitor.Common.Interfaces
{
    public interface IFileSystemMonitorServer
    {
        FolderTraceProfile ActiveProfile { get; set; }
        ServerState State { get; }
        string ServerTestProperty { get; set; }

        void StartListening();
        void StopListening();

        void UpdateChanges();
    }
}

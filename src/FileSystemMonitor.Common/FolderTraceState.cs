using System;
namespace FileSystemMonitor.Common
{
    [Serializable]
    public enum FolderTraceState
    {
        Running = 0x01,
        Stopped = 0x02,
    }
}

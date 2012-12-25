using System;

namespace FileSystemMonitor.Common
{
    [Serializable]
    public enum ServerState
    {
        Running     = 0x01,
        Paused      = 0x02,
        Stopped     = 0x04,
    }
}

using System;
using System.Collections.Generic;

namespace FileSystemMonitor.Common
{
    [Serializable]
    public class FolderTrace
    {
        private List<FolderTraceEntry> folderTraceEntryList;
        private string name;
        private FolderTraceState state;
        private Guid guid;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public FolderTraceState State
        {
            get { return state; }
            set { state = value; }
        }

        public Guid GUID
        {
            get { return guid; }
            set { guid = value; }
        }


        public List<FolderTraceEntry> Items
        {
            get
            {
                if (folderTraceEntryList == null)
                {
                    folderTraceEntryList = new List<FolderTraceEntry>();
                }
                return folderTraceEntryList;
            }
        }

        public FolderTrace(string traceName)
            : this(traceName, FolderTraceState.Stopped)
        {
        }

        public FolderTrace(string traceName, FolderTraceState traceState)
        {
            Name = traceName;
            State = traceState;
            guid = Guid.NewGuid();
        }

        public FolderTrace(string traceName, FolderTraceState traceState, Guid traceGuid)
        {
            Name = traceName;
            State = traceState;
            guid = traceGuid;
        }
    }
}

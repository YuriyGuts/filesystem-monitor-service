using System.Collections.Generic;
using System;

namespace FileSystemMonitor.Common
{
    [Serializable]
    public class FolderTraceProfile
    {
        private List<FolderTrace> folderTraceList;

        public List<FolderTrace> Traces
        {
            get
            {
                if (folderTraceList == null)
                {
                    folderTraceList = new List<FolderTrace>();
                }
                return folderTraceList;
            }
            set
            {
                folderTraceList = value;
            }
        }
    }
}

using System;
using System.IO;
using FileSystemMonitor.Common.Logging;

namespace FileSystemMonitor.Common
{
    [Serializable]
    public class FolderTraceEntry
    {
        private string folderName;
        private DirectoryInfo folderInfo;
        private bool includeSubfolders;
        private FolderTrace owner;

        public string FolderName
        {
            get { return folderName; }
            set { folderName = value; }
        }

        public DirectoryInfo FolderInfo
        {
            get { return folderInfo; }
            set { folderInfo = value; }
        }

        public bool IncludeSubfolders
        {
            get { return includeSubfolders; }
            set { includeSubfolders = value; }
        }

        public FolderTrace Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public FolderTraceEntry(string folderName, FolderTrace owner)
            : this(folderName, owner, false)
        {
        }

        public FolderTraceEntry(string folderName, FolderTrace owner, bool includeSubfolders)
        {
            this.folderName = folderName;
            try
            {
                folderInfo = new DirectoryInfo(folderName);
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.CommonLibraryEventSource, ex);
            }
            this.owner = owner;
            this.includeSubfolders = includeSubfolders;
        }
    }
}

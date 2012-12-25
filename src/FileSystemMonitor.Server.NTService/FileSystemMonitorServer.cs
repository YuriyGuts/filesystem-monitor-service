using System;
using FileSystemMonitor.Common;
using FileSystemMonitor.Common.Interfaces;
using System.IO;
using System.Collections.Generic;
using FileSystemMonitor.Common.Logging;
using FileSystemMonitor.Core;

namespace FileSystemMonitor.Server.NTService
{
    public class FileSystemMonitorServer : MarshalByRefObject, IFileSystemMonitorServer
    {
        const string eventInsertQueryText =
            @"insert into FileSystemEvent 
                  (FolderTraceGUID, FileSystemEventType, FileSystemEventDate, FileSystemEventOldName, FileSystemEventNewName)
              values
                  (@FolderTraceGUID, @FileSystemEventType, @FileSystemEventDate, @FileSystemEventOldName, @FileSystemEventNewName)";

        private ServerState serverState;
        private FolderTraceProfile profile;

        private Dictionary<FolderTraceEntry, FileSystemWatcher> fileSystemWatcherDictionary;

        internal ServerState ServerState
        {
            get { return serverState; }
            set { serverState = value; }
        }

        public FileSystemMonitorServer()
            : this(null)
        {
        }

        private string testValue;
        public string ServerTestProperty
        {
            get { return "Test string! Previously asisgned value: " + testValue; }
            set { testValue = value; }
        }

        public FileSystemMonitorServer(FolderTraceProfile profile)
        {
            serverState = ServerState.Stopped;
            ActiveProfile = profile;
        }

        #region IFileSystemMonitorServer Members

        public FolderTraceProfile ActiveProfile
        {
            get { return profile; }
            set
            {
                profile = value;
                ResetWatchers();
            }
        }

        private void ResetWatchers()
        {
            try
            {
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Resetting watchers...");
                RemovePreviousWatchers();
                GenerateNewWatchers();
                EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, "Watcher reset completed");
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.NTServiceEventSource, ex, "Failed to reset watchers: ");
                throw;
            }
        }

        private void GenerateNewWatchers()
        {
            if (ActiveProfile != null)
            {
                foreach (FolderTrace trace in ActiveProfile.Traces)
                {
                    EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Trace, "Processing trace: " + trace.Name);
                    foreach (FolderTraceEntry traceEntry in trace.Items)
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(traceEntry.FolderName);
                        EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Trace, "Adding folder " + directoryInfo.FullName);
                        FileSystemWatcher newWatcher = new FileSystemWatcher(directoryInfo.FullName);
                        newWatcher.IncludeSubdirectories = traceEntry.IncludeSubfolders;
                        newWatcher.Renamed += Watcher_ObjectRenamed;
                        newWatcher.Created += Watcher_ObjectCreated;
                        newWatcher.Changed += Watcher_ObjectChanged;
                        newWatcher.Deleted += Watcher_ObjectDeleted;
                        fileSystemWatcherDictionary.Add(traceEntry, newWatcher);
                        newWatcher.EnableRaisingEvents = true;
                    }
                }
            }
        }

        private void RemovePreviousWatchers()
        {
            if (fileSystemWatcherDictionary != null)
            {
                foreach (FileSystemWatcher watcher in fileSystemWatcherDictionary.Values)
                {
                    watcher.EnableRaisingEvents = false;
                    watcher.Dispose();
                }
            }
            else
            {
                fileSystemWatcherDictionary = new Dictionary<FolderTraceEntry, FileSystemWatcher>();
            }
        }

        public ServerState State
        {
            get { return ServerState; }
        }

        public void StartListening()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void StopListening()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void UpdateChanges()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Events

        public event EventHandler ServerStart;
        public event EventHandler ServerStop;
        public event EventHandler ServerPause;
        public event EventHandler ServerContinue;

        public event RenamedEventHandler ObjectRenamed;
        public event FileSystemEventHandler ObjectCreated;
        public event FileSystemEventHandler ObjectChanged;
        public event FileSystemEventHandler ObjectDeleted;

        #endregion

        private Guid LookupTraceGuid(object sender)
        {
            foreach (FolderTraceEntry key in fileSystemWatcherDictionary.Keys)
            {
                if (fileSystemWatcherDictionary[key] == sender)
                {
                    return key.Owner.GUID;
                }
            }
            return Guid.Empty;
        }

        private void RegisterEvent(FileSystemEventType eventType, string oldFullPath, string newFullPath, Guid traceGuid)
        {
            try
            {
                QueryParameterSet parameters = new QueryParameterSet();
                parameters.Add("@FolderTraceGUID", traceGuid.ToString());
                parameters.Add("@FileSystemEventType", (int)eventType);
                parameters.Add("@FileSystemEventDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                parameters.Add("@FileSystemEventOldName", oldFullPath);
                parameters.Add("@FileSystemEventNewName", newFullPath);
                DataProvider.Database.Query(eventInsertQueryText, parameters, false);

                if (eventType != FileSystemEventType.Renamed)
                {
                    EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, string.Format("{0}: {1}", eventType, newFullPath));
                }
                else
                {
                    EventLogger.RecordEvent(Constants.NTServiceEventSource, LogEventType.Information, string.Format("{0}: {1} to {2}", eventType, oldFullPath, newFullPath));
                }
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.NTServiceEventSource, ex, "Failed to register event: ");
            }
        }

        #region Event handlers

        private void Watcher_ObjectRenamed(object sender, RenamedEventArgs e)
        {
            RegisterEvent(FileSystemEventType.Renamed, e.OldFullPath, e.FullPath, LookupTraceGuid(sender));
            if (ObjectRenamed != null)
            {
                ObjectRenamed(sender, e);
            }
        }

        private void Watcher_ObjectCreated(object sender, FileSystemEventArgs e)
        {
            RegisterEvent(FileSystemEventType.Created, e.FullPath, e.FullPath, LookupTraceGuid(sender));
            if (ObjectCreated != null)
            {
                ObjectCreated(sender, e);
            }
        }

        private void Watcher_ObjectChanged(object sender, FileSystemEventArgs e)
        {
            RegisterEvent(FileSystemEventType.Modified, e.FullPath, e.FullPath, LookupTraceGuid(sender));
            if (ObjectChanged != null)
            {
                ObjectChanged(sender, e);
            }
        }

        private void Watcher_ObjectDeleted(object sender, FileSystemEventArgs e)
        {
            RegisterEvent(FileSystemEventType.Deleted, e.FullPath, e.FullPath, LookupTraceGuid(sender));
            if (ObjectDeleted != null)
            {
                ObjectDeleted(sender, e);
            }
        }

        #endregion
    }
}

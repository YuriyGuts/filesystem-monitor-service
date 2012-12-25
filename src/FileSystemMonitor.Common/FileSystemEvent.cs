using System;

namespace FileSystemMonitor.Common
{
    public enum FileSystemEventType
    {
        Created = 0x01,
        Modified = 0x02,
        Deleted = 0x03,
        Renamed = 0x04,
    }

    public class FileSystemEvent
    {
        private string oldFileName;
        private string newFileName;
        private FileSystemEventType eventType;
        private DateTime eventDate;

        public string OldFileName
        {
            get { return oldFileName; }
            set { oldFileName = value; }
        }

        public string NewFileName
        {
            get { return newFileName; }
            set { newFileName = value; }
        }

        public FileSystemEventType EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; }
        }

        public FileSystemEvent(FileSystemEventType eventType, string newFileName, DateTime eventDate)
            : this(eventType, newFileName, newFileName, eventDate)
        {
        }

        public FileSystemEvent(FileSystemEventType eventType, string oldFileName, string newFileName, DateTime eventDate)
        {
            this.eventType = eventType;
            this.oldFileName = oldFileName;
            this.newFileName = newFileName;
            this.eventDate = eventDate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace FileSystemMonitor.Common.Logging
{
    public static class EventLogger
    {
        private const string fileNameFormat = "{EventSource}-{yyyy}{MM}{dd}.log";
        private const string eventDateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
        private const int eventTypeColumnWidth = 12;

        private static readonly Dictionary<string, bool> dicInitializationState = new Dictionary<string, bool>();
        private static readonly Dictionary<string, DateTime> dicLoggingDate = new Dictionary<string, DateTime>();
        private static readonly Dictionary<string, FileStream> dicLoggingStream = new Dictionary<string, FileStream>();

        private static void Initialize(string eventSource)
        {
            if (!dicInitializationState.ContainsKey(eventSource))
            {
                dicInitializationState.Add(eventSource, false);
                dicLoggingDate.Add(eventSource, DateTime.Now);
                dicLoggingStream.Add(eventSource, null);
            }

            ReopenLoggingStream(eventSource);
            dicInitializationState[eventSource] = true;
        }

        private static void ReopenLoggingStream(string eventSource)
        {
            try
            {
                if (dicLoggingStream[eventSource] != null)
                {
                    dicLoggingStream[eventSource].Close();
                    dicLoggingStream[eventSource].Dispose();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Failed to close/dispose the logging stream: {0}", ex));
            }

            try
            {
                dicLoggingStream[eventSource] = new FileStream(GetLogFileName(eventSource), FileMode.Append, FileAccess.Write);
                dicLoggingDate[eventSource] = DateTime.Now;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Failed to create the logging stream: {0}", ex));
            }
        }

        private static string GetLogFileName(string eventSource)
        {
            string logDirectory = Path.GetTempPath();

            string result = string.Format
                (
                    "{0}{1}{2}",
                    logDirectory,
                    Path.DirectorySeparatorChar,
                    fileNameFormat
                );
            DateTime now = DateTime.Now;

            result = result.Replace("{EventSource}", eventSource);
            result = result.Replace("{yyyy}", now.Year.ToString("0000"));
            result = result.Replace("{MM}", now.Month.ToString("00"));
            result = result.Replace("{dd}", now.Day.ToString("00"));

            return result;
        }

        public static void RecordEvent(string eventSource, LogEventType eventType, string eventMessage)
        {
            if (!dicInitializationState.ContainsKey(eventSource) || !dicInitializationState[eventSource])
            {
                Initialize(eventSource);
            }
            if (DateTime.Now.Day != dicLoggingDate[eventSource].Day)
            {
                ReopenLoggingStream(eventSource);
            }

            string eventTypeString = GetEventTypeString(eventType);

            try
            {
                string logEntry = string.Format
                        (
                            "{0}   [{1}]{2}{3}\r\n",
                            DateTime.Now.ToString(eventDateTimeFormat),
                            eventTypeString,
                            string.Empty.PadRight(eventTypeColumnWidth - eventTypeString.Length),
                            eventMessage
                        );

                WriteStringToLogFile(eventSource, logEntry);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Failed to record event: {0}", ex));
            }
        }

        public static void RecordNonEvent(string eventSource, string message)
        {
            if (!dicInitializationState.ContainsKey(eventSource) || !dicInitializationState[eventSource])
            {
                Initialize(eventSource);
            }
            WriteStringToLogFile(eventSource, message);
        }

        private static void WriteStringToLogFile(string eventSource, string logEntry)
        {
            byte[] bytesToWrite = Encoding.UTF8.GetBytes(logEntry);
            dicLoggingStream[eventSource].Write(bytesToWrite, 0, bytesToWrite.Length);
            dicLoggingStream[eventSource].Flush();
        }

        private static string GetEventTypeString(LogEventType eventType)
        {
            string result;
            switch (eventType)
            {
                case LogEventType.Trace:
                    result = "TRACE";
                    break;
                case LogEventType.Warning:
                    result = "WARNING";
                    break;
                case LogEventType.Error:
                    result = "ERROR";
                    break;
                case LogEventType.Exception:
                    result = "EXCEPTION";
                    break;
                default:
                    result = "INFO";
                    break;
            }
            return result;
        }

        public static void RecordException(string eventSource, Exception exception)
        {
            RecordEvent(eventSource, LogEventType.Exception, exception.ToString());
        }

        public static void RecordException(string eventSource, Exception exception, string exceptionPrefix)
        {
            RecordEvent(eventSource, LogEventType.Exception, exceptionPrefix + exception);
        }
    }
}

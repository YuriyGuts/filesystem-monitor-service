using System;
using System.Data;
using FileSystemMonitor.Common;
using FileSystemMonitor.Common.Interfaces;
using FileSystemMonitor.Data.Interfaces;
using FileSystemMonitor.Data.MSAccess;

namespace FileSystemMonitor.Core
{
    public static class DataProvider
    {
        private static bool isInitialized;
        private static IDatabase database;
        private static string dbConnectionString;

        private static IFileSystemMonitorServer server;
        public static IFileSystemMonitorServer Server
        {
            get
            {
                string objectUri = string.Format("{0}{1}/{2}", Constants.IpcProtocolPrefix, Constants.IpcChannelPort, Constants.ServerObjectUri);
                server = (IFileSystemMonitorServer)Activator.GetObject(typeof(IFileSystemMonitorServer), objectUri);
                return server;
            }
        }


        public static IDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MSAccessDatabase();
                }
                if (database.Connection == null || database.Connection.State != ConnectionState.Open)
                {
                    database.Connect(dbConnectionString);
                }
                return database;
            }
        }

        public static bool IsInitialized
        {
            get { return isInitialized; }
            set { isInitialized = value; }
        }

        static DataProvider()
        {
            database = null;
            dbConnectionString = null;
            server = null;
            IsInitialized = false;
        }

        public static void Initialize(string databaseConnectionString)
        {
            dbConnectionString = databaseConnectionString;
            IsInitialized = true;
        }
    }
}
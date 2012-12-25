using System;
using System.Data;
using System.Data.OleDb;
using FileSystemMonitor.Common;
using FileSystemMonitor.Common.Logging;
using FileSystemMonitor.Data.Interfaces;

namespace FileSystemMonitor.Data.MSAccess
{
    public class MSAccessDatabase : IDatabase
    {
        private OleDbConnection connection;

        public IDbConnection Connection
        {
            get { return connection; }
            set { connection = (OleDbConnection)value; }
        }

        public MSAccessDatabase()
        {
            connection = null;
        }

        public void Connect(string connectionString)
        {
            try
            {
                Connection = new OleDbConnection(connectionString);
                Connection.Open();
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.DataAccessLayerEventSource, ex, "DB connection error: ");
                throw;
            }
        }
        public void Disconnect()
        {
            try
            {
                (Connection).Close();
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.DataAccessLayerEventSource, ex, "DB disconnection error: ");
            }
        }
        public IQueryResult Query(string queryString, IQueryParameterSet parameterSet, bool resultRequired)
        {
            try
            {
                OleDbCommand oleDbCommand = new OleDbCommand(queryString, connection);
                if (parameterSet != null)
                {
                    foreach (string key in parameterSet.ParameterList.Keys)
                    {
                        oleDbCommand.Parameters.Add(new OleDbParameter(key, parameterSet[key]));
                    }
                }
                if (resultRequired)
                {
                    OleDbDataReader reader = oleDbCommand.ExecuteReader();
                    IQueryResult result = new QueryResult();
                    while (reader.Read())
                    {
                        IQueryResultRow resultRow = new QueryResultRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            resultRow.Columns.Add(reader.GetName(i), reader[i]);
                        }
                        result.Rows.Add(resultRow);
                    }
                    reader.Close();
                    oleDbCommand.Dispose();
                    return result;
                }

                oleDbCommand.ExecuteScalar();
                oleDbCommand.Dispose();
                return null;
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.DataAccessLayerEventSource, ex, "Query execution error: ");
                throw;
            }
        }
    }
}
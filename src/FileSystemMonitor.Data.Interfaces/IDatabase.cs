using System.Data;

namespace FileSystemMonitor.Data.Interfaces
{
    public interface IDatabase
    {
        IDbConnection Connection { get; set; }
        void Connect(string connectionString);
        void Disconnect();
        IQueryResult Query(string queryString, IQueryParameterSet parameterSet, bool resultRequired);
    }
}
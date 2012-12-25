using System.Collections.Generic;
using FileSystemMonitor.Data.Interfaces;

namespace FileSystemMonitor.Data.MSAccess
{
    /// <summary>
    /// Represents a single row in SQL query result set.
    /// </summary>
    public class QueryResultRow : IQueryResultRow
    {
        private Dictionary<string, object> columns;

        /// <summary>
        /// Gets or sets the list of columns inside this row.
        /// </summary>
        public Dictionary<string, object> Columns
        {
            get
            {
                if (columns == null)
                {
                    columns = new Dictionary<string, object>();
                }
                return columns;
            }
            set { columns = value; }
        }

        /// <summary>
        /// Gets the value of the column with the specified name.
        /// </summary>
        /// <param name="columnName">The name of the column.</param>
        /// <returns>Value of the column which has the specified name.</returns>
        public object this[string columnName]
        {
            get { return Columns[columnName]; }
            set { Columns[columnName] = value; }
        }
    }
}
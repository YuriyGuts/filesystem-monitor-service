using System.Collections.Generic;
using FileSystemMonitor.Data.Interfaces;

namespace FileSystemMonitor.Data.MSAccess
{
    /// <summary>
    /// Represents an SQL query result.
    /// </summary>
    public class QueryResult : IQueryResult
    {
        private List<IQueryResultRow> rows;

        /// <summary>
        /// Gets or sets the list of rows contained inside this QueryResult.
        /// </summary>
        public List<IQueryResultRow> Rows
        {
            get
            {
                if (rows == null)
                {
                    rows = new List<IQueryResultRow>();
                }
                return rows;
            }
            set { rows = value; }
        }

        /// <summary>
        /// Gets or sets a QueryResultRow identified by its ordinal number.
        /// </summary>
        /// <param name="rowIndex">The ordinal number of the row.</param>
        /// <returns>A QueryResultRow which has the specified index in the collection.</returns>
        public IQueryResultRow this[int rowIndex]
        {
            get { return Rows[rowIndex]; }
            set { Rows[rowIndex] = value; }
        }
    }
}
using System.Collections.Generic;

namespace FileSystemMonitor.Data.Interfaces
{
    public interface IQueryResult
    {
        /// <summary>
        /// Gets or sets the list of rows contained inside this QueryResult.
        /// </summary>
        List<IQueryResultRow> Rows { get; set; }

        /// <summary>
        /// Gets or sets a QueryResultRow identified by its ordinal number.
        /// </summary>
        /// <param name="rowIndex">The ordinal number of the row.</param>
        /// <returns>A QueryResultRow which has the specified index in the collection.</returns>
        IQueryResultRow this[int rowIndex] { get; set; }
    }
}
using System.Collections.Generic;

namespace FileSystemMonitor.Data.Interfaces
{
    public interface IQueryResultRow
    {
        /// <summary>
        /// Gets or sets the list of columns inside this row.
        /// </summary>
        Dictionary<string, object> Columns { get; set; }

        /// <summary>
        /// Gets the value of the column with the specified name.
        /// </summary>
        /// <param name="columnName">The name of the column.</param>
        /// <returns>Value of the column which has the specified name.</returns>
        object this[string columnName] { get; set; }
    }
}
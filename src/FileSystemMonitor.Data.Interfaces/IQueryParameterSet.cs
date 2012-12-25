using System.Collections.Generic;

namespace FileSystemMonitor.Data.Interfaces
{
    public interface IQueryParameterSet
    {
        /// <summary>
        /// Gets or sets the list of query parameters.
        /// </summary>
        Dictionary<string, object> ParameterList { get; set; }

        /// <summary>
        /// Gets the total number of the parameters in this QueryParameterSet.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets or sets the value of the parameter identified by the specified key.
        /// </summary>
        /// <param name="key">Parameter key.</param>
        /// <returns>The value of the parameter.</returns>
        object this[string key] { get; set; }

        /// <summary>
        /// Adds a new parameter to the parameter set.
        /// </summary>
        /// <param name="key">Parameter key.</param>
        /// <param name="value">Parameter value.</param>
        void Add(string key, object value);

        /// <summary>
        /// Removes all parameters from this QueryParameterSet.
        /// </summary>
        void Clear();
    }
}
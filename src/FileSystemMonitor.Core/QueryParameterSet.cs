using System.Collections.Generic;
using FileSystemMonitor.Data.Interfaces;

namespace FileSystemMonitor.Core
{
    /// <summary>
    /// Represents a set of SQL query parameters.
    /// </summary>
    public class QueryParameterSet : IQueryParameterSet
    {
        private Dictionary<string, object> parameterList;

        /// <summary>
        /// Gets or sets the list of query parameters.
        /// </summary>
        public Dictionary<string, object> ParameterList
        {
            get
            {
                if (parameterList == null)
                {
                    parameterList = new Dictionary<string, object>();
                }
                return parameterList;
            }
            set { parameterList = value; }
        }

        /// <summary>
        /// Gets or sets the value of the parameter identified by the specified key.
        /// </summary>
        /// <param name="key">Parameter key.</param>
        /// <returns>The value of the parameter.</returns>
        public object this[string key]
        {
            get { return ParameterList[key]; }
            set { ParameterList[key] = value; }
        }

        /// <summary>
        /// Gets the total number of the parameters in this QueryParameterSet.
        /// </summary>
        public int Count
        {
            get { return ParameterList.Count; }
        }

        /// <summary>
        /// Adds a new parameter to the parameter set.
        /// </summary>
        /// <param name="key">Parameter key.</param>
        /// <param name="value">Parameter value.</param>
        public void Add(string key, object value)
        {
            ParameterList.Add(key, value);
        }

        /// <summary>
        /// Removes all parameters from this QueryParameterSet.
        /// </summary>
        public void Clear()
        {
            ParameterList.Clear();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yekzen.Domain.Metadata
{
    /// <summary>
    /// Search results are represented as Lists.
    /// </summary>
    public class List : Resource
    {
        /// <summary>
        /// Total number of resources matching the search parameters.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Requested limit parameter.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Requested skip parameter.
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Array of objects.
        /// </summary>
        public System.Collections.IEnumerable Items { get; set; }
    }
}
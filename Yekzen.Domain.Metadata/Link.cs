using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yekzen.Domain.Metadata
{
    /// <summary>
    /// Link values are used in Entries to specify actual Links to other Entries or Assets.
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Always "Link".
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Type of linked Resource.
        /// </summary>
        public string LinkType { get; set; }

        /// <summary>
        /// ID of linked Resource.
        /// </summary>
        public string Id { get; set; }
    }
}
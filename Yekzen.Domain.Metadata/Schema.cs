using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yekzen.Domain.Metadata
{
    /// <summary>
    /// Schemas are content types describing the shape of Entries. 
    /// They mainly consist of a list of fields acting as a blueprint for Entries.
    /// </summary>
    public class Schema : Resource
    {
        /// <summary>
        /// Name of the Schema.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the Schema.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID of main Field used for display.
        /// </summary>
        public string DisplayField { get; set; }

        /// <summary>
        /// List of Fields.
        /// </summary>
        public Field[] Fields { get; set; }
    }
}
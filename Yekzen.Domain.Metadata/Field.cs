using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yekzen.Domain.Metadata
{
    /// <summary>
    /// A Field describes a single property of an Entry.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// ID of the Field.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the Field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of the Field.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// (List type only) Schema for items.
        /// </summary>
        public Schema Items { get; set; }

        /// <summary>
        /// Describes whether the Field is mandatory.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Describes whether the Field is localized.
        /// </summary>
        public bool Localized { get; set; }
    }
}
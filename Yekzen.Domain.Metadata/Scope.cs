using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yekzen.Domain.Metadata
{
    /// <summary>
    /// Scopes are containers for Schemas, Entries and Assets and other resources.
    /// </summary>
    public class Scope :  Resource
    {
        /// <summary>
        /// Name of the Scope.
        /// </summary>
        public string Name { get; set; }
    }
}
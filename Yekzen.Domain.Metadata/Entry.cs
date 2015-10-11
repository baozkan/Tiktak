using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yekzen.Domain.Metadata
{
    /// <summary>
    /// Entries represent textual content in a Scope. 
    /// An Entry's data adheres to a certain Schema.
    /// </summary>
    public class Entry : Resource
    {
        /// <summary>
        /// Properties according to Schema.
        /// </summary>
        public IDictionary<string,object> Fields { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Entry()
        {
            this.Fields = new Dictionary<string, object>();
        }
    }
}
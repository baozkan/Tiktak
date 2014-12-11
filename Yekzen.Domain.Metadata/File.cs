using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yekzen.Domain.Metadata
{
    public class File
    {
        /// <summary>
        /// Original filename of the file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Content type of the file.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// URL of the file.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Details of the file, depending on its mime type.
        /// </summary>
        public IDictionary<string,object> Details { get; set; }
    }
}
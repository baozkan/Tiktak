using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yekzen.Domain.Metadata
{
    /// <summary>
    /// Assets represent files in a Scope.
    /// An asset can be any kind of file: an image, a video, an audio file, a PDF or any other filetype.
    /// Assets are usually attached to Entries through Links.
    /// </summary>
    public class Asset : Resource
    {
        /// <summary>
        /// Title of the Asset.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the Asset.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// File(s) of the Asset.
        /// </summary>
        public File File { get; set; }
    }
}
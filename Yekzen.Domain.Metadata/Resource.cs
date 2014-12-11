using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yekzen.Domain.Metadata
{
    /// <summary>
    /// There are many types of things which we call Resources: Scopes, Content Types, Entries, Assets, etc. 
    /// Regardless of which type of Resource you are interacting with, there are some rules that apply to all of them.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Type of resource.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Unique ID of resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Link to resource's Scope (except Scopes) .
        /// </summary>
        public Link Scope { get; set; }

        /// <summary>
        /// Link to Entry's Schema (Entries only).
        /// </summary>
        public Link ContentType { get; set; }

        /// <summary>
        /// Version of resource.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Time entity was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time entity was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
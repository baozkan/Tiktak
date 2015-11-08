using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yekzen.Data.Memory;
using Yekzen.Domain.Metadata;
using Yekzen.Core.Collections;
using Yekzen.ServiceModel.Abstractions;
using Yekzen.Core;

namespace Yekzen.Web.Ambar.Controllers
{
    public class EntryTypeController : ApiController
    {
        private readonly IDocumentService documents;

        public EntryTypeController()
        {
            this.documents = ServiceProvider.Current.GetService<IDocumentService>();
        }

        // GET: api/Schema
        public Collection Get(string scope)
        {
            var items = this.documents.Find<EntryType>();
            var collection = new Collection { Type = "Array", Limit = 25, Skip = 0 };
            collection.Items.AddRange(items);
            return collection;
        }

        // GET: api/Schema/5
        public string Get(string scope, int id)
        {
            return "value";
        }

        // POST: api/Schema
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Schema/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Schema/5
        public void Delete(int id)
        {
        }
    }
}

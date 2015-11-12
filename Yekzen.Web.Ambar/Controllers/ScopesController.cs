using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yekzen.Data.Memory;
using Yekzen.Domain.Metadata;
using Yekzen.Core.Collections;
using Yekzen.Data;
using Yekzen.Core;
using Yekzen.ServiceModel.Abstractions;

namespace Yekzen.Web.Ambar.Controllers
{
    public class ScopesController : ApiController
    {
        private readonly IDocumentService documents;

        public ScopesController()
        {
            this.documents = ServiceProvider.Current.GetService<IDocumentService>();
        }

        // GET: api/Scopes
        public Collection Get()
        {
            var items = documents.Find<Scope>();
            Collection collection = new Collection { Type = "Array", Limit = 25, Skip = 0 };
            collection.Items.AddRange(items);
            return collection;
        }

        // GET: api/Scopes/5
        public Scope Get(string id)
        {
            Scope scope = documents.Single<Scope>(p => p.Id == id);
            return scope;
        }

        // POST: api/Scopes
        public void Post([FromBody]Scope value)
        {
            value.Type = "Scope";
            value.Version = 1;
            value.CreatedAt = DateTime.Now;
            value.UpdatedAt = DateTime.Now;
            documents.Insert<Scope>(value);
        }

        // PUT: api/Scopes/5
        public void Put(string id, [FromBody]Scope value)
        {
            value.UpdatedAt = DateTime.Now;
            documents.Update<Scope>(p => p.Id == id, value);
        }

        // DELETE: api/Scopes/5
        public void Delete(string id)
        {
            documents.Delete<Scope>(p => p.Id == id);
        }

        protected override void Dispose(bool disposing)
        {
            if (documents != null)
            {
                documents.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

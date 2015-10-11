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

namespace Yekzen.Web.Ambar.Controllers
{
    public class ScopesController : ApiController
    {
        private readonly IRepository<Scope> repository;

        public ScopesController()
        {
            repository = ServiceProvider.Current.GetService<IRepository<Scope>>();
        }
        // GET: api/Scopes
        public Collection Get()
        {
            var items = repository.All();
            var collection = new Collection { Type = "Array",  Limit = 25, Skip = 0 };
            collection.Items.AddRange(items);
            return collection;
        }

        // GET: api/Scopes/5
        public Scope Get(string id)
        {
            var scope = MemoryContext.Default.GetSet<Scope>().FirstOrDefault(p => p.Id == id);
            return scope;
        }

        // POST: api/Scopes
        public void Post([FromBody]Scope value)
        {
            repository.Create(value);
        }

        // PUT: api/Scopes/5
        public void Put(string id, [FromBody]Scope value)
        {
            var set = MemoryContext.Default.GetSet<Scope>();
            set.Remove(p => p.Id == id);
            set.Add(value);
        }

        // DELETE: api/Scopes/5
        public void Delete(string id)
        {
            MemoryContext.Default.GetSet<Scope>().Remove(p => p.Id == id);
        }
    }
}

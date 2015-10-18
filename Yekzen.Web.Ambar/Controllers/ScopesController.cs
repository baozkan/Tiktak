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
        public ScopesController()
        {
            
        }
        // GET: api/Scopes
        public Collection Get()
        {
            Collection collection = null;
            using (var service = ServiceProvider.Current.GetService<IRepositoryService>())
            {
                var items = service.All<Scope>();
                collection = new Collection { Type = "Array", Limit = 25, Skip = 0 };
                collection.Items.AddRange(items);
            }
           
            return collection;
        }

        // GET: api/Scopes/5
        public Scope Get(string id)
        {
            Scope scope;
            using (var service = ServiceProvider.Current.GetService<IRepositoryService>())
            {
                scope = service.Find<Scope>(p => p.Id == id);
            }
            return scope;
        }

        // POST: api/Scopes
        public void Post([FromBody]Scope value)
        {
            using (var service = ServiceProvider.Current.GetService<IRepositoryService>())
            {
                service.Insert<Scope>(value);
            }
        }

        // PUT: api/Scopes/5
        public void Put(string id, [FromBody]Scope value)
        {
            using (var service = ServiceProvider.Current.GetService<IRepositoryService>())
            {
                service.Update<Scope>(value);
            }
        }

        // DELETE: api/Scopes/5
        public void Delete(string id)
        {
            using (var service = ServiceProvider.Current.GetService<IRepositoryService>())
            {
                var scope = service.Find<Scope>(p => p.Id == id);
                service.Delete<Scope>(scope);
            }
        }
    }
}

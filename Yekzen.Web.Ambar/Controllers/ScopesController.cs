using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yekzen.Domain.Metadata;

namespace Yekzen.Web.Ambar.Controllers
{
    public class ScopesController : ApiController
    {
        // GET: api/Scopes
        public IEnumerable<Scope> Get()
        {
            return new [] { new Scope{ Name = "Demo" } };
        }

        // GET: api/Scopes/5
        public Scope Get(string id)
        {
            return new Scope { Name = "Demo" };
        }

        // POST: api/Scopes
        public void Post([FromBody]Scope value)
        {
        }

        // PUT: api/Scopes/5
        public void Put(string id, [FromBody]Scope value)
        {
        }

        // DELETE: api/Scopes/5
        public void Delete(string id)
        {
        }
    }
}

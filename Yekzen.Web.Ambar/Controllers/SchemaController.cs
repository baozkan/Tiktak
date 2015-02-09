using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yekzen.Data.Memory;
using Yekzen.Domain.Metadata;

namespace Yekzen.Web.Ambar.Controllers
{
    public class SchemaController : ApiController
    {
        // GET: api/Schema
        public Collection Get(string scope)
        {
            var items = MemoryContext.Default.GetSet<Schema>();

            return new Collection { Type = "Array", Items = items.ToList<Resource>(), Limit = 25, Skip = 0 };
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

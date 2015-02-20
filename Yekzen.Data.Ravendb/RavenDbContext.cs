using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data.RavenDb
{
    public class RavenDbContext : IUnitOfWork
    {
        private readonly IDocumentSession session;

        public RavenDbContext(IDocumentStore store)
        {
            this.session = store.OpenSession();
        }

        public void SaveChanges()
        {
            this.session.SaveChanges();
        }

        public void Dispose()
        {
            this.session.Dispose();
        }
    }
}

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
        public IDocumentSession Session { get; private set; }

        public RavenDbContext(IDocumentStore store)
        {
            this.Session = store.OpenSession();
        }

        public void SaveChanges()
        {
            this.Session.SaveChanges();
        }

        public void Dispose()
        {
            this.Session.Dispose();
        }
    }
}

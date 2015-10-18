using Raven.Client;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Data.RavenDb
{
    public static class RavenDbRegistiration
    {
        public static void Run()
        {
            var store = new EmbeddableDocumentStore();
            store.Initialize();
            store.Conventions.AllowQueriesOnId = true;

            var context = new RavenDbContext(store);

            var serviceCollection = new ServiceCollection();
            serviceCollection.Singleton<IDocumentStore>(provider => store);
            serviceCollection.Scoped<IUnitOfWork, RavenDbContext>();
            serviceCollection.Scoped(typeof(IRepository<>), typeof(RavenDbRepository<>));
            serviceCollection.Update();
        }
    }
}

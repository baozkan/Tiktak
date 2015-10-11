using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raven.Client.Embedded;

namespace Yekzen.Data.RavenDb.Test
{
    [TestClass]
    public class RavenDbRepositoryTest
    {
        [TestMethod]
        public void CreateTest()
        {
            var store = new EmbeddableDocumentStore();
            store.Initialize();

            using (var context = new RavenDbContext(store))
            {
                var target = new RavenDbRepository<Foo>(context);
                target.Create(new Foo { Bar = "Foo" });

                var actual = target.Find(foo => foo.Bar == "Foo");

                Assert.IsNotNull(actual);
            }
        }
    }
}

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

            var session = store.OpenSession();
            var target = new RavenDbRepository<Foo>(session);
            target.Create(new Foo { Bar = "Foo" });
            session.SaveChanges();

            var actual = target.Find(foo => foo.Bar == "Foo");

            Assert.IsNotNull(actual);
        }
    }
}

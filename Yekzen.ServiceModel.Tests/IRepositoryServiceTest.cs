using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yekzen.ServiceModel.Abstractions;
using Yekzen.Core;
using Yekzen.Core.DependencyInjection;
using Yekzen.Data;
using NSubstitute;

namespace Yekzen.ServiceModel.Tests
{
    /// <summary>
    /// Summary description for IRepositoryTest
    /// </summary>
    [TestClass]
    public class IRepositoryServiceTest
    {
        private static bool saveAllChanges;

        public IRepositoryServiceTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        
        /// <summary>
        /// Use ClassInitialize to run code before running the first test in the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) 
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Transient<IRepositoryService>(p => new RepositoryService());

            // prepare substitude of IUnitOfWork;
            var unitOfWork = Substitute.For<IUnitOfWork>();
            unitOfWork.When(s => s.SaveChanges())
                .Do(c => saveAllChanges = true);

            serviceCollection.Scoped<IUnitOfWork>(p => unitOfWork);
            serviceCollection.Scoped(typeof(IRepository<>), typeof(SubRepository<>));
            serviceCollection.Update();
        }
        
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateRepositoryServiceTest()
        {
            saveAllChanges = false;
            var expected = true;
            using(IRepositoryService service = ServiceProvider.Current.GetService<IRepositoryService>())
            {
                // do nothing.
            }

            Assert.AreEqual(saveAllChanges, expected);
        }

        [TestMethod]
        public void InsertEntityTest()
        {
            var expected = "Foo";
            var actual = string.Empty;
            using (IRepositoryService service = ServiceProvider.Current.GetService<IRepositoryService>())
            {
                var foo = new Foo { Bar = expected };
                service.Insert<Foo>(foo);

                var target = service.Find<Foo>(p => true);
                actual = target.Bar;
            }

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void InsertEntityScopedTest()
        {
            var expected = "Foo";
            var actual = string.Empty;
            using (IRepositoryService service = ServiceProvider.Current.GetService<IRepositoryService>())
            {
                var foo = new Foo { Bar = expected };
                service.Insert<Foo>(foo);
            }

            using (IRepositoryService service = ServiceProvider.Current.GetService<IRepositoryService>())
            {
                var target = service.Find<Foo>(p => true);
                actual = target.Bar;
            }

            Assert.AreNotEqual(expected, actual);
        }
    }
}

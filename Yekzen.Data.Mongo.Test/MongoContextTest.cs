using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yekzen.Core.DependencyInjection;
using NSubstitute;
using MongoDB.Driver;
using Yekzen.Core.Settings;

namespace Yekzen.Data.Mongo.Test
{
    /// <summary>
    /// Summary description for MongoContext
    /// </summary>
    [TestClass]
    public class MongoContextTest
    {
        static readonly MongoSettings settings = new MongoSettings { DatabaseName = "TestStore" };
        
        public MongoContextTest(){ }

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
        public static void Init(TestContext testContext)
        {
            var serviceCollection = new ServiceCollection();

            // Register ISettingsProvider as singleton.;
            var provider = Substitute.For<ISettingsProvider>();
            provider
                .Get<MongoSettings>()
                .Returns(settings);
            serviceCollection.Singleton<ISettingsProvider>(p => provider);

            // Update registration.
            serviceCollection.Update();
        }

        /// <summary>
        /// Use ClassCleanup to run code after all tests in a class have run. 
        /// </summary>
        [ClassCleanup()]
        public static void Clean() 
        {
            var client = new MongoClient();
            client.DropDatabaseAsync(settings.DatabaseName);
        }
        
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
        public void CreateMongoContextTest()
        {
            var target = new MongoContext();

            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void CreateRepositoryTest()
        {
            var target = new MongoContext();
            var repository = new MongoRepository<Employee>(target);

            Assert.IsNotNull(repository);
        }


        [TestMethod]
        public void CreateRepositoryInsertTest()
        {
            var target = new MongoContext();
            var repository = new MongoRepository<Employee>(target);

            var document = new Employee() 
            {
                FirstName = "Albert",
                LastName = "Einstain"
            };
            
            repository.Insert(document);

            Assert.IsNotNull(repository);
        }

    }
}

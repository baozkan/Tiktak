﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yekzen.Web.Ambar;
using Yekzen.Web.Ambar.Controllers;
using Yekzen.Domain.Metadata;
using Yekzen.Core;

namespace Yekzen.Web.Ambar.Tests.Controllers
{
    [TestClass]
    public class ScopesControllerTest
    {

        /// <summary>
        /// Use ClassInitialize to run code before running the first test in the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            // Register dependency injection.
            Yekzen.Data.RavenDb.RavenDbRegistiration.Run();

            // Register services.
            Yekzen.ServiceModel.ServiceConfiguration.Run();
        }

        [TestMethod]
        public void Get()
        {
            var id = ShortGuid.NewGuid().Value;

            // Arrange
            var controller = new ScopesController();
            
            controller.Post(new Scope { Id = id, Name = "Foo Scope" });

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var controller = new ScopesController();

            var id = ShortGuid.NewGuid().Value;
            // Act
            var result = controller.Get(id);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Post()
        {
            var id = ShortGuid.NewGuid().Value;
            // Arrange
            var controller = new ScopesController();

            // Act
            controller.Post(new Scope { Id =  id, Name = "Foo Scope" });

            var result = controller.Get(id);

            // Assert
            Assert.IsNotNull(result);

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            var id = ShortGuid.NewGuid().Value;
            // Arrange
            var controller = new ScopesController();

            controller.Post(new Scope { Id = id, Name = "Foo" });
            
            // Act
            controller.Put(id, new Scope { Id = id, Name = "Bar" });


            var result = controller.Get(id);

            // Assert
            Assert.AreEqual("Bar",result.Name);

        }

        [TestMethod]
        public void Delete()
        {
            var id = ShortGuid.NewGuid().Value;

            // Arrange
            var controller = new ScopesController();

            // Add item.
            controller.Post(new Scope { Id = id, Name = "Foo" });

            // Act.
            controller.Delete(id);

            // Assert
        }
    }
}

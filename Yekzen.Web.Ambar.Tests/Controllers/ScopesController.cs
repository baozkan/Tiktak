using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yekzen.Web.Ambar;
using Yekzen.Web.Ambar.Controllers;
using Yekzen.Domain.Metadata;

namespace Yekzen.Web.Ambar.Tests.Controllers
{
    [TestClass]
    public class ScopesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var controller = new ScopesController();

            // Act
            IEnumerable<Scope> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var controller = new ScopesController();

            // Act
            var result = controller.Get("5");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            var controller = new ScopesController();

            // Act
            controller.Post(new Scope { Id = "5", Name="Foo" });

            var result = controller.Get("5");

            // Assert
            Assert.IsNotNull(result);

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            var controller = new ScopesController();

            controller.Post(new Scope { Id = "5", Name = "Foo" });
            
            // Act
            controller.Put("5", new Scope { Id = "5", Name = "Bar" });


            var result = controller.Get("5");

            // Assert
            Assert.AreEqual("Bar",result.Name);

        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ScopesController controller = new ScopesController();

            // Act
            controller.Delete("5");

            // Assert
        }
    }
}

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
            ScopesController controller = new ScopesController();

            // Act
            IEnumerable<Scope> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ScopesController controller = new ScopesController();

            // Act
            var result = controller.Get("5");

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ScopesController controller = new ScopesController();

            // Act
            controller.Post(new Scope());

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ScopesController controller = new ScopesController();

            // Act
            controller.Put("5", new Scope());

            // Assert
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

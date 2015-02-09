using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yekzen.Core.Test
{
    [TestClass]
    public class ShortGuidTest
    {
        [TestMethod]
        public void ImplicitlyCastGuidTest()
        {
            var target = new Guid("540c2d5f-a9ab-4414-bd36-9999f5388773");
            var expected = "Xy0MVKupFES9NpmZ9TiHcw";
            ShortGuid sguid1 = target; // implicitly cast the guid as a shortguid
            var actual = sguid1.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplicitlyCastStringTest()
        {
            string target = "Xy0MVKupFES9NpmZ9TiHcw";
            var expected = new Guid("540c2d5f-a9ab-4414-bd36-9999f5388773");
            ShortGuid sguid2 = target; // implicitly cast the string as a shortguid
            var actual = sguid2.Guid;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NewGuidTest()
        {
            var target = ShortGuid.NewGuid();
            Assert.IsNotNull(target.Guid);
        }
    }
}

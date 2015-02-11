using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yekzen.Core.Test
{
    [TestClass]
    public class ServiceProviderTest
    {
        [TestMethod]
        public void GetServiceTest()
        {
            var actual = ServiceProvider.Current.GetService(typeof(IFooService));
        }
    }
}

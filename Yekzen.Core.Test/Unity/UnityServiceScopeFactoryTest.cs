using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Yekzen.Core.Unity;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Test.Unity
{
    [TestClass]
    public class UnityServiceScopeFactoryTest
    {
        [TestMethod]
        public void CreateScopeTest()
        {
            var unityContainer = new UnityContainer();
            UnityRegisteration.Populate(unityContainer, new UnityServiceCollection(unityContainer));

            var notExpected = unityContainer.Resolve<IServiceProvider>();

            var scopeFactory = unityContainer.Resolve<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();

            var actual = scope.ServiceProvider;

            Assert.AreNotEqual(notExpected, actual);
        }
    }
}

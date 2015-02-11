using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Test
{
    [TestClass]
    public class ServiceProviderTest
    {
        [TestMethod]
        public void GetServiceTest()
        {
            var serviceCollection = ServiceProvider.Current.GetService<IServiceCollection>();
            serviceCollection.Add(new ServiceDescriptor(typeof(IFooService), typeof(FooService), LifecycleKind.Scoped));
            var actual = ServiceProvider.Current.GetService<IFooService>();
        }
    }
}

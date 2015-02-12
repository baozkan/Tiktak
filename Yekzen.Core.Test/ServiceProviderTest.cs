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
            serviceCollection.Scoped<IFooService, FooService>();
            var actual = ServiceProvider.Current.GetService<IFooService>();
        }

        
    }
}

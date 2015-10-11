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
            var serviceCollection = new ServiceCollection();
            serviceCollection.Scoped<IFooService, FooService>();
            serviceCollection.Update();
            var actual = ServiceProvider.Current.GetService<IFooService>();

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetGenericServiceTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Scoped(typeof(IGenericFooService<>), typeof(GenericFooService<>));
            serviceCollection.Update();
            var actual = ServiceProvider.Current.GetService<IGenericFooService<int>>();

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetInstanceTest()
        {
            var serviceCollection = new ServiceCollection();
            var expected = new FooService();
            expected.Value = 4;
            serviceCollection.Scoped<IFooService>(provider => expected);
            serviceCollection.Update();
            var actual = ServiceProvider.Current.GetService<IFooService>();

            Assert.AreEqual(expected.Value, actual.Value);
        }
    }
}

using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;
using Yekzen.Core.Unity;

namespace Yekzen.Core
{
    public class ServiceProvider : IServiceProvider, IDisposable
    {
        private static readonly Lazy<ServiceProvider> instance = new Lazy<ServiceProvider>(() => new ServiceProvider());

        private readonly IServiceProvider serviceProvider;

        public static ServiceProvider Current { get { return instance.Value; } }

        private ServiceProvider(IServiceCollection serviceCollection = null)
        {
            serviceCollection = serviceCollection ?? new ServiceCollection();
            this.serviceProvider = new UnityServiceProvider(serviceCollection);
        }

        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }

        public void Dispose()
        {
            ((UnityServiceProvider)this.serviceProvider)
                .Dispose();
        }
    }
}

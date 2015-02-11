using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core
{
    public class ServiceProvider : IServiceProvider
    {
        private static readonly Lazy<ServiceProvider> instance = new Lazy<ServiceProvider>(() => new ServiceProvider());  

        private readonly IServiceScope serviceScope;

        public static ServiceProvider Current { get { return instance.Value; } }

        private ServiceProvider(IConfiguration configuration = null)
        {
            this.serviceScope = serviceScope;
            ServiceLocator.SetLocatorProvider(() => (IServiceLocator)serviceScope);
        }

        public object GetService(Type serviceType)
        {
            return this.serviceScope.GetService(serviceType);
        }

        public static IServiceProvider Initialize()
        {
            var container = new UnityContainer();
            return new UnityServiceProvider(container);
        }            
    }
}

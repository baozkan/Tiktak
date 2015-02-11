using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Unity
{
    internal class UnityServiceProvider : IServiceProvider, IDisposable
    {
        private readonly IUnityContainer container;

        public UnityServiceProvider(IServiceCollection serviceCollection = null)
        {
            this.container = new UnityContainer();
            this.container.RegisterInstance<IServiceCollection>(new UnityServiceCollection(container, serviceCollection));      
        }
        
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>
        /// A service object of type serviceType.-or- null if there is no service object
        /// of type serviceType.
        /// </returns>
        public object GetService(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public void Dispose()
        {
            this.container.Dispose();
        }
    }
}

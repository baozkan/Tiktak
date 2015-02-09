using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core
{
    public class AppServices 
    {
        public static readonly Lazy<AppServices> instance = new Lazy<AppServices>(() => new AppServices(new UnityServiceLocator(new UnityContainer())));  

        private readonly IServiceProvider serviceProvider;

        public AppServices Current { get { return instance.Value; } }

        private AppServices(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            ServiceLocator.SetLocatorProvider(() => (IServiceLocator)serviceProvider);
        }
    }
}

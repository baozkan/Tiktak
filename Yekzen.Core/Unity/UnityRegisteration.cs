using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Unity
{
    public static class UnityRegisteration
    {
        public static void Populate(IUnityContainer container, IServiceCollection collection)
        {
            container.RegisterType<IServiceProvider, UnityServiceProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceScopeFactory, UnityServiceScopeFactory>(new HierarchicalLifetimeManager());
            container.RegisterInstance<IServiceCollection>(new UnityServiceCollection(container,collection));
        }
    }
}

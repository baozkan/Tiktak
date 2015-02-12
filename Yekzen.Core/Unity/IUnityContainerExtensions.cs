using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Unity
{
    internal static class IUnityContainerExtensions
    {
        public static void Register(this IUnityContainer container, IServiceDescriptor serviceDescriptor)
        {
            LifetimeManager lifetimeManager = null;
            switch (serviceDescriptor.Lifecycle)
            {
                case LifecycleKind.Singleton:
                    lifetimeManager = new ContainerControlledLifetimeManager();
                    break;
                case LifecycleKind.Scoped:
                    lifetimeManager = new HierarchicalLifetimeManager();
                    break;
                case LifecycleKind.Transient:
                    lifetimeManager = new TransientLifetimeManager();
                    break;
            }

            if (serviceDescriptor.ImplementationInstance != null)
                container.RegisterInstance(serviceDescriptor.ServiceType, serviceDescriptor.ImplementationInstance);
            else
                container.RegisterType(serviceDescriptor.ServiceType, serviceDescriptor.ImplementationType, lifetimeManager);
        }
    }
}

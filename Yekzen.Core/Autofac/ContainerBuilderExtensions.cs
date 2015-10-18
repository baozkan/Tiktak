using Autofac;
using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;
using System.Reflection;

namespace Yekzen.Core.Autofac
{
    public static class ContainerBuilderExtensions
    {
        public static void Register(this ContainerBuilder builder, IServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationType != null)
            {
                // Test if the an open generic type is being registered
                var serviceTypeInfo = descriptor.ServiceType.GetTypeInfo();
                if (serviceTypeInfo.IsGenericTypeDefinition)
                {
                    builder
                        .RegisterGeneric(descriptor.ImplementationType)
                        .As(descriptor.ServiceType)
                        .ConfigureLifecycle(descriptor.Lifecycle);
                }
                else
                {
                    builder
                        .RegisterType(descriptor.ImplementationType)
                        .As(descriptor.ServiceType)
                        .ConfigureLifecycle(descriptor.Lifecycle);
                }
            }
            else if (descriptor.ImplementationFactory != null)
            {
                var registration = RegistrationBuilder.ForDelegate(descriptor.ServiceType, (context, parameters) =>
                {
                    return descriptor.ImplementationFactory(ServiceProvider.Current);
                })
                .ConfigureLifecycle(descriptor.Lifecycle)
                .As(descriptor.ServiceType)
                .CreateRegistration();

                builder.RegisterComponent(registration);
            }
            else
            {
                builder
                    .RegisterInstance(descriptor.ImplementationInstance)
                    .As(descriptor.ServiceType)
                    .ConfigureLifecycle(descriptor.Lifecycle);
            }
        }

        private static IRegistrationBuilder<object, T, U> ConfigureLifecycle<T, U>(
                this IRegistrationBuilder<object, T, U> registrationBuilder,
                LifecycleKind lifecycleKind)
        {
            switch (lifecycleKind)
            {
                case LifecycleKind.Singleton:
                    registrationBuilder.SingleInstance();
                    break;
                case LifecycleKind.Scoped:
                    registrationBuilder.InstancePerLifetimeScope();
                    break;
                case LifecycleKind.Transient:
                    registrationBuilder.InstancePerDependency();
                    break;
            }

            return registrationBuilder;
        }
    }
}

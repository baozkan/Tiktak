using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static void Transient<TService, TImplementation>(this IServiceCollection collection)
        {
            collection.Describe<TService, TImplementation>(LifecycleKind.Transient);
        }

        public static void Transient(this IServiceCollection collection,[NotNull] Type service, [NotNull] Type implementationType)
        {
            collection.Describe(service, implementationType, LifecycleKind.Transient);
        }

        public static void Transient<TService>(this IServiceCollection collection, [NotNull] Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            collection.Describe(typeof(TService), implementationFactory, LifecycleKind.Transient);
        }

        public static void Transient(this IServiceCollection collection, [NotNull] Type service,
                                           [NotNull] Func<IServiceProvider, object> implementationFactory)
        {
            collection.Describe(service, implementationFactory, LifecycleKind.Transient);
        }

        public static void Scoped<TService, TImplementation>(this IServiceCollection collection)
        {
            collection.Describe<TService, TImplementation>(LifecycleKind.Scoped);
        }

        public static void Scoped(this IServiceCollection collection, [NotNull] Type service, [NotNull] Type implementationType)
        {
            collection.Describe(service, implementationType, LifecycleKind.Scoped);
        }

        public static void Scoped<TService>(this IServiceCollection collection, [NotNull] Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            collection.Describe(typeof(TService), implementationFactory, LifecycleKind.Scoped);
        }

        public static void Scoped(this IServiceCollection collection, [NotNull] Type service,
                                           [NotNull] Func<IServiceProvider, object> implementationFactory)
        {
            collection.Describe(service, implementationFactory, LifecycleKind.Scoped);
        }

        public static void Singleton<TService, TImplementation>(this IServiceCollection collection)
        {
            collection.Describe<TService, TImplementation>(LifecycleKind.Singleton);
        }

        public static void Singleton(this IServiceCollection collection, [NotNull] Type service, [NotNull] Type implementationType)
        {
            collection.Describe(service, implementationType, LifecycleKind.Singleton);
        }

        public static void Singleton<TService>(this IServiceCollection collection, [NotNull] Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            collection.Describe(typeof(TService), implementationFactory, LifecycleKind.Singleton);
        }

        public static void Singleton(this IServiceCollection collection, [NotNull] Type service,
                                           [NotNull] Func<IServiceProvider, object> implementationFactory)
        {
            collection.Describe(service, implementationFactory, LifecycleKind.Singleton);
        }

        public static void Instance<TService>(this IServiceCollection collection, [NotNull] TService implementationInstance)
        {
            collection.Instance(typeof(TService), implementationInstance);
        }

        public static void Instance(this IServiceCollection collection, [NotNull] Type serviceType,
                                          [NotNull] object implementationInstance)
        {
            // TODO : Load from configuration.
            var descriptor = new ServiceDescriptor(serviceType, implementationInstance);
            collection.Add(descriptor);
        }

        public static void Describe<TService, TImplementation>(this IServiceCollection collection, LifecycleKind lifecycle)
        {
            collection.Describe(
                typeof(TService),
                typeof(TImplementation),
                lifecycle: lifecycle);
        }

        public static void Describe(this IServiceCollection collection, Type serviceType, Type implementationType, LifecycleKind lifecycle)
        {
            // TODO : Load from configuration. 
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifecycle);
            collection.Add(descriptor);
        }

        public static void Describe(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory, LifecycleKind lifecycle)
        {
            // TODO : Load from configuration. 
            var descriptor = new ServiceDescriptor(serviceType, implementationFactory, lifecycle);
            collection.Add(descriptor);
        }
    }
}

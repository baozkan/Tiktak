using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core
{
    public static class IServiceProviderExtensions
    {
        /// <summary>
        /// Get service of type <typeparamref name="TService"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="TService">The type of service object to get.</typeparam>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <returns>A service object of type <typeparamref name="TService"/> or null if there is no such service.</returns>
        public static TService GetService<TService>(this IServiceProvider provider) where TService : class
        {
            return provider.GetService(typeof(TService)) as TService;
        }

        /// <summary>
        /// Get service of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type <paramref name="serviceType"/>.</returns>
        /// <exception cref="System.InvalidOperationException">There is no service of type <paramref name="serviceType"/>.</exception>
        public static object GetRequiredService([NotNull] this IServiceProvider provider, [NotNull] Type serviceType)
        {
            var service = provider.GetService(serviceType);

            if (service == null)
            {
                throw new InvalidOperationException(string.Format("'{0}' service could not be found.", serviceType));
            }

            return service;
        }

        /// <summary>
        /// Get service of type <typeparamref name="TService"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="TService">The type of service object to get.</typeparam>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <returns>A service object of type <typeparamref name="TService"/>.</returns>
        /// <exception cref="System.InvalidOperationException">There is no service of type <typeparamref name="TService"/>.</exception>
        public static TService GetRequiredService<TService>([NotNull] this IServiceProvider provider)
        {
            return (TService)provider.GetRequiredService(typeof(TService));
        }

        /// <summary>
        /// Get an enumeration of services of type <typeparamref name="TService"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="TService">The type of service object to get.</typeparam>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the services from.</param>
        /// <returns>An enumeration of services of type <typeparamref name="TService"/>.</returns>
        public static IEnumerable<TService> GetServices<TService>([NotNull] this IServiceProvider provider)
        {
            return provider.GetRequiredService<IEnumerable<TService>>();
        }

        /// <summary>
        /// Get an enumeration of services of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the services from.</param>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>An enumeration of services of type <paramref name="serviceType"/>.</returns>
        public static IEnumerable<object> GetServices([NotNull] this IServiceProvider provider, [NotNull] Type serviceType)
        {
            var genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetRequiredService(genericEnumerable);
        }
    }
}

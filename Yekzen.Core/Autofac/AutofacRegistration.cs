using Autofac;
using System;
using System.Collections.Generic;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Autofac
{
    public static class AutofacRegistration
    {
        public static IServiceProvider Populate(IServiceCollection descriptors)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AutofacServiceScopeFactory>().As<IServiceScopeFactory>();
            Register(builder, descriptors);
            return new AutofacServiceProvider(builder.Build());
        }

        private static void Register(
                ContainerBuilder builder,
                IEnumerable<IServiceDescriptor> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                builder.Register(descriptor);
            }
        }

        public static void Update(IServiceCollection descriptors)
        {
            var builder = new ContainerBuilder();
            Register(builder, descriptors);
            builder.Update(ServiceProvider.Current.GetService<IContainer>());
        }

        
    }
}

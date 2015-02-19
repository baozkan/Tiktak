using Autofac;
using System;
using System.Collections.Generic;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Autofac
{
    public static class AutofacRegistration
    {
        public static void Populate(
                this ContainerBuilder builder,
                IServiceCollection descriptors)
        {
            builder.RegisterType<AutofacServiceProvider>().As<IServiceProvider>();
            builder.RegisterType<AutofacServiceScopeFactory>().As<IServiceScopeFactory>();
            builder.RegisterInstance<IServiceCollection>(new AutofacServiceCollection(builder,descriptors));

            Register(builder, descriptors);
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

        
    }
}

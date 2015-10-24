using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.Autofac
{
    internal class AutofacServiceProvider : IServiceProvider
    {
        private readonly IContainer container;

        public AutofacServiceProvider(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IContainer))
                return container;

            if (!container.IsRegistered(serviceType))
                throw new NotRegisteredException(serviceType);

            return container.Resolve(serviceType);
        }
    }
}

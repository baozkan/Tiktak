using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Autofac
{
    internal class AutofacServiceScopeFactory : IServiceScopeFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacServiceScopeFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public IServiceScope CreateScope()
        {
            return new AutofacServiceScope(_lifetimeScope.BeginLifetimeScope());
        }
    }
}

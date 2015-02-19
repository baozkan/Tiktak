using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Autofac
{
    internal class AutofacServiceScope : IServiceScope
    {
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IServiceProvider _serviceProvider;

        public AutofacServiceScope(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _serviceProvider = _lifetimeScope.Resolve<IServiceProvider>();
        }

        public IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
        }

        public void Dispose()
        {
            _lifetimeScope.Dispose();
        }
    }
}

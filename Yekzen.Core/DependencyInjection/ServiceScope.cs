using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.DependencyInjection
{
    internal class ServiceScope : IServiceScope
    {
        private readonly ServiceProvider scopedProvider;

        public ServiceScope(ServiceProvider scopedProvider)
        {
            scopedProvider = scopedProvider;
        }

        public IServiceProvider ServiceProvider
        {
            get { return scopedProvider; }
        }

        public void Dispose()
        {
            scopedProvider.Dispose();
        }
    }
}

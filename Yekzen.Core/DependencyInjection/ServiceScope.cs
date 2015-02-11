using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.DependencyInjection
{
    internal class ServiceScope : IServiceScope
    {
        private readonly IServiceProvider scopedProvider;

        public ServiceScope(IServiceProvider scopedProvider)
        {
            this.scopedProvider = scopedProvider;
        }

        public IServiceProvider ServiceProvider
        {
            get { return scopedProvider; }
        }

        public void Dispose()
        {
            if(scopedProvider is IDisposable)
                ((IDisposable)scopedProvider).Dispose();
        }
    }
}

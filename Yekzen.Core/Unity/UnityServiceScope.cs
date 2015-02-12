using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Unity
{
    public class UnityServiceScope : IServiceScope
    {
        private readonly IUnityContainer container;
        private readonly IServiceProvider provider;

        public UnityServiceScope(IUnityContainer container)
        {
            this.container = container;
            this.provider = container.Resolve<IServiceProvider>();
        }

        public IServiceProvider ServiceProvider
        {
            get { return provider; }
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}

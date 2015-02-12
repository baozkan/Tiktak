using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Unity
{
    public class UnityServiceScopeFactory : IServiceScopeFactory
    {
        private readonly IUnityContainer container;
        public UnityServiceScopeFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public IServiceScope CreateScope()
        {
            var container = this.container.CreateChildContainer();
            return new UnityServiceScope(container);
        }
    }
}

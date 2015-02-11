using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core
{
    public static class IServiceProviderExtensions
    {
        public static TService GetService<TService>(this IServiceProvider provider) where TService : class
        {
            return provider.GetService(typeof(TService)) as TService;
        }
    }
}

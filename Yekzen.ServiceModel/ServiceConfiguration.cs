using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;
using Yekzen.ServiceModel.Abstractions;

namespace Yekzen.ServiceModel
{
    public static class ServiceConfiguration
    {
        public static void Run()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Transient<IDocumentService, RepositoryService>();
            serviceCollection.Update();
        }
    }
}

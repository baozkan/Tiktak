using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core;
using Yekzen.Core.DependencyInjection;
using Yekzen.Core.Settings;

namespace Yekzen.Data.Mongo
{
    public class MongoDbRegistration
    {
        public static void Run()
        {
            var serviceCollection = new ServiceCollection();

            var dictionary = new Dictionary<int, object>();

            dictionary.Add(typeof(MongoSettings).GetHashCode(), new MongoSettings {
                DatabaseName = "MetadataStore",
                Host = "localhost",
                Port = 27017,
                Timeout = 2 
            });

            // Register ISettingsProvider as singleton.;
            var provider = new DictionarySettingProvider(dictionary);
            
            serviceCollection.Singleton<ISettingsProvider>(p => provider);

            serviceCollection.Scoped<IUnitOfWork, MongoContext>();
            serviceCollection.Scoped(typeof(IRepository<>), typeof(MongoRepository<>));
            
            // Update registration.
            serviceCollection.Update();
        }
    }
}

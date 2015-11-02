using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core;
using Yekzen.Core.Settings;

namespace Yekzen.Data.Mongo
{
    public class MongoContext : IUnitOfWork
    {
        private readonly ISettingsProvider settingsProvider;

        public IMongoDatabase Database { get; private set; }

        public MongoContext()
        {
            this.settingsProvider = ServiceProvider.Current.GetService<ISettingsProvider>();
            var settings = this.settingsProvider.Get<MongoSettings>();

            GetDatabase(settings);
        }

        private void GetDatabase(MongoSettings settings)
        {
            Requires.NotNull(settings, "settings");

            // Register conventions.
            Register();
            
            // To directly connect to a single MongoDB server
            // (this will not auto-discover the primary even if it's a member of a replica set)
            var clientSettings = new MongoClientSettings
            {
                Server = new MongoServerAddress(settings.Host,settings.Port),
                ClusterConfigurator = builder =>
                {
                    builder.ConfigureCluster(s => s.With(serverSelectionTimeout: TimeSpan.FromSeconds(settings.Timeout)));
                }
            };
            var client = new MongoClient(clientSettings);

            this.Database = client.GetDatabase(settings.DatabaseName);
            
            try
            {   
                var result = client.ListDatabasesAsync();
                result.Wait();
            }
            catch(AggregateException exception)
            {
                if (exception.InnerException is TimeoutException)
                    throw new UnreachableException(client, exception.InnerException as TimeoutException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Register()
        {
            var pack = new ConventionPack();
            pack.AddRange(new IConvention[]
            {
                new ReadWriteMemberFinderConvention(),
                new NamedIdMemberConvention(new [] {"id","Id"}),
                new NamedExtraElementsMemberConvention(new [] { "ExtraElements" }),
                new IgnoreExtraElementsConvention(true),
                new NamedParameterCreatorMapConvention(),
                new StringObjectIdIdGeneratorConvention(), // should be before LookupIdGeneratorConvention
                new LookupIdGeneratorConvention()
            });

            ConventionRegistry.Remove("__defaults__");
            ConventionRegistry.Register("__defaults__", pack, t => true);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

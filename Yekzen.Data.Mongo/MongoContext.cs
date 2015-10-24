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

            // To directly connect to a single MongoDB server
            // (this will not auto-discover the primary even if it's a member of a replica set)
            var client = new MongoClient();
            this.Database = client.GetDatabase(settings.DatabaseName);
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

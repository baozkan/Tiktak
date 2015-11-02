using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data.Mongo
{
    public class UnreachableException : Exception
    {
        public MongoClient Client { get; set; }

        public UnreachableException(MongoClient client, TimeoutException innerException) 
            : base(string.Format("MongoDb('{0}') server is unreachable.", client.Settings.Server.ToString()), innerException) { }
    }
}

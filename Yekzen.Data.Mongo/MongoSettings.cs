using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data.Mongo
{
    public class MongoSettings
    {
        public string DatabaseName { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public double Timeout { get; set; }
    }
}

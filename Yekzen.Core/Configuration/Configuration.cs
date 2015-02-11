using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.Configuration
{
    public class Configuration : IConfiguration
    {
        public string Get(string name)
        {
            return System.Configuration.ConfigurationManager.AppSettings[name];
        }
    }
}

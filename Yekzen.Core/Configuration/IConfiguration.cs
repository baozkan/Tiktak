using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.Configuration
{
    public interface IConfiguration
    {
        string Get(string name);
    }
}

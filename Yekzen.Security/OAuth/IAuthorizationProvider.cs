using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Security.OAuth
{
    public interface IAuthorizationProvider
    {
        string Authorize(string clientId, string clientSecret, string username, string password);
    }
}

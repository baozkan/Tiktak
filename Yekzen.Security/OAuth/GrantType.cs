using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Security.OAuth
{
    public enum GrantType
    {
        AuthorizationCode,
        Implicit,
        ResourceOwnerPasswordCredentials,
        ClientCredentials
    }
}

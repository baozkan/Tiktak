using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Security.OAuth
{
    /// <summary>
    /// OAuth defines two client types, based on their ability to
    /// authenticate securely with the authorization server (i.e., ability to
    /// maintain the confidentiality of their client credentials).
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// Clients capable of maintaining the confidentiality of their
        /// credentials (e.g., client implemented on a secure server with
        /// restricted access to the client credentials), or capable of secure
        /// client authentication using other means.
        /// </summary>
        Confidential,

        /// <summary>
        /// Clients incapable of maintaining the confidentiality of their
        /// credentials (e.g., clients executing on the device used by the
        /// resource owner, such as an installed native application or a web
        /// browser-based application), and incapable of secure client
        /// authentication via any other means.
        /// </summary>
        Public
    }
}

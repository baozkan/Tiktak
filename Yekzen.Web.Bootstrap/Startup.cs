using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yekzen.Web.Bootstrap.Startup))]
namespace Yekzen.Web.Bootstrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

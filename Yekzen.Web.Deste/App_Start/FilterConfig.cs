using System.Web;
using System.Web.Mvc;

namespace Yekzen.Web.Deste
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

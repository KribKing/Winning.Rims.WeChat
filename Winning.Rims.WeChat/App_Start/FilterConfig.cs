using System.Web;
using System.Web.Mvc;

namespace Winning.Rims.WeChat
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

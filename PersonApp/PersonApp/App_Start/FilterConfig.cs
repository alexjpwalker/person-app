using System.Web;
using System.Web.Mvc;

namespace PersonApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Ensure errors are handled somewhat gracefully
            filters.Add(new HandleErrorAttribute());
        }
    }
}

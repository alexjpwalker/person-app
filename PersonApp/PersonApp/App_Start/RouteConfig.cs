using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PersonApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ControllerAndAction",
                url: "{controller}/{action}",
                defaults: new { controller = "Person", action = "Index" }
            );

            routes.MapRoute(
                name: "DetailsPage",
                url: "{controller}/{action=Details}/{id}",
                defaults: new { controller = "Person", action = "Details", id = 0 }
            );
        }
    }
}

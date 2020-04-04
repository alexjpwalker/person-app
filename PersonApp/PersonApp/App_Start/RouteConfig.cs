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
            // Ignore internal ASP.NET generated files
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // General purpose routing for actions in controllers
            routes.MapRoute(
                name: "ControllerAndAction",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            // Routing for object details pages (e.g. person details)
            routes.MapRoute(
                name: "DetailsPage",
                url: "{controller}/{action=Details}/{id}",
                defaults: new { controller = "Person", action = "Details", id = 0 }
            );

            // Routing for create object forms (e.g. create new person)
            routes.MapRoute(
                name: "CreatePage",
                url: "{controller}/{action=Create}");
        }
    }
}

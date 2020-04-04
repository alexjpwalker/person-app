using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace PersonApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Make JSON the default WebAPI serialization format
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping(
                "Accept",
                "text/html",
                StringComparison.InvariantCultureIgnoreCase,
                true,
                "application/json"));
            // Use camelCase to match JavaScript / JSON convention
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Enable attribute routing
            config.MapHttpAttributeRoutes();

            /* // Basic REST methods: get/update/delete by id
            config.Routes.MapHttpRoute(
                name: "ById",
                routeTemplate: "api/{controller}/{id:int}"
            );

            // Custom controller actions
            config.Routes.MapHttpRoute(
                name: "CustomActions",
                routeTemplate: "api/{controller}/{action}"
            );

            // Basic REST method: get all
            config.Routes.MapHttpRoute(
                name: "GetAll",
                routeTemplate: "api/{controller}"
            ); */
        }
    }
}

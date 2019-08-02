using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ModernizeLegacyCode
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PingApi",
                routeTemplate: "",
                defaults: new
                {
                    controller = "Result",
                    action = "Ping"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

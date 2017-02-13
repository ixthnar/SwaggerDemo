using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SwaggerDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{action}/{actionid}/{subaction}/{subactionid}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    action = RouteParameter.Optional,
                    actionid = RouteParameter.Optional,
                    subaction = RouteParameter.Optional,
                    subactionid = RouteParameter.Optional
                }
                //routeTemplate: "api/{controller}/{id}",
                //defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

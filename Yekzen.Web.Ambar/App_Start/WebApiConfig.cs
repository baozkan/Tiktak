using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Yekzen.Core.DependencyInjection;
using Yekzen.ServiceModel;
using Yekzen.ServiceModel.Abstractions;

namespace Yekzen.Web.Ambar
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Register dependency injection.
            Yekzen.Data.RavenDb.RavenDbRegistiration.Run();

            // Register 
            Yekzen.ServiceModel.ServiceConfiguration.Run();

        }
    }
}

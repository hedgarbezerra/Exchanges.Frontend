using Hedgar.Exchanges.Frontend.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Hedgar.Exchanges.Frontend.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Filters.Add(new APIExceptionHandler());

            //config.Services.Replace(typeof(IExceptionHandler), new GlobalAPIExceptionHandler());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UjalaCityNews1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "News",
                url: "{controller}/{action}/{title}",
                defaults: new { controller = "Home", action = "News", title = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "NewsIndex",
                url: "{controller}/{action}/{title}",
                defaults: new { controller = "Home", action = "NewsIndex", title = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Category",
                url: "{controller}/{action}/{title}",
                defaults: new { controller = "Home", action = "Category", title = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Place",
                url: "{controller}/{action}/{title}",
                defaults: new { controller = "Home", action = "Place", title = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

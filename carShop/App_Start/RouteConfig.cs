using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace carShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CarsCreate",
                url: "Cars/Create",
                defaults: new { controller = "Cars", action = "Create" }
            );

            routes.MapRoute(
                name:"CarsbyCategorybyPage",
                url: "Cars/{category}/Page{page}",
                defaults: new { controller = "Cars", action = "Index" }
            );

            routes.MapRoute(
                name:"CarsbyPage",
                url: "Cars/Page{page}",
                defaults: new { controller = "Cars", action = "Index" }
            );

            routes.MapRoute(
                name: "CarsByCategory",
                url: "Cars/{category}",
                defaults: new { controller = "Cars", action = "Index" }
            );

            routes.MapRoute(
                name: "CarsIndex",
                url:"Cars",
                defaults: new { controller = "Cars", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

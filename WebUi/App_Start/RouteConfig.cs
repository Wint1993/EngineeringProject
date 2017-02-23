using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

             routes.MapRoute(null,
                 "",
                 new
                 {
                     controller = "Packs",
                     action = "Index",
                     category = (string)null,
                     page = 1
                 }
             );

             routes.MapRoute(null,
                 "Page{page}",
                 new { controller = "Packs", action = "Index", category = (string)null },
                 new { page = @"\d+" }
             );

             routes.MapRoute(null,
                 "{category}",
                 new { controller = "Packs", action = "Index", page = 1 }
             );

             routes.MapRoute(null,
                 "{category}/Page{page}",
                 new { controller = "Packs", action = "Index" },
                 new { page = @"\d+" }
             );

             routes.MapRoute(null, "{controller}/{action}");
             
           /* routes.MapRoute(null, "{category}/Page{page}",
                new { controller = "Admin", action = "Index" },
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{controller}/{action}");
            */
        }
    }
}

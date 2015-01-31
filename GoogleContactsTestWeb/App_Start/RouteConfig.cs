using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GoogleContactsTestWeb.Controllers;

namespace GoogleContactsTestWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Google auth callback", "GoogleAuthCallback/{code}/{error}",
                new
                {
                    controller = HomeController.NameConst,
                    action = HomeController.ActionNameConstants.GoogleAuthCallback,
                    code = UrlParameter.Optional,
                    error = UrlParameter.Optional
                });

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }
    }
}
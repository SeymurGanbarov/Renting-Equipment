using RCE.UI.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace RCE.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "Localization",
             url: "{lang}/{controller}/{action}/{id}",
             constraints: new { lang = @"(\w{2})" },   // en 
             defaults: new { lang=LanguageHelper.DefaultLanguage.ToLower() ,controller = "home", action = "index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new {controller = "home", action = "index", id = UrlParameter.Optional }
         );
        }
    }
}

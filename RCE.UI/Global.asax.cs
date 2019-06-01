using LightInject;
using Microsoft.Practices.ServiceLocation;
using RCE.UI.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RCE.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // LightInject initially configure
            var container = new ServiceContainer();
            container.RegisterControllers();
            ApplicationConfig.Bootstrap(container);
            container.EnableMvc();

            //Initialize data store
            DataStoreConfig.Initialize();
        }
    }
}

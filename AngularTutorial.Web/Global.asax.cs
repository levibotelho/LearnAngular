using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AngularTutorial.Web.Entities;

namespace AngularTutorial.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyInjectionConfig.Register();
            CacheFiller.FillCache();
            SiteMapGenerator.Generate();
        }
    }
}

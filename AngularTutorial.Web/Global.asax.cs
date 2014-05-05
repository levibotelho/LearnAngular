using System.Web.Mvc;
using System.Web.Routing;
using AngularTutorial.Web.Entities;

namespace AngularTutorial.Web
{
    using System.Web.Optimization;

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
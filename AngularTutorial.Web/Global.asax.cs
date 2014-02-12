using System.Web.Mvc;
using System.Web.Routing;
using AngularTutorial.Web.CourseData;

namespace AngularTutorial.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyInjectionConfig.Register();
            CacheFiller.FillCache();
        }
    }
}

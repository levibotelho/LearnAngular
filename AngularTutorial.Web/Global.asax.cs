using System;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using AngularTutorial.Web.Entities;
using Spoon;

namespace AngularTutorial.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        readonly string SnapshotsPath = HostingEnvironment.MapPath("~/Snapshots");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyInjectionConfig.Register();
            CacheFiller.FillCache();
            SiteMapGenerator.Generate();
            SetupSnapshots();
        }

        void SetupSnapshots()
        {
            var urls = File.ReadAllLines(SiteMapGenerator.SitemapPath);
            var escapedFragmentUrlPairs = urls.ToDictionary(x => x.Substring(x.IndexOf("#!", StringComparison.Ordinal) + 2), x => x);
            escapedFragmentUrlPairs[""] = escapedFragmentUrlPairs["/"];
            SnapshotManager.InitializeAsync(escapedFragmentUrlPairs, SnapshotsPath);
        }
    }
}

using System.Web.Optimization;

namespace AngularTutorial.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/Scripts/Services.js")
                .Include("~/Scripts/Controllers.js")
                .Include("~/Scripts/App.js")
                .Include("~/Scripts/ace/ace.js")
                .Include("~/Scripts/ui-ace.js")
                .Include("~/Scripts/GoogleAnalytics.js"));

            bundles.Add(new StyleBundle("~/bundles/styles")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/Site.css"));
        }
    }
}
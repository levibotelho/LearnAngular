using System.Web.Optimization;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;

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
                .Include("~/Scripts/ace.config.js")
                .Include("~/Scripts/GoogleAnalytics.js"));

            var cssBundle = new CustomStyleBundle("~/bundles/styles")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/Site.less");
            cssBundle.Orderer = new NullOrderer();
            bundles.Add(cssBundle);
        }
    }
}
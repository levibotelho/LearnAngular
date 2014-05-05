using System.Web.Optimization;
using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;

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

            var lessTransformer = new CssTransformer();
            var cssBundle = new Bundle("~/bundles/styles")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/Site.less");
            cssBundle.Builder = new NullBuilder();
            cssBundle.Transforms.Add(lessTransformer);
            cssBundle.Orderer = new NullOrderer();
            bundles.Add(cssBundle);
        }
    }
}
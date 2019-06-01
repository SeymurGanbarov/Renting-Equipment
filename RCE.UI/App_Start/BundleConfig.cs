using System.Web;
using System.Web.Optimization;

namespace RCE.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                      ));
            
            bundles.Add(new StyleBundle("~/bundles/css/ui").Include(
                      "~/UI/css/core-style.css",
                      "~/UI/style.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/js/ui").Include(
                     "~/UI/js/jquery/jquery-2.2.4.min.js",
                     "~/UI/js/popper.min.js",
                     "~/UI/js/bootstrap.min.js",
                     "~/UI/js/plugins.js",
                     "~/UI/js/active.js"
                ));
        }
    }
}

using System.Web.Optimization;

namespace Hackathon.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/drag.css"));

            bundles.Add(new ScriptBundle("~/js/lib").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-drag-and-drop-lists.js"
                ));

            bundles.Add(new ScriptBundle("~/js/app").IncludeDirectory(
                "~/client/", "*.js", true));
        }
    }
}

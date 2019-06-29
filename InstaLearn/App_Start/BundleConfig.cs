using System.Web;
using System.Web.Optimization;

namespace InstaLearn
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/jquery-ui-1.12.1.min.js",
                "~/Scripts/sweetalert.js",
                "~/Scripts/fontawesome5.5/js/all.js",
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/DataTables/css/jquery.dataTables.css",
                "~/Content/DataTables/css/dataTables.bootstrap.css",
                "~/Content/fontawesome5.5/css/all.css",
                "~/Content/themes/base/jquery-ui.min.css",
                "~/Content/sweetalert.css",
                "~/Content/site.css"));
        }
    }
}

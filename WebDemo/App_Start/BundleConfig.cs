using System.Web;
using System.Web.Optimization;

namespace WebDemo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/charisma.css").Include(
                "~/Content/bootstrap-cerulean.min.css",
                //"~/Content/bootstrap-cyborg.min.css",
                //"~/Content/bootstrap-darkly.min.css",
                //"~/Content/bootstrap-lumen.min.css",
                //"~/Content/bootstrap-simplex.min.css",
                //"~/Content/bootstrap-slate.min.css",
                //"~/Content/bootstrap-spacelab.min.css",
                //"~/Content/bootstrap-united.min.css",
                "~/Content/charisma-app.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bowser_components").Include(
                "~/Scripts/bower_components/chosen.jquery.min.js",
                "~/Scripts/bower_components/jquery.colorbox.js",
                "~/Scripts/bower_components/moment.js",
                "~/Scripts/bower_components/fullcalendar.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/charisma").Include(
                "~/Scripts/jquery.autogrow-textarea.js",
                "~/Scripts/jquery.cookie.js",
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/jquery.history.js",
                "~/Scripts/jquery.iphone.toggle.js",
                "~/Scripts/jquery.noty.js",
                "~/Scripts/jquery.raty.min.js",
                "~/Scripts/jquery.uploadify-3.1.min.js",
                "~/Scripts/charisma.js"
                ));
        }
    }
}

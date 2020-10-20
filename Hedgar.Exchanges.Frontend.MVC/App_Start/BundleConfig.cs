using System.Web;
using System.Web.Optimization;

namespace Hedgar.Exchanges.Frontend.MVC
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

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                      "~/Scripts/vue.min.js",
                      "~/Scripts/vee-validate-locale-pt_Br.js",
                      "~/Scripts/vee-validate.full.min.js",
                      "~/Scripts/axios.min.js",
                      "~/Scripts/vue-spinners.umd.min.js",
                      "~/Scripts/vue-infinite-loading.js",
                      "~/Scripts/vue-toasted.min.js"
                      ));


            bundles.Add(new ScriptBundle("~/bundles/materialdesign").Include(
                   "~/Scripts/popper.min.js",
                   "~/Scripts/bootstrap-material-design.min.js",
                   "~/Scripts/material-kit.min.js"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                      "~/Content/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                      "~/Scripts/moment-with-locales.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/currency").Include(
                      "~/Scripts/currency.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                      "~/Scripts/Chart.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
            

            bundles.Add(new StyleBundle("~/Content/vue-select").Include(
                      "~/Content/css/vue-select.css"));

            bundles.Add(new ScriptBundle("~/bundles/vue-select").Include(
                      "~/Scripts/vue-select.js"));

            bundles.Add(new StyleBundle("~/Content/animatecss").Include(
                     "~/Content/css/animate.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                    "~/Content/css/all.css"));

            bundles.Add(new StyleBundle("~/Content/materialdesign").Include(
                     "~/Content/css/material-kit.min.css"));
        }
    }
}

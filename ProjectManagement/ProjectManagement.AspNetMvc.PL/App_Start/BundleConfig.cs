using System.Web.Optimization;

namespace ProjectManagement.AspNetMvc.PL
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/Chart").Include(
                "~/Scripts/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/Datepicker").Include(
                "~/Scripts/daterangepicker.js",
                "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/Gentelella").Include(
                "~/Scripts/fastclick.js",
                "~/Scripts/nprogress.js",
                "~/Scripts/respond.js",
                "~/Scripts/moment.js",
                "~/Libs/Gentelella/js/custom.js"));

            #endregion

            #region Styles

            bundles.Add(new ScriptBundle("~/Content/Datepicker").Include(
                "~/Content/daterangepicker.css",
                "~/Content/bootstrap-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/Content/Gentelella").Include(
                "~/Content/nprogress.css",
                "~/Content/animate.css",
                "~/Libs/Gentelella/css/custom.css",
                "~/Content/daterangepicker.css",
                "~/Content/bootstrap-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/ProjectManagement-home").Include(
                "~/Content/ProjectManagement-home.css"));

            #endregion
        }
    }
}

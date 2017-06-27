using System.Web.Optimization;

namespace ProjectManagement.AspNetMvc.PL
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-2.2.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/daterangepicker.js",
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/fastclick").Include(
                "~/Scripts/fastclick.js"));

            bundles.Add(new ScriptBundle("~/bundles/nprogress").Include(
                "~/Scripts/nprogress.js"));

            bundles.Add(new ScriptBundle("~/bundles/Chart").Include(
                "~/Scripts/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/Gentelella").Include(
                "~/Libs/Gentelella/js/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/Dragula").Include(
                "~/Libs/Dragula/dist/dragula.js"));

            #endregion

            #region Styles

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/nprogress.css",
                "~/Content/animate.css",
                "~/Content/daterangepicker.css",
                "~/Content/bootstrap-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/Content/Gentelella").Include(
                "~/Libs/Gentelella/css/custom.css"));

            bundles.Add(new StyleBundle("~/Content/Dragula").Include(
                "~/Libs/Gentelella/dist/dragula.css"));

            #endregion
        }
    }
}
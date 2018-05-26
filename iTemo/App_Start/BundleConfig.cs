using System.Web.Optimization;

namespace iTemo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Script

            bundles.Add(new ScriptBundle("~/script/js").Include(
                "~/Public/js/app.js",
                "~/Public/js/respond.js",
                "~/Public/js/editGrid.js",
                "~/Public/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/script/jquery").Include(
                "~/Public/plugins/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/script/bootstrap").Include(
                "~/Public/plugins/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/script/jsgrid").Include(
                "~/Public/plugins/jsGrid/js/jsgrid.js"));

            bundles.Add(new ScriptBundle("~/script/nprogress").Include(
                "~/Public/plugins/nprogress/js/nprogress.js"));

            bundles.Add(new ScriptBundle("~/script/helper").Include(
                "~/Public/js/helper/commonHelper.js",
                "~/Public/js/helper/gridHelper.js",
                "~/Public/js/helper/multiselectHelper.js",
                "~/Public/js/helper/numberHelper.js",
                "~/Public/js/helper/suggestionHelper.js",
                "~/Public/js/helper/urlHelper.js"));

            #endregion

            #region Style

            bundles.Add(new StyleBundle("~/style/css").Include(
                "~/Public/css/app.css"));

            bundles.Add(new StyleBundle("~/style/nprogress").Include(
                "~/Public/plugins/nprogress/css/nprogress.css"));

            bundles.Add(new StyleBundle("~/style/bootstrap").Include(
                "~/Public/plugins/bootstrap/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/style/fontawesome").Include(
                "~/Public/plugins/fontawesome/css/fa-brands.css",
                "~/Public/plugins/fontawesome/css/fa-regular.css",
                "~/Public/plugins/fontawesome/css/fa-solid.css",
                "~/Public/plugins/fontawesome/css/fontawesome-all.css",
                "~/Public/plugins/fontawesome/css/fontawesome.css"));

            bundles.Add(new StyleBundle("~/style/jsgrid").Include(
                "~/Public/plugins/jsGrid/css/jsgrid.css",
                "~/Public/plugins/jsGrid/css/theme.css"));

            #endregion
        }
    }
}

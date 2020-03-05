using System.Web;
using System.Web.Optimization;

namespace UI.Cart2
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

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/panel").Include(
                    "~/Scripts/Panel/adminlte.js",
                    "~/Scripts/Panel/demo.js",
                    "~/Scripts/Panel/pages/dashboard.js",
                    "~/Scripts/Panel/pages/dashboard2.js",
                    "~/Scripts/Panel/pages/dashboard3.js",
                    "~/plugins/jquery/jquery.min.js",
                    "~/plugins/jquery-ui/jquery-ui.min.js",
                    "~/plugins/bootstrap/js/bootstrap.bundle.min.js",
                    "~/plugins/chart.js/Chart.min.js",
                    "~/plugins/sparklines/sparkline.js",
                    "~/plugins/jqvmap/jquery.vmap.min.js",
                    "~/plugins/jqvmap/maps/jquery.vmap.usa.js",
                    "~/plugins/jquery-knob/jquery.knob.min.js",
                    "~/plugins/moment/moment.min.js",
                    "~/plugins/daterangepicker/daterangepicker.js",
                    "~/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                    "~/plugins/summernote/summernote-bs4.min.js",
                    "~/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/panel").Include(
                  "~/Content/Panel/adminlte.components.css",
                  "~/Content/Panel/alt/adminlte.core.css",
                  "~/Content/Panel/alt/adminlte.extra-components.css",
                  "~/Content/Panel/alt/adminlte.pages.css",
                  "~/Content/Panel/alt/adminlte.plugins.css",
                  "~/plugins/fontawesome-free/css/all.min.css",
                  "~/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                  "~/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                  "~/plugins/jqvmap/jqvmap.min.css",
                  "~/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                  "~/plugins/daterangepicker/daterangepicker.css",
                  "~/plugins/summernote/summernote-bs4.css"

                  ));
        }
    }
}

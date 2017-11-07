using System.Web.Optimization;

namespace ProjetoBanco.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                "~/Scripts/jquery.validate.js"
            ));
          
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/materialize/js/materialize.js",
                "~/Scripts/datatables.min.js",
                "~/Scripts/respond.js",
                "~/Scripts/SisBank.js",
                "~/Scripts/materialize/SisBankMaterialize.js",
                "~/Scripts/jquery.maskedinput.js",
                "~/Scripts/jquery.maskMoney.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/materialize/css/materialize.css",
                "~/Content/SisBank.css",
                "~/Content/datatables.min.css"));
        }
    }
}
using System.Web.Optimization;

namespace Jra.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            try
            {
                bundles.Add(new ScriptBundle("~/js/jquery").Include(
                    "~/js/jquery-{version}.js"));
            }
            catch { }
            //bundles.Add(new ScriptBundle("~/js/bootstrap").Include(
            //          "~/js/bootstrap.js",
            //          "~/js/respond.js"));
            try
            {
                bundles.Add(new StyleBundle("~/css/main").Include(
                    "~/css/site.css"));
            }
            catch { }
            BundleTable.EnableOptimizations = true;
        }

        
    }
}

using System.Web;
using System.Web.Optimization;

namespace CodeRepository.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Scripts/Script").Include(
          "~/Scripts/Script.js",
          "~/Scripts/jquery-3.1.1.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/StyleSheet.css"));
        }
    }
}
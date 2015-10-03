using System.Web;
using System.Web.Optimization;

namespace SaveNote
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-2.*")
                .Include("~/Scripts/jquery.unobtrusive-ajax*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/semantic")
                .Include("~/Scripts/semantic*")
                .Include("~/Scripts/tinymce/tinymce*")
                .Include("~/Scripts/tinymce/jquery.tinymce*")
                .Include("~/Scripts/jquery.cookie*")                
                .Include("~/Scripts/checkbox*")
                .Include("~/Scripts/index*")
                .Include("~/Scripts/popup*")
                .Include("~/Scripts/shape*"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/common.js"));

            bundles.Add(new ScriptBundle("~/bundles/calendar")
                .Include("~/Scripts/datepicker-ru.js")
                .Include("~/Scripts/calendar.js"));

            
            bundles.Add(new StyleBundle("~/Content/css")
                    .Include("~/Content/site.css")
                    .Include("~/Content/semantic*")
                    .Include("~/Content/icon*")
                    .Include("~/Content/card*")
                    .Include("~/Content/button*")
                    .Include("~/Content/table*")
                    .Include("~/Content/checkbox*")
                    .Include("~/Content/popup*")
                    .Include("~/Content/font-awesome*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                     "~/Scripts/jquery-ui.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css/jqueryui")
                   .Include("~/Content/jquery-ui.*"));
        }
    }
}
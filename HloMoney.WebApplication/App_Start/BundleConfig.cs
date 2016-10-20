﻿using System.Web;
using System.Web.Optimization;

namespace HloMoney.WebApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/jquery.jgrowl.js",
                        "~/Scripts/jgrowl.alerts.js",
                        "~/Scripts/jquery.ui.widget.js",
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/jquery-ui-timepicker.js",
                        "~/Scripts/jquery.fileupload.js",
                        "~/Scripts/tinymce/tinymce.min.js",
                        "~/Scripts/loader.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/DateTimePicker.css",
                      "~/Content/jquery.jgrowl.css"));
        }
    }
}

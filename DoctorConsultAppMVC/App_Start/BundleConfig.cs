﻿using System.Web;
using System.Web.Optimization;

namespace DoctorConsultAppMVC
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Kendo Css, bootsrap files

            bundles.Add(new ScriptBundle("~/Kendo").Include(
                     "~/Content/Kendo/js/kendo.all.min.js",
                     "~/Content/Kendo/js/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Kendo/styles").Include(
                      "~/Content/Kendo/styles/kendo.bootstrap.min.css",
                      "~/Content/Kendo/styles/kendo.common.min.css",
                      "~/Content/Kendo/styles/kendo.default.min.css"));

            bundles.IgnoreList.Clear();



        }
    }
}

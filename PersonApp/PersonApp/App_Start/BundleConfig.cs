using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PersonApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bundle stylesheets
            // It doesn't provide much benefit right now, but it would if we had more stylesheets.
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/styles.css"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Namespace name matches the directory structure.
namespace PersonApp.Controllers
{
    // Controller name matches the path name: in this case, "About".
    // When inheriting from a superclass, prefer to put the superclass name at the end of the subclass name.
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
    }
}

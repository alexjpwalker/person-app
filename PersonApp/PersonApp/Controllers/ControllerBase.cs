using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IPersonAppContext Context => _context;

        private IPersonAppContext _context = PersonAppContext.Instance;
    }
}

using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PersonApp.Controllers.Api
{
    public abstract class BaseApiController : ApiController
    {
        protected IPersonAppContext Context => _context;

        private IPersonAppContext _context = PersonAppContext.Instance;
    }
}

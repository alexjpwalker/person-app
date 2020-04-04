using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PersonApp.Controllers
{
    public class PersonController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var people = await Context.People
                .Include(p => p.PersonGroup)
                .ToListAsync();
            return View(people);
        }

        [Route("{id}")]
        public ActionResult Details(int id)
        {
            var person = Context.People.SingleOrDefault(x => x.Id == id);
            if (person == null)
            {
                return View();
            }
            return View(person);
        }
    }
}

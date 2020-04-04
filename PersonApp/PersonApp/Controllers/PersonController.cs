using PersonApp.Models;
using PersonApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = await Context.People
                .Include(p => p.PersonGroup)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (person == null)
            {
                return new HttpNotFoundResult();
            }

            return View(person);
        }
        
        public async Task<ActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return PartialView("PersonSearchResultsPane", new PersonSearchResultsPaneViewModel
                {
                    InitialState = true
                });
            }

            var people = await Context.People
                .Where(p => p.FirstName.Contains(query.Trim()) || p.LastName.Contains(query.Trim()))
                .ToListAsync();
            return PartialView("PersonSearchResultsPane", new PersonSearchResultsPaneViewModel
            {
                People = people
            });
        }
    }
}

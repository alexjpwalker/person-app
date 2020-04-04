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
        // Prefer async Tasks over non-async methods:
        // see https://docs.microsoft.com/en-us/archive/msdn-magazine/2014/october/async-programming-introduction-to-async-await-on-asp-net for details.
        public async Task<ActionResult> Index()
        {
            // In general, the PersonGroup should not be loaded because that's an additional JOIN.
            // But here, we need the group name, so we join explictly using .Include to get it.
            var people = await Context.People
                .Include(p => p.PersonGroup)
                .ToListAsync();
            return View(people);
        }
        
        // Action name matches the path name (e.g: /Person/Details/4)
        public async Task<ActionResult> Details(int? id)
        {
            // Return something sensible if someone tries to navigate to /Person/Details
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Because it's conceivable that someone might type in an ID that doesn't exist, use SingleOrDefault instead of Single
            // and check if the result is null. If it is, we can take the user to a 404 page.
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
            // If query is empty, render "Please type some text" or similar
            if (string.IsNullOrWhiteSpace(query))
            {
                return PartialView("PersonSearchResultsPane", new PersonSearchResultsPaneViewModel
                {
                    InitialState = true
                });
            }

            // Note: This is not a very efficient lookup.
#warning May be case sensitive depending on implementation of Contains
            var people = await Context.People
                .Where(p => p.FirstName.Contains(query.Trim()) || p.LastName.Contains(query.Trim()))
                .ToListAsync();
            return PartialView("PersonSearchResultsPane", new PersonSearchResultsPaneViewModel
            {
                People = people
            });
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            // The Create Person form has a dropdown list of groups; we load them here.
            var groups = await Context.PersonGroups.ToListAsync();
            return View("Create", new CreatePersonViewModel
            {
                Groups = groups,
                FirstName = "",
                LastName = ""
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePersonViewModel model)
        {
            // Check that all required items are present: in this case, first name, last name and group ID.
            if (!ModelState.IsValid)
            {
                // We still need to reinitialize the groups dropdown - they will not magically reappear.
                var groups = await Context.PersonGroups.ToListAsync();
                model.Groups = groups;
                return View("Create", model);
            }

            // Prefer using 'var' when possible (instead of writing Person twice).
            // Prefer giving variables descriptive names (i.e. 'person' and not, say, 'x')
            var person = new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PersonGroupId = model.Group.Value
            };

            Context.People.Add(person);
            // In EF, SaveChanges (or SaveChangesAsync) is required in order to persist data to the database.
            await Context.SaveChangesAsync();
            // After save, 'person' has the database generated ID and CreatedDate automatically attached to it.
            return View("Details", person);
        }
    }
}

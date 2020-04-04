using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

/* We don't currently make use of this Web API, but we probably should. */
namespace PersonApp.Controllers.Api
{
    [RoutePrefix("api/people")]
    public class PeopleController : BaseApiController
    {
        // GET api/people
        [HttpGet]
        [Route("")]
        public async Task<List<Person>> Get()
        {
            var people = await Context.People.ToListAsync();
            return people;
        }

        // GET api/people/7
        [HttpGet]
        [Route("{id}")]
        public async Task<Person> Get(int id)
        {
            var person = await Context.People.SingleOrDefaultAsync(x => x.Id == id);
            return person;
        }

        // GET api/people/search
        // Example: GET api/people/search?q=john
        [HttpGet]
        [Route("search")]
        public async Task<List<Person>> Search([FromUri(Name = "q")] string query)
        {
            // Note: This is not a very efficient lookup.
            var people = await Context.People
                .Where(p => p.FirstName.Contains(query) || p.LastName.Contains(query))
                .ToListAsync();
            return people;
        }

        // POST api/people
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] Person person)
        {
            var p = Context.People.Add(person);
            return Created($"api/people/{p.Id}", p);
        }
    }
}

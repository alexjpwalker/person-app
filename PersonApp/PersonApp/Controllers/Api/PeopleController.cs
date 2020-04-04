using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PersonApp.Controllers.Api
{
    public class PeopleController : BaseApiController
    {
        // GET api/people
        [HttpGet]
        public async Task<List<Person>> Get()
        {
            var people = await Context.People.ToListAsync();
            return people;
        }

        // GET api/people/7
        [HttpGet]
        public async Task<Person> Get(int id)
        {
            var person = await Context.People.SingleOrDefaultAsync(x => x.Id == id);
            return person;
        }

        // POST api/people
        [HttpPost]
        public Person Post([FromBody] Person person)
        {
            return Context.People.Add(person);
        }
    }
}

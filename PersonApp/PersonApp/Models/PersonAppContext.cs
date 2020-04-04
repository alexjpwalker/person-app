using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PersonApp.Models
{
    public class PersonAppContext : DbContext, IPersonAppContext
    {
        private PersonAppContext()
        {

        }

        public static PersonAppContext Instance => _instance;

        public IDbSet<PersonGroup> PersonGroups { get; set; }
        public IDbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Not required here - because EF knows a property named {prop}Id is the FK relation for {prop}?
            /*modelBuilder.Entity<PersonGroup>()
                .HasMany(pg => pg.People)
                .WithRequired(p => p.PersonGroup)
                .HasForeignKey(p => p.PersonGroupId);*/
        }

        private static PersonAppContext _instance = new PersonAppContext();
    }
}

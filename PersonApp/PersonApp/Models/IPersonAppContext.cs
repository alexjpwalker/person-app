using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PersonApp.Models
{
    // Naming convention for C# interfaces: the thing they describe, prefixed with the letter 'I'.
    public interface IPersonAppContext
    {
        IDbSet<PersonGroup> PersonGroups { get; }
        IDbSet<Person> People { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

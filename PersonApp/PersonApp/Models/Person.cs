using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PersonApp.Models
{
    // EF may or may not default to assigning table names that match the class names, but there's no harm in specifying them explicitly.
    [Table("Person")]
    public class Person
    {
        // May as well specify the primary key explicitly too.
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // If PersonGroup was serialized, it would cause a circular reference and throw an error.
        [JsonIgnore]
        public PersonGroup PersonGroup { get; set; }
        public int PersonGroupId { get; set; }
        // Ensure that EF uses the database default for CreatedDate.
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";
    }
}

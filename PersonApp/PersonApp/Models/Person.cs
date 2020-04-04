using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PersonApp.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public PersonGroup PersonGroup { get; set; }
        public int PersonGroupId { get; set; }
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";
    }
}

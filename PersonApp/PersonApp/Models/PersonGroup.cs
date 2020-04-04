using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PersonApp.Models
{
    [Table("PersonGroup")]
    public class PersonGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Person> People { get; set; }
    }
}

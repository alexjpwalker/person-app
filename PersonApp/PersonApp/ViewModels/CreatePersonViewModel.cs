using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonApp.ViewModels
{
    public class CreatePersonViewModel
    {
        public List<PersonGroup> Groups { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int? Group { get; set; }

        public string ErrorMessage { get; set; }
    }
}

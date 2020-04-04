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

        // Ensure that, if FirstName is not specified when submitting the Create form, the form fails to submit.
        // It is sensible to implement client-side validation for this too.
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int? Group { get; set; }

        // We could display an error message to the user when their Create fails for whatever reason.
        public string ErrorMessage { get; set; }
    }
}

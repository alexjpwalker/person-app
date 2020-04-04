using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonApp.ViewModels
{
    public class PersonSearchResultsPaneViewModel
    {
        public bool InitialState { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}

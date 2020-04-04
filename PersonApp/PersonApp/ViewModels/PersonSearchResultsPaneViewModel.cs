using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonApp.ViewModels
{
    public class PersonSearchResultsPaneViewModel
    {
        // If InitialState is true, the view will display something like 'Type to search for people'.
        public bool InitialState { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}

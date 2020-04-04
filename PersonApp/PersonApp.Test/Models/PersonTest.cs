using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.Test.Models
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void FullName_ShouldBeFirstNameFollowedByLastName()
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = "Smith"
            };
            Assert.AreEqual("John Smith", person.FullName);
        }
    }
}

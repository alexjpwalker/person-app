using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonApp;
using PersonApp.Controllers;
using System.Threading.Tasks;

namespace PersonApp.Test.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        [TestMethod]
        public async Task Index_ShouldExist()
        {
            var controller = new PersonController();
            var result = await controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        // TODO: Test other controller methods
    }
}

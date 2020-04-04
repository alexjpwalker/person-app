using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonApp;
using PersonApp.Controllers;
using System.Threading.Tasks;

namespace PersonApp.Test.Controllers
{
    [TestClass]
    public class AboutControllerTest
    {
        [TestMethod]
        public void Index_ShouldExist()
        {
            var controller = new AboutController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}

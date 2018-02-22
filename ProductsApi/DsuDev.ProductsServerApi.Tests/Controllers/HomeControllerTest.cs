using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DsuDev.ProductsServerApi.Controllers;

namespace DsuDev.ProductsServerApi.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void HomeController_Index()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Home Page", result.ViewBag.Title);
		}
	}
}

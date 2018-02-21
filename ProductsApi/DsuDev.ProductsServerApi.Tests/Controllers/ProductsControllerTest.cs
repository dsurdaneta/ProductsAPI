using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DsuDev.ProductsServerApi;
using DsuDev.ProductsServerApi.Controllers;

namespace DsuDev.ProductsServerApi.Tests.Controllers
{
	[TestClass]
	public class ProductsControllerTest
	{
		[Ignore]
		[TestMethod]
		public void ProductsController_Index()
		{
			// Arrange
			ProductsController controller = new ProductsController();

			// Act
			var result = controller.GetProducts();
			
			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Home Page", "");
		}
	}
}

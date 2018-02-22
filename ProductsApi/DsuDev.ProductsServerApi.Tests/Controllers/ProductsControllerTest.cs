using Microsoft.VisualStudio.TestTools.UnitTesting;
using DsuDev.ProductsServerApi.Controllers;
using DsuDev.ProductsServerApi.Models;
using System.Collections.Generic;
using DsuDev.ProductsServerApi.Tests.Models;
using System.Web.Http.Results;
using System.Net;
using System.Linq;

namespace DsuDev.ProductsServerApi.Tests.Controllers
{
	[TestClass]
	public class ProductsControllerTest
	{		
		[TestMethod]
		public void PostProduct_ShouldReturnSameProduct()
		{
			//Arrange
			var controller = new ProductsController(new TestStoreAppContext());
			var item = GetDemoProduct();
			//Act
			var result = controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<Product>;
			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(result.RouteName, "DefaultApi");
			Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
			Assert.AreEqual(result.Content.ProductName, item.ProductName);
		}

		[TestMethod]
		public void PutProduct_ShouldReturnStatusCode()
		{
			//Arrange
			var controller = new ProductsController(new TestStoreAppContext());
			var item = GetDemoProduct();
			//Act
			var result = controller.PutProduct(item.Id, item) as StatusCodeResult;
			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
			Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
		}

		[TestMethod]
		public void PutProduct_ShouldFail_WhenDifferentID()
		{
			//Arrange
			var controller = new ProductsController(new TestStoreAppContext());
			//Act
			var badresult = controller.PutProduct(999, GetDemoProduct());
			//Assert
			Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
		}

		[TestMethod]
		public void GetProduct_ShouldReturnProductWithSameID()
		{
			//Arrange
			var context = new TestStoreAppContext();
			context.Products.Add(GetDemoProduct());
			//Act
			var controller = new ProductsController(context);
			var result = controller.GetProduct(3) as OkNegotiatedContentResult<Product>;
			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Content.Id);
		}

		[TestMethod]
		public void GetProducts_ShouldReturnAllProducts()
		{
			//Arrange
			var context = GetDemoContext();
			//Act
			var controller = new ProductsController(context);
			var result = controller.GetProducts() as TestProductDbSet;
			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Local.Count);
		}

		[TestMethod]
		public void DeleteProduct_ShouldReturnOK()
		{
			//Arrange
			var context = new TestStoreAppContext();
			var item = GetDemoProduct();
			context.Products.Add(item);
			//Act
			var controller = new ProductsController(context);
			var result = controller.DeleteProduct(3) as OkNegotiatedContentResult<Product>;
			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(item.Id, result.Content.Id);
		}

		[TestMethod]
		public void GetProductsInStock_ShouldNotReturnAllProducts()
		{
			//Arrange
			var context = GetDemoContext();
			//Act
			var controller = new ProductsController(context);
			var result = controller.GetProductsInStock() as IQueryable<Product>;
			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() < context.Products.Local.Count);
			CollectionAssert.AreNotEqual(result.ToList(), context.Products.Local.ToList());
		}

		[TestMethod]
		public void GetProductsByName_ShouldReturnCorrectProduct()
		{
			//Arrange
			string name = "Yo-yo";
			var context = GetDemoContext();
			//Act
			var controller = new ProductsController(context);
			var result = controller.GetProductsByName(name) as OkNegotiatedContentResult<List<Product>>;
			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.Content[0].Id);
		}

		[TestMethod]
		public void GetProductsInStockByName_ShouldReturnCorrectProduct()
		{
			//Arrange
			string name = "Tomato";
			var context = GetDemoContext();
			//Act
			var controller = new ProductsController(context);
			var result = controller.GetProductsInStockByName(name) as OkNegotiatedContentResult<List<Product>>;
			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Content[0].Id);
			Assert.IsTrue(result.Content[0].StockQuantity > 0);
		}

		[TestMethod]
		public void GetProductsInStockByName_ShouldNotReturnNotFound()
		{
			//Arrange
			string name = "Hammer";
			var context = GetDemoContext();
			//Act
			var controller = new ProductsController(context);
			var notFoundResult = controller.GetProductsInStockByName(name);
			//Assert
			Assert.IsInstanceOfType(notFoundResult, typeof(NotFoundResult));
		}

		#region Private Methods
		Product GetDemoProduct()
		{
			return new Product() { Id = 3, ProductName = "Hammer", Category = "Hardware", Price = 16.99M, StockQuantity = 0 };
		}

		private static TestStoreAppContext GetDemoContext()
		{
			var context = new TestStoreAppContext();
			context.Products.Add(new Product { Id = 1, ProductName = "Tomato Soup", Category = "Groceries", Price = 1, StockQuantity = 150 });
			context.Products.Add(new Product { Id = 2, ProductName = "Yo-yo", Category = "Toys", Price = 3.75M, StockQuantity = 78 });
			context.Products.Add(new Product { Id = 3, ProductName = "Hammer", Category = "Hardware", Price = 16.99M, StockQuantity = 0 });
			return context;
		}
		#endregion
	}
}

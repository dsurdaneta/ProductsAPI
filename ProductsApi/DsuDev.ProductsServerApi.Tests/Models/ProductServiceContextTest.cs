using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DsuDev.ProductsServerApi.Models;

namespace DsuDev.ProductsServerApi.Tests.Models
{
	[TestClass]
	public class ProductServiceContextTest
	{
		[TestMethod]
		public void ProductServiceContext_NotNull()
		{
			//Act
			var result = new ProductServiceContext();
			//Assert
			Assert.IsNotNull(result);
		}

		[Ignore]
		[TestMethod]
		public void ProductServiceContext_HasProducts()
		{
			//Arrange
			var context = new ProductServiceContext();
			//Act
			var result = context.Products;
			//Assert
			Assert.IsTrue(result.Local.Count > 0);
		}
	}
}

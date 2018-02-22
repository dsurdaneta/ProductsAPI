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

		[TestMethod]
		public void ProductServiceContext_HasNotNullProducts()
		{
			//Arrange
			var context = new ProductServiceContext();
			//Act
			var result = context.Products;
			//Assert
			Assert.IsNotNull(result);
		}
	}
}

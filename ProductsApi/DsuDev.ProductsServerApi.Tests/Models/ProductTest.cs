using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DsuDev.ProductsServerApi.Models;

namespace DsuDev.ProductsServerApi.Tests.Models
{
	/// <summary>
	/// Summary description for ProductTest
	/// </summary>
	[TestClass]
	public class ProductTest
	{
		[TestMethod]
		public void Product_NotNull()
		{
			//Arrange
			var result = new Product();
			//Assert
			Assert.IsNotNull(result);
		}
	}
}

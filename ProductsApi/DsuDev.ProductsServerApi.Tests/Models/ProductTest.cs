using DsuDev.ProductsServerApi.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

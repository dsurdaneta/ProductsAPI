using System.Data.Entity;
using DsuDev.ProductsServerApi.Domain.Entities;
using DsuDev.ProductsServerApi.Services.Context;

namespace DsuDev.ProductsServerApi.Tests.Models
{
    /// <summary>
    ///  Mocking class
    /// </summary>
    public class TestStoreAppContext : IProductServiceContext
	{
		public TestStoreAppContext()
		{
			this.Products = new TestProductDbSet();
		}

		public DbSet<Product> Products { get; set; }

		public int SaveChanges()
		{
			return 0;
		}

		public void MarkAsModified(Product item) { }
		public void Dispose() { }
	}
}

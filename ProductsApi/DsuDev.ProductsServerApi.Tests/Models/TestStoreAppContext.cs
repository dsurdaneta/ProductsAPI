using System.Data.Entity;
using DsuDev.ProductsServerApi.Models;

namespace DsuDev.ProductsServerApi.Tests.Models
{
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

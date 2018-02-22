using System;
using System.Data.Entity;

namespace DsuDev.ProductsServerApi.Models
{
	public interface IProductServiceContext : IDisposable
	{
		DbSet<Product> Products { get; }
		int SaveChanges();
		void MarkAsModified(Product item);
	}
}

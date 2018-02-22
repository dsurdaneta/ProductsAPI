using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsuDev.ProductsServerApi.Models
{
	public interface IProductServiceContext : IDisposable
	{
		DbSet<Product> Products { get; }
		int SaveChanges();
		void MarkAsModified(Product item);
	}
}

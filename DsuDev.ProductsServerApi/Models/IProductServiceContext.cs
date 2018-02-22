using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsuDev.ProductsServerApi.Models
{
	interface IProductServiceContext : IDisposable
	{
		DbSet<Product> Products { get; }
		int SaveChanges();
		void MarkAsModified(Product item);
	}
}

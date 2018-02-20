namespace DsuDev.ProductsServerApi.Migrations
{
	using DsuDev.ProductsServerApi.Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<ProductServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductServiceContext context)
        {
			context.Products.AddOrUpdate(x => x.Id,
				new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1, StockQuantity = 150 },
				new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M, StockQuantity = 78 },
				new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M, StockQuantity = 0 }
				);

			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}
    }
}

using DsuDev.ProductsServerApi.Domain.Entities;
using DsuDev.ProductsServerApi.Services.Context;
using System.Data.Entity.Migrations;

namespace DsuDev.ProductsServerApi.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProductServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductServiceContext context)
        {
            context.Products.AddOrUpdate(x => x.Id,
                new Product { Id = 1, ProductName = "Tomato Soup", Category = "Groceries", Price = 1, StockQuantity = 150 },
                new Product { Id = 2, ProductName = "Yo-yo", Category = "Toys", Price = 3.75M, StockQuantity = 78 },
                new Product { Id = 3, ProductName = "Hammer", Category = "Hardware", Price = 16.99M, StockQuantity = 0 }
            );			
        }
    }
}

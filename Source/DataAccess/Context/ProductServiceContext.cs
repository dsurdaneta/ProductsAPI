using DsuDev.ProductsServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DsuDev.ProductsServer.DataAccess.Context
{
    public class ProductServiceContext : DbContext, IProductServiceContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string ContextName = "name=ProductServiceContext";
        private static readonly string DefaultConectionString =
            @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True";

        public ProductServiceContext(DbContextOptions options) : base(options)
        {
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DefaultConectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public void MarkAsModified(Product item)
        {
            Entry(item).State = EntityState.Modified;
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public void MarkAsModified(Category item)
        {
            Entry(item).State = EntityState.Modified;
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
    }
}

﻿using System.Data.Entity;
using DsuDev.ProductsServerApi.Domain.Entities;

namespace DsuDev.ProductsServerApi.Services.Context
{
    public class ProductServiceContext : DbContext, IProductServiceContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProductServiceContext() : base("name=ProductServiceContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public void MarkAsModified(Product item)
        {
            Entry(item).State = EntityState.Modified;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public void MarkAsModified(Category item)
        {
            Entry(item).State = EntityState.Modified;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
    }
}

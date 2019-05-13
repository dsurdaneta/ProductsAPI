using System;
using System.Data.Entity;
using DsuDev.ProductsServerApi.Domain.Entities;

namespace DsuDev.ProductsServerApi.Services.Context
{
    public interface IProductServiceContext : IDisposable
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
        int SaveChanges();
        void MarkAsModified(Product item);
    }
}

using System;
using DsuDev.ProductsServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DsuDev.ProductsServer.DataAccess.Context
{
    public interface IProductServiceContext : IDisposable
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
        int SaveChanges();
        void MarkAsModified(Product item);
    }
}

using System.Collections.Generic;
using DsuDev.ProductsServer.Domain.Entities;

namespace DsuDev.ProductsServer.Services
{
    public interface IProductService
    {
        bool ProductExists(int id);
        int Insert(Product product);
        Product FindProduct(int productId);
        int Remove(Product product);
        int UpdateProducts(Product product);
        IEnumerable<Product> GetAllProducts(bool stockOnly = false);
        IEnumerable<Product> GetProductsByName(string name, bool stockOnly = false);        
    }
}

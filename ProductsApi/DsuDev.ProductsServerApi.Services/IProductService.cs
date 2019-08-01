using DsuDev.ProductsServerApi.Domain.Entities;
using System.Collections.Generic;

namespace DsuDev.ProductsServerApi.Services
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

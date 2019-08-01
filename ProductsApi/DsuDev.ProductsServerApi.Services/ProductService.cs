using DsuDev.ProductsServerApi.Domain.Entities;
using DsuDev.ProductsServerApi.Services.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DsuDev.ProductsServerApi.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductServiceContext productServiceContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        internal ProductService(IProductServiceContext context)
        {
            this.productServiceContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool ProductExists(int id)
        {
            return this.productServiceContext.Products.Any(product => product.Id == id);
        }

        public int Insert(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            productServiceContext.Products.Add(product);
			return productServiceContext.SaveChanges();
        }

        public Product FindProduct(int productId)
        {
            return productServiceContext.Products.Find(productId);
        }

        public int Remove(Product product)
        {
            productServiceContext.Products.Remove(product);
			return productServiceContext.SaveChanges();
        }

        public int UpdateProducts(Product product)
        {
            productServiceContext.MarkAsModified(product);
            return productServiceContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts(bool stockOnly = false)
        {
            var products = productServiceContext.Products;

            return stockOnly 
                ? products.Where(p => p.StockQuantity > 0) 
                : products;
        }

        public IEnumerable<Product> GetProductsByName(string name, bool stockOnly = false)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return new List<Product>();
            }
            var products = productServiceContext.Products
                .Where(p => p.ProductName.Contains(name.Trim(), StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(o => o.StockQuantity);
            
            return stockOnly 
                ? products.Where(p => p.StockQuantity > 0) 
                : products;
        }
    }
}

using DsuDev.ProductsServerApi.Domain.Entities;
using DsuDev.ProductsServerApi.Services.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DsuDev.ProductsServerApi.Services
{
    public class ProductService
    {
        private readonly IProductServiceContext productServiceContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ProductService(IProductServiceContext context)
        {
            this.productServiceContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool ProductExists(int id)
        {
            return this.productServiceContext.Products.Any(product => product.Id == id);
        }

        public void Insert(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            productServiceContext.Products.Add(product);
			productServiceContext.SaveChanges();
        }
    }
}

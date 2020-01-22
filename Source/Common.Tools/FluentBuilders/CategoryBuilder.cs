using System.Collections.Generic;
using DsuDev.ProductsServer.Domain.Entities;

namespace DsuDev.ProductsServer.Common.Tools.FluentBuilders
{
    public class CategoryBuilder
    {
        private int _id;
        private string _name;
        private List<Product> _products;

        public CategoryBuilder CreateProduct()
        {
            this._id = 0;
            this._name = string.Empty;
            this._products = new List<Product>();
            return this;
        }

        public CategoryBuilder WithId(int identifier)
        {
            this._id = identifier;
            return this;
        }

        public CategoryBuilder WithName(string categoryName)
        {
            this._name = categoryName;
            return this;
        }

        public CategoryBuilder WithProduct(Product product)
        {
            this._products.Add(product);
            return this;
        }
        
        public CategoryBuilder WithProductCollection(ICollection<Product> products)
        {
            this._products.AddRange(products);
            return this;
        }

        public Category Build()
        {
            return new Category
            {
                Id = this._id,
                CategoryName = this._name,
                Products = this._products
            };
        }
    }
}

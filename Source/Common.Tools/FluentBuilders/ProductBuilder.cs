using DsuDev.ProductsServer.Domain.Entities;

namespace DsuDev.ProductsServer.Common.Tools.FluentBuilders
{
    public class ProductBuilder
    {
        private int _id;
        private string _name;
        private string _category;
        private decimal _price;
        private int _quantity;

        public ProductBuilder CreateProduct()
        {
            this._id = 0;
            this._name = string.Empty;
            this._category = string.Empty;
            this._price = 0;
            this._quantity = 0;
            return this;
        }

        public ProductBuilder WithId(int identifier)
        {
            this._id = identifier;
            return this;
        }

        public ProductBuilder WithName(string productName)
        {
            this._name = productName;
            return this;
        }

        public ProductBuilder WithCategory(string productCategory)
        {
            this._category = productCategory;
            return this;
        }

        public ProductBuilder WithPrice(decimal productPrice)
        {
            this._price = productPrice;
            return this;
        }

        public ProductBuilder WithStockQuantity(int stockQuantity)
        {
            this._quantity = stockQuantity;
            return this;
        }

        public Product Build()
        {
            return new Product
            {
                Id = this._id,
                ProductName = this._name,
                Category = this._category,
                Price = this._price,
                StockQuantity = _quantity
            };
        }
    }
}
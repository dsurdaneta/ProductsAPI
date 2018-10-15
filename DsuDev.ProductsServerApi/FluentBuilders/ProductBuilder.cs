using DsuDev.ProductsServerApi.Models;

namespace DsuDev.ProductsServerApi.FluentBuilders
{
    public class ProductBuilder
    {
        private int id;
        private string name;
        private string category;
        private decimal price;
        private int quantity;

        public ProductBuilder CreateProduct()
        {
            this.id = 0;
            this.name = string.Empty;
            this.category = string.Empty;
            this.price = 0;
            this.quantity = 0;
            return this;
        }

        public ProductBuilder WithId(int identifier)
        {
            this.id = identifier;
            return this;
        }

        public ProductBuilder WithName(string productName)
        {
            this.name = productName;
            return this;
        }

        public ProductBuilder WithCategory(string productCategory)
        {
            this.category = productCategory;
            return this;
        }

        public ProductBuilder WithPrice(decimal productPrice)
        {
            this.price = productPrice;
            return this;
        }

        public ProductBuilder WithStockQuantity(int stockQuantity)
        {
            this.quantity = stockQuantity;
            return this;
        }

        public Product Build()
        {
            return new Product
            {
                Id = this.id,
                ProductName = this.name,
                Category = this.category,
                Price = this.price,
                StockQuantity = quantity
            };
        }
    }
}
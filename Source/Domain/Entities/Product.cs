using System.ComponentModel.DataAnnotations;

namespace DsuDev.ProductsServer.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Category { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public Product() : this("Undefined", 1, "Undefined")
        {
            
        }

        public Product(string name, int quantity, string category)
        {
            this.Initializer(name, quantity, category);
        }

        public void Initializer(string name, int quantity = 1, string category = null)
        {
            Id = 0;
            ProductName = name;
            Category = category ?? string.Empty;
            Price = 0;
            StockQuantity = quantity;
        }
    }
}
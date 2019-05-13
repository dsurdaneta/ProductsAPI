using System.ComponentModel.DataAnnotations;

namespace DsuDev.ProductsServerApi.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
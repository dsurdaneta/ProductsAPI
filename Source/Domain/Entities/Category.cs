using System.Collections.Generic;

namespace DsuDev.ProductsServer.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        {
            Id = 0;
            CategoryName = "Undefined";
            Products = new List<Product>();
        }
    }
}

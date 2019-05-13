using System.Collections.Generic;

namespace DsuDev.ProductsServerApi.Domain.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}

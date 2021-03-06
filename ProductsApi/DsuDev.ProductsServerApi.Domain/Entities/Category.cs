﻿using System.Collections.Generic;

namespace DsuDev.ProductsServerApi.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}

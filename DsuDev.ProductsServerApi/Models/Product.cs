using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DsuDev.ProductsServerApi.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		[Required]
		public string ProductName { get; set; }
		public string Category { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
	}
}
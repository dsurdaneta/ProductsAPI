﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DsuDev.ProductsServerApi.Models
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
	}
}
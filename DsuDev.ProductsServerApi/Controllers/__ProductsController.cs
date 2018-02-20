using DsuDev.ProductsServerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DsuDev.ProductsServerApi.Controllers
{
	//public class ProductsController : ApiController
	//{
	//	Product[] products = new Product[]
	//	{
	//		new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
	//		new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
	//		new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
	//	};

	//	private ProductServiceContext db = new ProductServiceContext();

	//	public IEnumerable<Product> GetAllProducts()
	//	{
	//		return products;
	//	}

	//	public IHttpActionResult GetProduct(int id)
	//	{
	//		var product = products.FirstOrDefault((p) => p.Id == id);
	//		if (product == null)
	//		{
	//			return NotFound();
	//		}
	//		return Ok(product);
	//	}

	//	public IHttpActionResult GetProductsByName(string name)
	//	{
	//		var products = this.products.Where((p) => p.Name.Contains(name.Trim()) ).OrderBy(o => o.StockQuantity).ToList();
	//		if (products.Count == 0)
	//		{
	//			return NotFound();
	//		}
	//		return base.Ok(products);
	//	}

	//	public IHttpActionResult GetProductsInStockByName(string name)
	//	{
	//		var products = this.products.Where((p) => p.Name.Contains(name.Trim()) && p.StockQuantity > 0).ToList();
	//		if (products.Count == 0)
	//		{
	//			return NotFound();
	//		}
	//		return base.Ok(products);
	//	}
	//}
}

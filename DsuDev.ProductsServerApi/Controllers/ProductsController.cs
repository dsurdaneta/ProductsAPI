using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DsuDev.ProductsServerApi.Models;
using Newtonsoft.Json;

namespace DsuDev.ProductsServerApi.Controllers
{
	[RoutePrefix("api/Products")]
	public class ProductsController : ApiController
    {
        private IProductServiceContext db = new ProductServiceContext();

		public ProductsController() { }

		public ProductsController(IProductServiceContext context)
		{
			db = context;
		}
		
		// GET: api/Products
		[HttpGet]
		[Route("")]
		public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

		// GET: api/Products/5
		[HttpGet]
		[Route("{id:int}")]
		[ResponseType(typeof(Product))]
		public IHttpActionResult GetProduct(int id)
		{
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
		[HttpPut]
		[Route("{id:int}")]
		[ResponseType(typeof(void))]
		public IHttpActionResult PutProduct(int id, Product product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != product.Id)
			{
				return BadRequest();
			}

			db.MarkAsModified(product);

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return StatusCode(HttpStatusCode.NoContent);
		}

		// PUT: api/Products/5/Destock/2
		[HttpPut]
		[Route("{id:int}/Destock/{quantity:int}")]
		[ResponseType(typeof(void))]
		public IHttpActionResult PutDestockProduct(int id, int quantity)
		{
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return NotFound();
			}

			product.StockQuantity -= quantity;

			if (product.StockQuantity < 0)
			{
				product.StockQuantity = 0;
			}

			return PutProduct(id, product);			
		}

		// PUT: api/Products/5/Restock/2
		[HttpPut]
		[Route("{id:int}/Restock/{quantity:int}")]
		[ResponseType(typeof(void))]
		public IHttpActionResult PutRestockProduct(int id, int quantity)
		{
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return NotFound();
			}

			product.StockQuantity += quantity;
			
			return PutProduct(id, product);			
		}

		// POST: api/Products
		[HttpPost]
		[Route("")]
		[ResponseType(typeof(Product))]
		public IHttpActionResult PostProduct(Product product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Products.Add(product);
			db.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
		}

		// DELETE: api/Products/5
		[HttpDelete]
		[Route("{id:int}")]
		[ResponseType(typeof(Product))]
		public IHttpActionResult DeleteProduct(int id)
		{
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return NotFound();
			}

			if(product.StockQuantity > 0)
			{
				return BadRequest("Product still exist in stock.");
			}

			db.Products.Remove(product);
			db.SaveChanges();

			return Ok(product);
		}

		[NonAction]
		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

		[NonAction]
		private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }

		// GET: api/Products/ByName/Hammer		
		[HttpGet]
		[Route("ByName/{name}")]
		[ResponseType(typeof(Product))]
		[ActionName("ByName")]
		public IHttpActionResult GetProductsByName(string name)
		{
			var products = db.Products.Where(p => p.ProductName.Contains(name.Trim())).OrderBy(o => o.StockQuantity).ToList();
			if (products.Count == 0)
			{
				return NotFound();
			}
			return base.Ok(products);
		}

		// GET: api/Products/InStockByName/Tomato
		[HttpGet]
		[Route("InStockByName/{name}")]
		[ActionName("InStockByName")]
		public IHttpActionResult GetProductsInStockByName(string name)
		{
			var products = db.Products.Where(p => p.ProductName.Contains(name.Trim()) && p.StockQuantity > 0).ToList();
			if (products.Count == 0)
			{
				return NotFound();
			}
			return base.Ok(products);
		}

		// GET: api/Products/InStock
		[HttpGet]
		[Route("InStock")]
		public IQueryable<Product> GetProductsInStock()
		{
			var inStockProducts = db.Products.Where(p => p.StockQuantity > 0);
			return inStockProducts;
		}
	}
}
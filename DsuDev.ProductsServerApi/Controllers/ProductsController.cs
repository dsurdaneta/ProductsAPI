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

namespace DsuDev.ProductsServerApi.Controllers
{
	[RoutePrefix("api/Products")]
	public class ProductsController : ApiController
    {
        private ProductServiceContext db = new ProductServiceContext();

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
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
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
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

        // POST: api/Products
		[HttpPost]
		[Route("")]
		[ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
		[HttpDelete]
		[Route("{id:int}")]
		[ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

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
			var products = db.Products.Where((p) => p.Name.Contains(name.Trim())).OrderBy(o => o.StockQuantity).ToList();
			if (products.Count == 0)
			{
				return NotFound();
			}
			return base.Ok(products);
		}

		// GET: api/Products/InStockByName/Hammer
		[HttpGet]
		[Route("InStockByName/{name}")]
		[ResponseType(typeof(Product))]
		[ActionName("InStockByName")]
		public IHttpActionResult GetProductsInStockByName(string name)
		{
			var products = db.Products.Where((p) => p.Name.Contains(name.Trim()) && p.StockQuantity > 0).ToList();
			if (products.Count == 0)
			{
				return NotFound();
			}
			return base.Ok(products);
		}

		// GET: api/Products/InStock
		[HttpGet]
		[Route("InStock")]
		[ActionName("InStock")]
		public IQueryable<Product> GetProductsInStock()
		{
			return db.Products.Where((p) => p.StockQuantity > 0);
		}
	}
}
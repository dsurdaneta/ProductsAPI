using System.Linq;
using DsuDev.ProductsServerApi.Domain.Entities;

namespace DsuDev.ProductsServerApi.Tests.Models
{
    /// <summary>
    ///  Mocking class
    /// </summary>
    class TestProductDbSet : TestDbSet<Product>
	{
		public override Product Find(params object[] keyValues)
		{
			return this.SingleOrDefault(product => product.Id == (int)keyValues.Single());
		}
	}
}

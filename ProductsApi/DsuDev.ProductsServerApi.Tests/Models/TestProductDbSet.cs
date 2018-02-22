using DsuDev.ProductsServerApi.Models;
using System.Linq;

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

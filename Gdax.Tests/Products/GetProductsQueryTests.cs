using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Products
{
	public class GetProductsQueryTests
	{
		[Fact]
		public async Task GetProducts_ShouldReturnTheCurrentCurrencies()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var products = await client.GetProducts();

			products.ShouldNotBeEmpty();
		}
	}
}

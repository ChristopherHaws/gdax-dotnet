using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Products
{
	public class GetProductsQueryTests
	{
		[Fact]
		public async Task GetProductsAsync_ShouldReturnTheCurrentCurrencies()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var products = await client.GetProductsAsync();

			products.ShouldNotBeEmpty();
		}
	}
}

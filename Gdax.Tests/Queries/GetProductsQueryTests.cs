using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gdax.Queries
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

			products.Should().NotBeEmpty();
		}
	}
}

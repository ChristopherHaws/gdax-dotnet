using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Products
{
	public class GetProductTickerQueryTests
	{
		[Fact]
		public async Task GetProductTickerAsync_ShouldReturnTheCurrentCurrencyPrices()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var ticker = await client.GetProductTickerAsync("BTC-USD");

			ticker.ShouldNotBeNull();
			ticker.Price.ShouldBeGreaterThan(0);
		}
	}
}

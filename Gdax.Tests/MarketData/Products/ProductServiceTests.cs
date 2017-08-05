using System.Threading.Tasks;
using FluentAssertions;
using Gdax.Authentication;
using Xunit;

namespace Gdax.MarketData.Products.Tests
{
	public class ProductServiceTests
	{
		[Fact]
		public async Task GetProductsAsync_ShouldReturnTheCurrentCurrencies()
		{
			var auth = new GdaxAuthenticator("", "", "");
			var client = new GdaxClient(auth);

			var products = await client.MarketData.Products.GetProductsAsync();

			products.Should().NotBeEmpty();
		}

		[Fact]
		public async Task GetProductTickerAsync_ShouldReturnTheCurrentCurrencyPrices()
		{
			var auth = new GdaxAuthenticator("", "", "");
			var client = new GdaxClient(auth);

			var ticker = await client.MarketData.Products.GetProductTickerAsync("BTC-USD");

			ticker.Should().NotBeNull();
			ticker.Price.Should().BeGreaterThan(0);
		}

		[Fact]
		public async Task GetOrderBookAsync_ShouldReturnTheCurrentOrderBook()
		{
			var auth = new GdaxAuthenticator("", "", "");
			var client = new GdaxClient(auth);

			var book = await client.MarketData.Products.GetOrderBookAsync("BTC-USD");

			book.Should().NotBeNull();
		}
	}
}

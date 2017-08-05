using System;
using System.Threading.Tasks;
using FluentAssertions;
using Gdax.Tests;
using Xunit;

namespace Gdax.MarketData.Products.Tests
{
	public class ProductServiceTests
	{
		[Fact]
		public async Task GetProductsAsync_ShouldReturnTheCurrentCurrencies()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var products = await client.MarketData.Products.GetProductsAsync();

			products.Should().NotBeEmpty();
		}

		[Fact]
		public async Task GetProductTickerAsync_ShouldReturnTheCurrentCurrencyPrices()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var ticker = await client.MarketData.Products.GetProductTickerAsync("BTC-USD");

			ticker.Should().NotBeNull();
			ticker.Price.Should().BeGreaterThan(0);
		}

		[Fact]
		public async Task GetOrderBookAsync_ShouldReturnTheCurrentOrderBook()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var book = await client.MarketData.Products.GetOrderBookAsync("BTC-USD");

			book.Should().NotBeNull();
		}

		[Fact]
		public async Task GetHistoricRatesAsync_ShouldReturnTheHistoricRates()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var history = await client.MarketData.Products.GetHistoricRatesAsync("BTC-USD", DateTime.UtcNow.AddMinutes(-10), DateTime.UtcNow, 30);

			history.Should().NotBeNull();
		}
	}
}

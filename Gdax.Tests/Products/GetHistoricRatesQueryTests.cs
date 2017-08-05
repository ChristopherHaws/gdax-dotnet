using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gdax.Products
{
	public class GetHistoricRatesQueryTests
	{
		[Fact]
		public async Task GetHistoricRatesAsync_ShouldReturnTheHistoricRates()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var history = await client.GetHistoricRatesAsync("BTC-USD", DateTime.UtcNow.AddMinutes(-10), DateTime.UtcNow, 30);

			history.Should().NotBeNull();
		}
	}
}

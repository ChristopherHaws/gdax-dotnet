using System;
using System.Threading.Tasks;
using Gdax.Models;
using Shouldly;
using Xunit;

namespace Gdax.Products
{
	public class GetHistoricRatesQueryTests
	{
		[Fact]
		public async Task GetHistoricRates_ShouldReturnTheHistoricRates()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var minusDays = -10;
			var history = await client.GetHistoricRates("BTC-USD", DateTime.UtcNow.AddDays(minusDays), DateTime.UtcNow, MarketPeriod.Day);
			var index = history.Count;

			history.ShouldNotBeNull();
		}
	}
}

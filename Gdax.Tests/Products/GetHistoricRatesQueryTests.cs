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

			// Get index count
			index.ShouldBeGreaterThanOrEqualTo(minusDays);

			history.ShouldNotBeNull();

			// Last 20 Closes
			for (Int32 i = index - 1; i >= index - 5; i--)
			{
				var closeprices = String.Format("{0}", history[i].Close);
				// Price close prices for 5 bars
				Console.WriteLine(closeprices);

				closeprices.ShouldNotStartWith(((Int32)0).ToString());
			}
		}
	}
}

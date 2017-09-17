using System;
using System.Threading.Tasks;
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

			var history = await client.GetHistoricRates("BTC-USD", DateTime.UtcNow.AddMinutes(-10), DateTime.UtcNow, 30);

			history.ShouldNotBeNull();
		}
	}
}

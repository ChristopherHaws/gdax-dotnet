using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Products
{
	public class GetOrderBookQueryTests
	{
		[Fact]
		public async Task GetOrderBookAsync_ShouldReturnTheCurrentOrderBook()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var book = await client.GetOrderBookAsync("BTC-USD");

			book.ShouldNotBeNull();
		}
	}
}

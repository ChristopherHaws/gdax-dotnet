using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Products
{
	public class GetOrderBookQueryTests
	{
		[Fact]
		public async Task GetOrderBook_ShouldReturnTheCurrentOrderBook()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var book = await client.GetOrderBook("BTC-USD");

			book.ShouldNotBeNull();
		}
	}
}

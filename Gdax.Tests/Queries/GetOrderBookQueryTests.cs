using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gdax.Queries
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

			book.Should().NotBeNull();
		}
	}
}

using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Times
{
	public class GetServerTimeQueryTests
	{
		[Fact]
		public async Task GetServerTimeAsync_ReturnsTheCurrentTime()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var time = await client.GetServerTimeAsync();

			time.Iso.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(30));
		}
	}
}

using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Times
{
	public class GetServerTimeQueryTests
	{
		[Fact]
		public async Task GetServerTime_ReturnsTheCurrentTime()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var time = await client.GetServerTime();

			time.Iso.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(30));
		}
	}
}

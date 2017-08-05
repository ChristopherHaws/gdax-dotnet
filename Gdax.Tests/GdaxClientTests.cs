using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gdax.Tests
{
	public class GdaxClientTests
	{
		[Fact]
		public async Task GetServerTime_ReturnsTheCurrentTime()
		{
			var client = new GdaxClient(TestAuthenticators.Unauthorized)
			{
				UseSandbox = true
			};

			var time = await client.GetServerTimeAsync();

			time.Iso.Should().BeCloseTo(DateTime.UtcNow, 30 * 1000);
		}
	}
}

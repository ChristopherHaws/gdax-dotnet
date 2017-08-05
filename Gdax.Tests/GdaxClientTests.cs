using System;
using System.Threading.Tasks;
using FluentAssertions;
using Gdax.Authentication;
using Xunit;

namespace Gdax.Tests
{
	public class GdaxClientTests
	{
		[Fact]
		public async Task GetServerTime_ReturnsTheCurrentTime()
		{
			var auth = new GdaxAuthenticator("", "", "");
			var client = new GdaxClient(auth);

			var time = await client.GetServerTimeAsync();

			time.Iso.Should().BeCloseTo(DateTime.UtcNow, 30 * 1000);
		}
	}
}

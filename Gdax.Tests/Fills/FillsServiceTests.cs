using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gdax.Tests.Fills
{
	public class FillsServiceTests
	{
		[Fact]
		public async Task ListFills_ShouldListTheFills()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var fills = await client.Fills.ListFills();

			fills.Should().NotBeNull();
		}
	}
}

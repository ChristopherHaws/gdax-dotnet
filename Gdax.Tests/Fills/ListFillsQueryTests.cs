using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gdax.Fills
{
	public class ListFillsQueryTests
	{
		[Fact]
		public async Task ListFills_ShouldListTheFills()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var fills = await client.GetFillsAsync();

			fills.Should().NotBeNull();
		}
		
		[Fact]
		public async Task ListFills_ShouldAllowNextAndPreviousPage()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var fills = await client.GetFillsAsync(paging: new PagingOptions<Int32?>
			{
				Limit = 1
			});
			
			var fillsPage2 = await client.GetFillsAsync(paging: fills.OlderPage());
			var fillsPage1 = await client.GetFillsAsync(paging: fillsPage2.NewerPage());

			fills.Should().NotBeNull();
			fills.Results.Should().HaveCount(1);

			fillsPage2.Should().NotBeNull();
			fillsPage2.Results.Should().HaveCount(1);
			fillsPage2.Results.Should().NotContain(x => x.OrderId == fills.Results.First().OrderId);

			fillsPage1.Should().NotBeNull();
			fillsPage1.Results.Should().HaveCount(1);
			fillsPage1.Results.Should().Contain(x => x.OrderId == fills.Results.First().OrderId);
		}
	}
}

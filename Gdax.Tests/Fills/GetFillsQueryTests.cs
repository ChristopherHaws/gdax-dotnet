using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Fills
{
	public class GetFillsQueryTests
	{
		[Fact]
		public async Task GetFills_ShouldListTheFills()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var fills = await client.GetFills();

			fills.ShouldNotBeNull();
		}
		
		[Fact]
		public async Task GetFills_ShouldAllowOlderAndNewerPage()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var fills = await client.GetFills(paging: new PagingOptions<Int32?>
			{
				Limit = 1
			});
			
			var fillsPage2 = await client.GetFills(paging: fills.OlderPage());
			var fillsPage1 = await client.GetFills(paging: fillsPage2.NewerPage());

			fills.ShouldNotBeNull();
			fills.Results.ShouldHaveSingleItem();

			fillsPage2.ShouldNotBeNull();
			fillsPage2.Results.ShouldHaveSingleItem();
			fillsPage2.Results.ShouldNotContain(x => x.OrderId == fills.Results.First().OrderId);

			fillsPage1.ShouldNotBeNull();
			fillsPage1.Results.ShouldHaveSingleItem();
			fillsPage1.Results.ShouldContain(x => x.OrderId == fills.Results.First().OrderId);
		}
	}
}

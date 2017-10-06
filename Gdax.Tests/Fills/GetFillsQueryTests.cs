using System;
using System.Linq;
using System.Threading.Tasks;
using Gdax.Models;
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

			var accounts = await client.GetCoinbaseAccounts();
			var btcAccount = accounts.First(x => x.Currency == "BTC");

			if (btcAccount.Balance > 0)
			{
				await client.DepositFromCoinbase(10, btcAccount.Currency, btcAccount.Id);
			}

			await client.PlaceMarketOrder(Side.Sell, "BTC-USD", 0.01m);
			await client.PlaceMarketOrder(Side.Sell, "BTC-USD", 0.02m);
			await client.PlaceMarketOrder(Side.Sell, "BTC-USD", 0.03m);
			await client.PlaceMarketOrder(Side.Sell, "BTC-USD", 0.04m);

			var fills = await client.GetFills(paging: new PagingOptions<Int32?>
			{
				Limit = 1
			});
			
			var fillsPage2 = await client.GetFills(paging: fills.NextPage());
			var fillsPage1 = await client.GetFills(paging: fillsPage2.PreviousPage());

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

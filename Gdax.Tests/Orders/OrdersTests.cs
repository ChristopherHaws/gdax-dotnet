using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Gdax.Models;
using Shouldly;
using Xunit;

namespace Gdax.Tests.Orders
{
    public class OrdersTests
    {
		public static GdaxClient client = new GdaxClient(TestAuthenticators.FullAccess)
		{
			UseSandbox = true
		};

		[Fact]
		public async Task TestAllOrderFunctions()
		{
			var marketOrder = await client.PlaceMarketOrder(Side.Buy, "BTC-USD", 0.1m).ConfigureAwait(false);
			marketOrder.ShouldBeNull();

			var limitOrder = await client.PlaceLimitOrder(Side.Sell, "BTC-USD", 0.1m, 8000m).ConfigureAwait(false);
			limitOrder.ShouldNotBeNull();

			var stopOrder = await client.PlaceStopOrder(Side.Sell, "BTC-USD", 0.1m, 3000m).ConfigureAwait(false);
			stopOrder.ShouldNotBeNull();
		}


		[Fact]
		public static async Task ListOrders()
		{
			var orders = await client.GetOrders().ConfigureAwait(false);

			foreach (var o in orders.Results)
			{
				Debug.WriteLine("Pair {0} | Size {1} | Created at {2} | Side {3}", o.ProductId, o.Size, o.CreatedAt, o.Side);

				orders.ShouldBeNull();
			}
		}

		[Fact]
		public static async Task DeleteOrders()
		{
			var orders = await client.GetOrders("open").ConfigureAwait(false);

			if (orders.Results.Count > 0)
			{
				var cancelOrder = await client.CancelAllOrders().ConfigureAwait(false);
				cancelOrder.ShouldBeNull();
			}
		}
	}
}

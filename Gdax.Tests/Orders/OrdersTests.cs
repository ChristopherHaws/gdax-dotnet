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
			await TestMarketOrder(Side.Sell, "ETH-EUR", 0.1m).ConfigureAwait(false);

			await TestLimitOrder(Side.Sell, "ETH-EUR", 0.1m, 500m).ConfigureAwait(false);

			await TestStopOrder(Side.Buy, "ETH-EUR", 0.1m, 150m).ConfigureAwait(false);

			await ListOrders().ConfigureAwait(false);

			await DeleteOrders().ConfigureAwait(false);
		}

		public static async Task TestMarketOrder(Side side, String currency, Decimal amount = 0m)
		{
			Debug.WriteLine("Sending Order");

			var marketOrder = await client.PlaceMarketOrder(side, currency, amount).ConfigureAwait(false);

			Debug.WriteLine("Test Market");
		}

		public static async Task TestLimitOrder(Side side, String currency, Decimal size, Decimal price)
		{
			Debug.WriteLine("Sending Order");

			var limitOrder = await client.PlaceLimitOrder(side, currency, size, price).ConfigureAwait(false);

			Debug.WriteLine("Test Limit Order");
		}

		public static async Task TestStopOrder(Side side, String currency, Decimal size, Decimal price)
		{
			Debug.WriteLine("Sending Order");

			var limitOrder = await client.PlaceLimitOrder(side, currency, size, price).ConfigureAwait(false);

			Debug.WriteLine("Test Stop Order");
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

			foreach (var o in orders.Results)
			{
				Debug.WriteLine("STATUS {0}", o.Status);
				Debug.WriteLine("ORDER ID {0}", o.OrderId);
			}

			if (orders.Results.Count > 0)
			{
				var cancelOrder = await client.CancelAllOrders().ConfigureAwait(false);
				cancelOrder.ShouldBeNull();
			}
		}
	}
}

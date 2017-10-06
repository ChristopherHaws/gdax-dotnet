using System;
using System.Linq;
using System.Threading.Tasks;
using Gdax.Models;
using Shouldly;
using Xunit;

namespace Gdax.Tests.Orders
{
	public class GetOrdersQueryTests
	{
		[Fact]
		public async Task GetOrders_ShouldListTheOrders()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var Orders = await client.GetOrders(states: OrderStates.All);

			Orders.ShouldNotBeNull();
		}

		[Fact]
		public async Task GetOrders_ShouldAllowOlderAndNewerPage()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var orders = await client.GetOrders(states: OrderStates.All, paging: new PagingOptions<DateTime?>
			{
				Limit = 1
			});

			var ordersPage2 = await client.GetOrders(paging: orders.NextPage());
			var ordersPage1 = await client.GetOrders(paging: ordersPage2.PreviousPage());

			orders.ShouldNotBeNull();
			orders.Results.ShouldHaveSingleItem();

			ordersPage2.ShouldNotBeNull();
			ordersPage2.Results.ShouldHaveSingleItem();
			ordersPage2.Results.ShouldNotContain(x => x.OrderId == orders.Results.First().OrderId);

			ordersPage1.ShouldNotBeNull();
			ordersPage1.Results.ShouldHaveSingleItem();
			ordersPage1.Results.ShouldContain(x => x.OrderId == orders.Results.First().OrderId);
		}
	}
}

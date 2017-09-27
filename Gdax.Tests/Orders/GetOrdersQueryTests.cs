using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

			var Orders = await client.GetOrders();

			Orders.ShouldNotBeNull();
		}

		[Fact]
		public async Task GetOrders_ShouldAllowOlderAndNewerPage()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var Orders = await client.GetOrders(paging: new PagingOptions<Int32?>
			{
				Limit = 1
			});

			var OrdersPage2 = await client.GetOrders(paging: Orders.OlderPage());
			var OrdersPage1 = await client.GetOrders(paging: OrdersPage2.NewerPage());

			Orders.ShouldNotBeNull();
			Orders.Results.ShouldHaveSingleItem();

			OrdersPage2.ShouldNotBeNull();
			OrdersPage2.Results.ShouldHaveSingleItem();
			OrdersPage2.Results.ShouldNotContain(x => x.Id == Orders.Results.First().Id);

			OrdersPage1.ShouldNotBeNull();
			OrdersPage1.Results.ShouldHaveSingleItem();
			OrdersPage1.Results.ShouldContain(x => x.Id == Orders.Results.First().Id);
		}
	}
}

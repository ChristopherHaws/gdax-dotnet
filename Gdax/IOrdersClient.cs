using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IOrdersClient
	{
		Task<Order> SubmitMarketOrder(Side side, String productId, Decimal size, OrderType orderType = OrderType.market);

		Task<Order> SubmitMarketOrderFiat(Side side, String productId, Decimal funds, OrderType orderType = OrderType.market);

		Task<Order> SubmitLimitOrder(Side side, String productId, Decimal size, Decimal price, OrderType orderType);

		Task<Order> SubmitStopOrderFiat(Side side, String productId, Decimal price, Decimal funds, OrderType orderType = OrderType.stop);

		Task<PagedResults<Order, Int32?>> ListOrders(String orderStatus = null, PagingOptions<Int32?> paging = null);

		Task<IList<Order>> CancelOrders(string productID);


	}
}

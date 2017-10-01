using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IOrdersClient
	{
		Task<Order> SubmitMarketOrder(Side side, String productId, Decimal size);

		Task<Order> SubmitMarketOrderFiat(Side side, String productId, Decimal funds);

		Task<Order> SubmitLimitOrder(Side side, String productId, Decimal size, Decimal price);

		Task<Order> SubmitStopOrderFiat(Side side, String productId, Decimal price, Decimal funds);

		Task<PagedResults<Order, Int32?>> ListOpenOrders(String productId = null, OrderStates? states = null, PagingOptions<Int32?> paging = null);

		Task<IList<Guid>> CancelAllOrders(String productID = null);
	}
}

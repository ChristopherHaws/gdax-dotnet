using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IOrdersClient
	{
		Task<Order> SubmitMarketOrderBySize(Side side, String productId, Decimal size, OrderType orderType = OrderType.Market);

		Task<PagedResults<Order, Int32?>> ListOrders(String orderStatus = null, PagingOptions<Int32?> paging = null);

		Task<IList<Order>> CancelOrders(string productID);


	}
}

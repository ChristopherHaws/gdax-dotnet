using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IOrdersClient
	{
		/// <summary>
		/// Places a market order in the base currency.
		/// </summary>
		/// <param name="side">The side.</param>
		/// <param name="productId">The product identifier.</param>
		/// <param name="amount">Indicates the amount of base currency to buy or sell.</param>
		/// <returns></returns>
		Task<Order> PlaceMarketOrder(Side side, String productId, Decimal amount);

		/// <summary>
		/// Places a market order in the quote currency.
		/// </summary>
		/// <param name="side">The side.</param>
		/// <param name="productId">The product identifier.</param>
		/// <param name="amount">Indicates the amount of quote currency to buy or sell.</param>
		/// <returns></returns>
		Task<Order> PlaceMarketOrderInQuoteCurrency(Side side, String productId, Decimal amount);

		Task<Order> PlaceLimitOrder(Side side, String productId, Decimal amount, Decimal limitPrice);

		Task<Order> PlaceStopOrder(Side side, String productId, Decimal price, Decimal amount);

		Task<Order> PlaceStopOrderInQuoteCurrency(Side side, String productId, Decimal price, Decimal amount);

		Task<Order> PlaceOrderAdvanced(OrderRequest order);

		/// <summary>
		/// Gets the orders. If no states are provided, only open, pending, and active orders will be returned.
		/// </summary>
		/// <param name="productId">Limit returned orders to a specific product.</param>
		/// <param name="states">Limit returned orders to these statuses.</param>
		/// <param name="paging">The paging.</param>
		/// <returns></returns>
		Task<PagedResults<Order, DateTime?>> GetOrders(String productId = null, OrderStates? states = null, PagingOptions<DateTime?> paging = null);

		Task CancelOrder(String orderId);

		Task<IList<Guid>> CancelAllOrders(String productID = null);
	}
}

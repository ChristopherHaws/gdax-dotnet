using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gdax.MarketData.Products
{
	public interface IProductService
	{
		/// <summary>
		/// Get a list of available currency pairs for trading.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Product>> GetProductsAsync();

		/// <summary>
		/// Gets snapshot information about the last trade (tick), best bid/ask, and 24h volume.
		/// </summary>
		/// <remarks>
		/// Polling is discouraged in favor of connecting via the websocket stream and listening for match messages.
		/// </remarks>
		/// <param name="productId">The product identifier.</param>
		/// <returns></returns>
		Task<ProductTicker> GetProductTickerAsync(String productId);

		/// <summary>
		/// Get a list of open orders for a product. The amount of detail shown can be customized with the level parameter.
		/// </summary>
		/// <param name="productId">The product identifier.</param>
		/// <param name="level">Select response detail. Valid levels are documented below.</param>
		/// <returns></returns>
		Task<OrderBook> GetOrderBookAsync(String productId, Int32 level = 1);
	}
}

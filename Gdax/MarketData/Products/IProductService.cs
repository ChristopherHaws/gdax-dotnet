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
		/// <param name="productId">The currency pair.</param>
		/// <param name="level">Select response detail. Valid levels are documented below.</param>
		/// <returns></returns>
		Task<OrderBook> GetOrderBookAsync(String productId, Int32 level = 1);

		/// <summary>
		///		<para>
		///			Gets the historic rates for a product. Rates are returned in grouped buckets based on requested granularity.
		///		</para>
		///		<para>
		///			The maximum number of data points for a single request is 200 candles. If your selection of start/end time and granularity
		///			will result in more than 200 data points, your request will be rejected. If you wish to retrieve fine granularity data over
		///			a larger time range, you will need to make multiple requests with new start/end ranges.
		///		</para>
		/// </summary>
		/// <remarks>
		/// Historical rate data may be incomplete. No data is published for intervals where there are no ticks.
		/// Historical rates should not be polled frequently. If you need real-time information, use the trade and book endpoints along with the websocket feed.
		/// </remarks>
		/// <param name="productId">The currency pair.</param>
		/// <param name="start">Start time in ISO 8601.</param>
		/// <param name="end">End time in ISO 8601.</param>
		/// <param name="granularity">Desired timeslice in seconds.</param>
		/// <returns></returns>
		Task<IEnumerable<HistoricRate>> GetHistoricRatesAsync(String productId, DateTime start, DateTime end, Int32 granularity);
	}
}

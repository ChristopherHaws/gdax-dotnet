using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gdax.Products
{
	/// <summary>
	/// Get a list of open orders for a product. The amount of detail shown can be customized with the level parameter.
	/// </summary>
	/// <param name="productId">The currency pair.</param>
	/// <param name="level">Select response detail. Valid levels are documented below.</param>
	/// <returns></returns>
	public static class GetOrderBookQuery
	{
		public static async Task<OrderBook> GetOrderBookAsync(this GdaxClient client, String productId, OrderBookLevel level = OrderBookLevel.Level1)
		{
			Check.NotNull(client, nameof(client));
			Check.NotNullOrWhiteSpace(productId, nameof(productId));

			var request = new GdaxRequestBuilder($"/products/{productId}/book")
				.AddParameterIfNotNull("level", ((Int32)level).ToString())
				.Build();

			return (await client.GetResponseAsync<OrderBook>(request).ConfigureAwait(false)).Value;
		}

		public class OrderBook
		{
			[JsonProperty("sequence")]
			public Int64 Sequence { get; set; }

			[JsonProperty("bids")]
			public IList<String[]> Bids { get; set; }

			[JsonProperty("asks")]
			public IList<String[]> Asks { get; set; }
		}

		/// <summary>
		/// Levels 1 and 2 are aggregated and return the number of orders at each level.
		/// Level 3 is non-aggregated and returns the entire order book.
		/// </summary>
		public enum OrderBookLevel
		{
			/// <summary>
			/// Only the best bid and ask
			/// </summary>
			/// 
			Level1 = 1,
			/// <summary>
			/// Top 50 bids and asks (aggregated)
			/// </summary>
			Level2 = 2,

			/// <summary>
			/// Full order book (non aggregated)
			/// </summary>
			Level3 = 3
		}
	}
}

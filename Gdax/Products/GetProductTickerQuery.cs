using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gdax.Products
{
	public static class GetProductTickerQuery
	{
		/// <summary>
		/// Gets snapshot information about the last trade (tick), best bid/ask, and 24h volume.
		/// </summary>
		/// <remarks>
		/// Polling is discouraged in favor of connecting via the websocket stream and listening for match messages.
		/// </remarks>
		/// <param name="productId">The product identifier.</param>
		/// <returns></returns>
		public static async Task<ProductTicker> GetProductTickerAsync(this GdaxClient client, String productId)
		{
			Check.NotNull(client, nameof(client));
			Check.NotNullOrWhiteSpace(productId, nameof(productId));

			var request = new GdaxRequestBuilder($"/products/{productId}/ticker")
				.Build();

			var response = await client.GetResponseAsync<ProductTicker>(request).ConfigureAwait(false);

			if (response.Value != null)
			{
				response.Value.ProductId = productId;
			}

			return response.Value;
		}

		public class ProductTicker
		{
			[JsonProperty("product_id")]
			public String ProductId { get; set; }

			[JsonProperty("trade_id")]
			public String TradeId { get; set; }

			[JsonProperty("price")]
			public Decimal Price { get; set; }

			[JsonProperty("size")]
			public Decimal Size { get; set; }

			[JsonProperty("bid")]
			public Decimal Bid { get; set; }

			[JsonProperty("ask")]
			public Decimal Ask { get; set; }

			[JsonProperty("volume")]
			public Decimal Volume { get; set; }

			[JsonProperty("time")]
			public DateTime Time { get; set; }
		}
	}
	
}

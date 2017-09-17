using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gdax
{
	public static class GetFillsQuery
	{
		/// <summary>
		///		<para>
		///			Get a list of recent fills.
		///		</para>
		///		<para>
		///			Fees are recorded in two stages. Immediately after the matching engine completes a match, the fill is inserted
		///			into the datastore. Once the fill is recorded, a settlement process will settle the fill and credit both trading
		///			counterparties.
		///		</para>
		/// </summary>
		/// <remarks>
		/// Fills are returned sorted by descending trade_id from the largest trade_id to the smallest trade_id.
		/// </remarks>
		/// <param name="orderId">Limit list of fills to this order.</param>
		/// <param name="productId">Limit list of fills to this product.</param>
		/// <param name="paging">The paging options.</param>
		/// <returns></returns>
		public static async Task<PagedResults<Fill, Int32?>> GetFillsAsync(this GdaxClient client, String orderId = null, String productId = null, PagingOptions<Int32?> paging = null)
		{
			Check.NotNull(client, nameof(client));

			var request = new GdaxRequestBuilder("/fills")
				.AddParameterIfNotNull("order_id", orderId)
				.AddParameterIfNotNull("product_id", productId)
				.AddPagingOptions(paging, CursorEncoders.Int32)
				.Build();

			var response = await client.GetResponseAsync<IList<Fill>>(request).ConfigureAwait(false);

			return new PagedResults<Fill, Int32?>(response, CursorEncoders.Int32, paging);
		}

		[DebuggerDisplay("{TradeId} - {OrderId}")]
		public class Fill
		{
			[JsonProperty("trade_id")]
			public Int32 TradeId { get; set; }

			[JsonProperty("order_id")]
			public Guid OrderId { get; set; }

			[JsonProperty("product_id")]
			public String ProductId { get; set; }

			[JsonProperty("price")]
			public Decimal Price { get; set; }

			[JsonProperty("size")]
			public Decimal Size { get; set; }

			[JsonProperty("created_at")]
			public DateTime CreatedAt { get; set; }

			[JsonProperty("liquidity")]
			[JsonConverter(typeof(LiquidityTypeConverter))]
			public LiquidityType Liquidity { get; set; }

			[JsonProperty("fee")]
			public Decimal Fee { get; set; }

			[JsonProperty("settled")]
			public Boolean Settled { get; set; }

			[JsonProperty("side")]
			public Side Side { get; set; }
		}
	}
}

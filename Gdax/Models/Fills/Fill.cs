using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Gdax.Models
{
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
		public LiquidityType Liquidity { get; set; }

		[JsonProperty("fee")]
		public Decimal Fee { get; set; }

		[JsonProperty("settled")]
		public Boolean Settled { get; set; }

		[JsonProperty("side")]
		public Side Side { get; set; }
	}
}

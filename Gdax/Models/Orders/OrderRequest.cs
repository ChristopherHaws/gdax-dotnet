using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class OrderRequest
	{
		[JsonProperty("client_oid")]
		public Guid ClientOrderId { get; set; }

		[JsonProperty("side")]
		public Side Side { get; set; }

		[JsonProperty("type")]
		public OrderType Type { get; set; }

		[JsonProperty("product_id")]
		public String ProductId { get; set; }

		[JsonProperty("size")]
		public Decimal Size { get; set; }

		[JsonProperty("price")]
		public Decimal Price { get; set; }

		[JsonProperty("funds")]
		public Decimal Funds { get; set; }

		[JsonProperty("stp")]
		public SelfTradePrevention? SelfTradePrevention { get; set; }

		[JsonProperty("time_in_force")]
		public TimeInForce? TimeInForce { get; set; }

		[JsonProperty("cancel_after")]
		public Decimal CancelAfter { get; set; }
	}
}

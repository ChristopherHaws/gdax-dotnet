using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class Order
	{
		[JsonProperty("id")]
		public Guid OrderId { get; set; }

		[JsonProperty("product_id")]
		public String ProductId { get; set; }

		[JsonProperty("filled_size")]
		public Decimal FilledSize { get; set; }

		[JsonProperty("executed_value")]
		public Decimal ExecutedValue { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("fill_fees")]
		public Decimal FillFees { get; set; }

		[JsonProperty("post_only")]
		public Boolean PostOnly { get; set; }

		[JsonProperty("price")]
		public Decimal Price { get; set; }

		[JsonProperty("status")]
		public String Status { get; set; }

		[JsonProperty("side")]
		public Side Side { get; set; }

		[JsonProperty("settled")]
		public Boolean Settled { get; set; }

		[JsonProperty("size")]
		public Decimal Size { get; set; }

		[JsonProperty("time_in_force")]
		public TimeInForce TimeInForce { get; set; }

		[JsonProperty("stp")]
		public SelfTradePrevention SelfTradePrevention { get; set; }

		[JsonProperty("type")]
		public OrderType Type { get; set; }
	}
}

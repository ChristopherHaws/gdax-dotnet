using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class Order
	{

		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("price")]
		public Decimal Price { get; set; }

		[JsonProperty("size")]
		public Double Size { get; set; }

		[JsonProperty("product_id")]
		public String ProductId { get; set; }

		[JsonProperty("side")]
		public Side Side { get; set; }

		[JsonProperty("stp")]
		public string Stp { get; set; }

		[JsonProperty("type")]
		public OrderType Type { get; set; }

		[JsonProperty("time_in_force")]
		public string TimeInForce { get; set; }

		[JsonProperty("post_only")]
		public bool PostOnly { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("fill_fees")]
		public string FillFees { get; set; }

		[JsonProperty("filled_size")]
		public double FilledSize { get; set; }

		[JsonProperty("executed_value")]
		public string ExecutedValue { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("settled")]
		public bool Settled { get; set; }
	}
}

using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class Order
	{

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("price")]
		public string Price { get; set; }

		[JsonProperty("size")]
		public string Size { get; set; }

		[JsonProperty("product_id")]
		public string ProductId { get; set; }

		[JsonProperty("side")]
		public string Side { get; set; }

		[JsonProperty("stp")]
		public string Stp { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("time_in_force")]
		public string TimeInForce { get; set; }

		[JsonProperty("post_only")]
		public bool PostOnly { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("fill_fees")]
		public string FillFees { get; set; }

		[JsonProperty("filled_size")]
		public string FilledSize { get; set; }

		[JsonProperty("executed_value")]
		public string ExecutedValue { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("settled")]
		public bool Settled { get; set; }
	}
}

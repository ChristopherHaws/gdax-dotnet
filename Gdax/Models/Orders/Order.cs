using System;
using System.Diagnostics;
using Gdax.Serialization;
using Newtonsoft.Json;

namespace Gdax.Models
{
		public class Order
		{
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
			public bool PostOnly { get; set; }

			[JsonProperty("id")]
			public Guid Id { get; set; }

			[JsonProperty("price")]
			public Decimal Price { get; set; }

			[JsonProperty("status")]
			public string Status { get; set; }

			[JsonProperty("side")]
			public Side Side { get; set; }

			[JsonProperty("settled")]
			public bool Settled { get; set; }

			[JsonProperty("size")]
			public Decimal Size { get; set; }

			[JsonProperty("time_in_force")]
			public string TimeInForce { get; set; }

			[JsonProperty("stp")]
			public string Stp { get; set; }

			[JsonProperty("type")]
			public OrderType Type { get; set; }
		}
	}

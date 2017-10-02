﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gdax.Models
{
	internal class OrderRequest
	{
		[JsonProperty("client_oid")]
		public String Client_Oid { get; set; }

		[JsonProperty("side"), JsonConverter(typeof(StringEnumConverter))]
		public Side Side { get; set; }

		[JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
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
		public String Stp { get; set; }

		[JsonProperty("time_in_force")]
		public Decimal TimeInForce { get; set; }

		[JsonProperty("cancel_after")]
		public Decimal CancelAfter { get; set; }
	}
}

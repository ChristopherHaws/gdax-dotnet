using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gdax.Models
{
    public class OrderRequest
    {
		
		private OrderRequest model;

		public OrderRequest()
		{
		}

		public OrderRequest(OrderRequest model)
		{
			this.model = model;
		}

		
		[JsonProperty("side"), JsonConverter(typeof(StringEnumConverter))]
		public Side Side { get; set; }
		

		[JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
		public OrderType Type { get; set; }

		[JsonProperty("product_id")]
		public String ProductId { get; set; }

		//[JsonProperty("side")]
		//public Side Side { get; set; }

		[JsonProperty("size")]
		public Decimal Size { get; set; }

		[JsonProperty("price")]
		public Decimal Price { get; set; }
	}
}

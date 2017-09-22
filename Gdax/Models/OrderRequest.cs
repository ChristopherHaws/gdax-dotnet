using System;
using System.Diagnostics;
using Newtonsoft.Json;

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

		[JsonProperty("type")]
		//public String Type { get; } = "market";
		public OrderType Type { get; set; }

		[JsonProperty("product_id")]
		public String ProductId { get; set; }

		[JsonProperty("side")]
		public Side Side { get; set; }

		[JsonProperty("size")]
		public Decimal Size { get; set; }

		[JsonProperty("price")]
		public Decimal Price { get; set; }
	}
}

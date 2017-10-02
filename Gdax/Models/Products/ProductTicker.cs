using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class ProductTicker
	{
		[JsonProperty("product_id")]
		public String ProductId { get; set; }

		[JsonProperty("trade_id")]
		public String TradeId { get; set; }

		[JsonProperty("price")]
		public Decimal Price { get; set; }

		[JsonProperty("size")]
		public Decimal Size { get; set; }

		[JsonProperty("bid")]
		public Decimal Bid { get; set; }

		[JsonProperty("ask")]
		public Decimal Ask { get; set; }

		[JsonProperty("volume")]
		public Decimal Volume { get; set; }

		[JsonProperty("time")]
		public DateTime Time { get; set; }
	}	
}

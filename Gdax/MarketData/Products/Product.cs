using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Gdax.MarketData.Products
{
	[DebuggerDisplay("{Id}")]
	public class Product
	{
		[JsonProperty("id")]
		public String Id { get; set; }

		[JsonProperty("base_currency")]
		public String BaseCurrency { get; set; }

		[JsonProperty("quote_currency")]
		public String QuoteCurrency { get; set; }

		[JsonProperty("base_min_size")]
		public Decimal BaseMinSize { get; set; }

		[JsonProperty("base_max_size")]
		public Decimal BaseMaxSize { get; set; }

		[JsonProperty("quote_increment")]
		public Decimal QuoteIncrement { get; set; }
	}
}

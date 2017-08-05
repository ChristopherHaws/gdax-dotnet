using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gdax.MarketData.Products
{
	public class OrderBook
	{
		[JsonProperty("sequence")]
		public Int64 Sequence { get; set; }

		[JsonProperty("bids")]
		public IEnumerable<String[]> Bids { get; set; }

		[JsonProperty("asks")]
		public IEnumerable<String[]> Asks { get; set; }
	}
}

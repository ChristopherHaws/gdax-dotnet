using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class OrderBook
	{
		[JsonProperty("sequence")]
		public Int64 Sequence { get; set; }

		[JsonProperty("bids")]
		public IList<String[]> Bids { get; set; }

		[JsonProperty("asks")]
		public IList<String[]> Asks { get; set; }
	}

	/// <summary>
	/// Levels 1 and 2 are aggregated and return the number of orders at each level.
	/// Level 3 is non-aggregated and returns the entire order book.
	/// </summary>
	public enum OrderBookLevel
	{
		/// <summary>
		/// Only the best bid and ask
		/// </summary>
		/// 
		Level1 = 1,

		/// <summary>
		/// Top 50 bids and asks (aggregated)
		/// </summary>
		Level2 = 2,

		/// <summary>
		/// Full order book (non aggregated)
		/// </summary>
		Level3 = 3
	}
}

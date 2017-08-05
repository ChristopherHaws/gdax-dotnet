using System;
using Newtonsoft.Json;

namespace Gdax.MarketData.Products
{
	public class HistoricRate
	{
		/// <summary>
		/// Gets or sets the bucket start time
		/// </summary>
		[JsonProperty("time")]
		public Decimal Time { get; set; }

		/// <summary>
		/// Gets or sets the lowest price during the bucket interval
		/// </summary>
		[JsonProperty("low")]
		public Decimal Low { get; set; }

		/// <summary>
		/// Gets or sets the highest price during the bucket interval
		/// </summary>
		[JsonProperty("high")]
		public Decimal High { get; set; }

		/// <summary>
		/// Gets or sets the opening price (first trade) in the bucket interval
		/// </summary>
		[JsonProperty("open")]
		public Decimal Open { get; set; }

		/// <summary>
		/// Gets or sets the closing price (last trade) in the bucket interval
		/// </summary>
		[JsonProperty("close")]
		public Decimal Close { get; set; }

		/// <summary>
		/// Gets or sets the volume of trading activity during the bucket interval
		/// </summary>
		[JsonProperty("volume")]
		public Decimal Volume { get; set; }
	}
}

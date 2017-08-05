using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gdax.Products
{
	public static class GetHistoricRatesQuery
	{
		/// <summary>
		///		<para>
		///			Gets the historic rates for a product. Rates are returned in grouped buckets based on requested granularity.
		///		</para>
		///		<para>
		///			The maximum number of data points for a single request is 200 candles. If your selection of start/end time and granularity
		///			will result in more than 200 data points, your request will be rejected. If you wish to retrieve fine granularity data over
		///			a larger time range, you will need to make multiple requests with new start/end ranges.
		///		</para>
		/// </summary>
		/// <remarks>
		/// Historical rate data may be incomplete. No data is published for intervals where there are no ticks.
		/// Historical rates should not be polled frequently. If you need real-time information, use the trade and book endpoints along with the websocket feed.
		/// </remarks>
		/// <param name="productId">The currency pair.</param>
		/// <param name="start">Start time in ISO 8601.</param>
		/// <param name="end">End time in ISO 8601.</param>
		/// <param name="granularity">Desired timeslice in seconds.</param>
		/// <returns></returns>
		public static async Task<IEnumerable<HistoricRate>> GetHistoricRatesAsync(this GdaxClient client, String productId, DateTime? start = null, DateTime? end = null, Int32? granularity = null)
		{
			Check.NotNull(client, nameof(client));
			Check.NotNullOrWhiteSpace(productId, nameof(productId));

			var request = new GdaxRequestBuilder($"/products/{productId}/candles")
				.AddParameterIfNotNull("start", start?.ToString("o"))
				.AddParameterIfNotNull("end", end?.ToString("o"))
				.AddParameterIfNotNull("granularity", granularity?.ToString())
				.Build();

			var rates = (await client.GetResponseAsync<IEnumerable<Decimal[]>>(request).ConfigureAwait(false)).Value;

			var results = new List<HistoricRate>();

			foreach (var rate in rates)
			{
				results.Add(new HistoricRate
				{
					Time = rate[0],
					Low = rate[1],
					High = rate[2],
					Open = rate[3],
					Close = rate[4],
					Volume = rate[5],
				});
			}

			return results;
		}

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
}

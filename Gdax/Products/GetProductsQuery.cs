using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gdax.Products
{
	public static class GetProductsQuery
	{
		/// <summary>
		/// Get a list of available currency pairs for trading.
		/// </summary>
		/// <returns></returns>
		public static async Task<IEnumerable<Product>> GetProductsAsync(this GdaxClient client)
		{
			Check.NotNull(client, nameof(client));

			var request = new GdaxRequestBuilder("/products")
				.Build();

			return (await client.GetResponseAsync<IEnumerable<Product>>(request).ConfigureAwait(false)).Value;
		}

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
}

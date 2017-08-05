using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gdax.MarketData.Products
{
	internal class ProductService : IProductService
	{
		private readonly GdaxClient client;

		public ProductService(GdaxClient client)
		{
			this.client = Check.NotNull(client, nameof(client));
		}

		public async Task<IEnumerable<Product>> GetProductsAsync()
		{
			var request = new GdaxRequestBuilder("/products")
				.Build();

			return (await this.client.GetResponseAsync<IEnumerable<Product>>(request).ConfigureAwait(false)).Value;
		}

		public async Task<ProductTicker> GetProductTickerAsync(String productId)
		{
			Check.NotNullOrWhiteSpace(productId, nameof(productId));

			var request = new GdaxRequestBuilder($"/products/{productId}/ticker")
				.Build();

			var response = await this.client.GetResponseAsync<ProductTicker>(request).ConfigureAwait(false);

			if (response.Value != null)
			{
				response.Value.ProductId = productId;
			}

			return response.Value;
		}

		public async Task<OrderBook> GetOrderBookAsync(String productId, Int32 level = 1)
		{
			Check.NotNullOrWhiteSpace(productId, nameof(productId));

			var request = new GdaxRequestBuilder($"/products/{productId}/book")
				.AddParameterIfNotNull("level", level.ToString())
				.Build();

			return (await this.client.GetResponseAsync<OrderBook>(request).ConfigureAwait(false)).Value;
		}

		public async Task<IEnumerable<HistoricRate>> GetHistoricRatesAsync(String productId, DateTime? start = null, DateTime? end = null, Int32? granularity = null)
		{
			Check.NotNullOrWhiteSpace(productId, nameof(productId));

			var request = new GdaxRequestBuilder($"/products/{productId}/candles")
				.AddParameterIfNotNull("start", start?.ToString("o"))
				.AddParameterIfNotNull("end", end?.ToString("o"))
				.AddParameterIfNotNull("granularity", granularity?.ToString())
				.Build();

			var rates = (await this.client.GetResponseAsync<IEnumerable<Decimal[]>>(request).ConfigureAwait(false)).Value;
			
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
	}
}

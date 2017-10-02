using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public partial class GdaxClient
	{
		public async Task<IList<HistoricRate>> GetHistoricRates(String productId, DateTime? start = null, DateTime? end = null, Int32? granularity = null)
		{
			Check.NotNullOrWhiteSpace(productId, nameof(productId));

			var request = new GdaxRequestBuilder($"/products/{productId}/candles")
				.AddParameterIfNotNull("start", start?.ToString("o"))
				.AddParameterIfNotNull("end", end?.ToString("o"))
				.AddParameterIfNotNull("granularity", granularity?.ToString())
				.Build();

			var rates = (await this.GetResponse<IList<Decimal[]>>(request).ConfigureAwait(false)).Value;

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

		public async Task<OrderBook> GetOrderBook(String productId, OrderBookLevel level = OrderBookLevel.Level1)
		{
			Check.NotNullOrWhiteSpace(productId, nameof(productId));

			var request = new GdaxRequestBuilder($"/products/{productId}/book")
				.AddParameterIfNotNull("level", ((Int32)level).ToString())
				.Build();

			return (await this.GetResponse<OrderBook>(request).ConfigureAwait(false)).Value;
		}

		public async Task<IList<Product>> GetProducts()
		{
			var request = new GdaxRequestBuilder("/products")
				.Build();

			return (await this.GetResponse<IList<Product>>(request).ConfigureAwait(false)).Value;
		}

		public async Task<ProductTicker> GetProductTicker(String productId)
		{
			Check.NotNullOrWhiteSpace(productId, nameof(productId));

			var request = new GdaxRequestBuilder($"/products/{productId}/ticker")
				.Build();

			var response = await this.GetResponse<ProductTicker>(request).ConfigureAwait(false);

			if (response.Value != null)
			{
				response.Value.ProductId = productId;
			}

			return response.Value;
		}
	}
}

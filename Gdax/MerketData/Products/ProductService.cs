using System;
using System.Collections.Generic;
using System.Net.Http;
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
			return (await this.client.GetResponseAsync<IEnumerable<Product>>(
				new GdaxRequest(HttpMethod.Get, "/products")
			).ConfigureAwait(false)).Value;
		}

		public async Task<ProductTicker> GetProductTickerAsync(String productId)
		{
			var response = await this.client.GetResponseAsync<ProductTicker>(
				new GdaxRequest(HttpMethod.Get, $"/products/{productId}/ticker")
			).ConfigureAwait(false);

			if (response.Value != null)
			{
				response.Value.ProductId = productId;
			}

			return response.Value;
		}

		public async Task<OrderBook> GetOrderBookAsync(String productId, Int32 level = 1)
		{
			return (await this.client.GetResponseAsync<OrderBook>(
				new GdaxRequest(HttpMethod.Get, $"/products/{productId}/book?level={level}")
			).ConfigureAwait(false)).Value;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gdax.Fills
{
	internal class FillsService : IFillsService
	{
		private readonly GdaxClient client;

		public FillsService(GdaxClient client)
		{
			this.client = client;
		}

		public async Task<IEnumerable<Fill>> ListFills(String orderId = null, String productId = null)
		{
			var request = new GdaxRequestBuilder("/fills")
				.AddParameterIfNotNull("order_id", orderId)
				.AddParameterIfNotNull("product_id", productId)
				.Build();

			return (await this.client.GetResponseAsync<IEnumerable<Fill>>(request).ConfigureAwait(false)).Value;
		}
	}
}

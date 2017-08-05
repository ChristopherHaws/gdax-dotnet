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
				
		public async Task<PaginatedResult<Fill>> ListFills(String orderId = null, String productId = null, PaginationOptions paging = null)
		{
			var request = new GdaxRequestBuilder("/fills")
				.AddParameterIfNotNull("order_id", orderId)
				.AddParameterIfNotNull("product_id", productId)
				.SetPageLimit(paging?.Limit)
				.SetCursor(paging?.CursorType ?? default(CursorType), paging?.Value)
				.Build();

			var response = await this.client.GetResponseAsync<IEnumerable<Fill>>(request).ConfigureAwait(false);

			return new PaginatedResult<Fill>(response);
		}
	}
}

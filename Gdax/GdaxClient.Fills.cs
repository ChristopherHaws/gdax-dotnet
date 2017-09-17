using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public partial class GdaxClient
	{
		public async Task<PagedResults<Fill, Int32?>> GetFills(String orderId = null, String productId = null, PagingOptions<Int32?> paging = null)
		{
			var request = new GdaxRequestBuilder("/fills")
				.AddParameterIfNotNull("order_id", orderId)
				.AddParameterIfNotNull("product_id", productId)
				.AddPagingOptions(paging, CursorEncoders.Int32)
				.Build();

			var response = await this.GetResponse<IList<Fill>>(request).ConfigureAwait(false);

			return new PagedResults<Fill, Int32?>(response, CursorEncoders.Int32, paging);
		}
	}
}

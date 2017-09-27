using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public partial class GdaxClient
	{
		public async Task<PagedResults<Order, Int32?>> GetOrders(String status = null, String productId = null, PagingOptions<Int32?> paging = null)
		{
			var request = new GdaxRequestBuilder("/orders")
				.AddParameterIfNotNull("status", status)
				.AddParameterIfNotNull("product_id", productId)
				.AddPagingOptions(paging, CursorEncoders.Int32)
				.Build();

			var response = await this.GetResponse<IList<Order>>(request).ConfigureAwait(false);

			return new PagedResults<Order, Int32?>(response, CursorEncoders.Int32, paging);
		}
	}
}

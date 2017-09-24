using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Gdax.Models;
using Newtonsoft.Json;

namespace Gdax
{
	public partial class GdaxClient
    {

		public async Task<Order> SubmitMarketOrderBySize(Side side, String productId, Decimal size, OrderType orderType)
		{			
			var model = new OrderRequest()
			{
				Side = side,
				ProductId = productId,
				Type = orderType,
				Size = size
			};

			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post)
				.AddBody(side, productId, orderType, size)
				.Build();

			request.RequestBody = JsonConvert.SerializeObject(model);

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}

		public async Task<PagedResults<Order, Int32?>> ListOrders(String orderStatus = null, PagingOptions<Int32?> paging = null)
		{
			var request = new GdaxRequestBuilder("/orders")
				.AddParameterIfNotNull("status", orderStatus)
				.Build();

			var response = await this.GetResponse<IList<Order>>(request).ConfigureAwait(false);

			return new PagedResults<Order, Int32?>(response, CursorEncoders.Int32, paging);
		}

		public async Task<IList<Order>> CancelOrders()
		{
			var request = new GdaxRequestBuilder("/orders", HttpMethod.Delete).Build();

			return (await this.GetResponse<IList<Order>>(request).ConfigureAwait(false)).Value;
		}

		public async Task<IList<Order>> CancelOrders(string productID)
		{
			var request = new GdaxRequestBuilder("/orders", HttpMethod.Delete)
				.AddParameterIfNotNull("product_id", productID)
				.Build();

			return (await this.GetResponse<IList<Order>>(request).ConfigureAwait(false)).Value;
		}
	}
}

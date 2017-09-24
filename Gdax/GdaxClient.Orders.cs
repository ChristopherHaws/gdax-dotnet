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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="side"></param>
		/// <param name="productId"></param>
		/// <param name="size"> Size in BTC / ETH etc </param>
		/// <param name="funds"> Optional - Amount in fiat currency </param>
		/// <param name="orderType"></param>
		/// <returns></returns>
		public async Task<Order> SubmitMarketOrder(Side side, String productId, Decimal size, OrderType orderType = OrderType.market)
		{			
			var model = new OrderRequest()
			{
				Side = side,
				ProductId = productId,
				Type = orderType,
				Size = size
			};

			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post).Build();

			request.RequestBody = JsonConvert.SerializeObject(model);

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}

		public async Task<Order> SubmitMarketOrderFiat(Side side, String productId, Decimal funds, OrderType orderType = OrderType.market)
		{
			var model = new OrderRequest()
			{
				Side = side,
				ProductId = productId,
				Type = orderType,
				Funds = funds
			};

			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post).Build();

			request.RequestBody = JsonConvert.SerializeObject(model);

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}

		// Submit Limit or stop order
		public async Task<Order> SubmitLimitOrder(Side side, String productId, Decimal size, Decimal price, OrderType orderType)
		{
			var model = new OrderRequest()
			{
				Side = side,
				ProductId = productId,
				Type = orderType,
				Size = size,
				Price = price
			};

			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post).Build();

			request.RequestBody = JsonConvert.SerializeObject(model);

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}

		// Submit Limit or stop order
		public async Task<Order> SubmitStopOrderFiat(Side side, String productId, Decimal price, Decimal funds, OrderType orderType = OrderType.stop)
		{
			var model = new OrderRequest()
			{
				Side = side,
				ProductId = productId,
				Price = price,
				Type = orderType,
				Funds = funds
			};

			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post).Build();

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

		public async Task<IList<Order>> CancelOrders(String productID = null)
		{
			var request = new GdaxRequestBuilder("/orders", HttpMethod.Delete)
				.AddParameterIfNotNull("product_id", productID)
				.Build();

			return (await this.GetResponse<IList<Order>>(request).ConfigureAwait(false)).Value;
		}
	}
}

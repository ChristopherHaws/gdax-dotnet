using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public partial class GdaxClient
	{
		public async Task<Order> SubmitMarketOrder(Side side, String productId, Decimal size)
		{
			var model = new OrderRequest
			{
				Side = side,
				ProductId = productId,
				Type = OrderType.Market,
				Size = size
			};

			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post)
				.AddBody(model)
				.Build();

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}

		public async Task<Order> SubmitMarketOrderFiat(Side side, String productId, Decimal funds)
		{
			var model = new OrderRequest
			{
				Side = side,
				ProductId = productId,
				Type = OrderType.Market,
				Funds = funds
			};

			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post)
				.AddBody(model)
				.Build();

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}
		
		public async Task<Order> SubmitLimitOrder(Side side, String productId, Decimal size, Decimal price)
		{
			var model = new OrderRequest
			{
				Side = side,
				ProductId = productId,
				Type = OrderType.Limit,
				Size = size,
				Price = price
			};

			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post)
				.AddBody(model)
				.Build();

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}
		
		public async Task<Order> SubmitStopOrderFiat(Side side, String productId, Decimal price, Decimal funds)
		{
			var model = new OrderRequest
			{
				Side = side,
				ProductId = productId,
				Price = price,
				Type = OrderType.Stop,
				Funds = funds
			};

			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post)
				.AddBody(model)
				.Build();

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}

		public async Task<PagedResults<Order, Int32?>> GetOpenOrders(String productId = null, OrderStates? states = null, PagingOptions<Int32?> paging = null)
		{
			var request = new GdaxRequestBuilder("/orders")
				.AddEnumParameterIfNotNull("status", states)
				.AddParameterIfNotNull("product_id", productId)
				.Build();

			var response = await this.GetResponse<IList<Order>>(request).ConfigureAwait(false);

			return new PagedResults<Order, Int32?>(response, CursorEncoders.Int32, paging);
		}

		public async Task<IList<Guid>> CancelAllOrders(String productId = null)
		{
			var request = new GdaxRequestBuilder("/orders", HttpMethod.Delete)
				.AddParameterIfNotNull("product_id", productId)
				.Build();

			return (await this.GetResponse<IList<Guid>>(request).ConfigureAwait(false)).Value;
		}
	}
}

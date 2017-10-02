using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public partial class GdaxClient
	{
		public Task<Order> PlaceMarketOrder(Side side, String productId, Decimal amount)
		{
			var model = new OrderRequest
			{
				Side = side,
				ProductId = productId,
				Type = OrderType.Market,
				Size = amount
			};
			
			return this.PlaceOrderAdvanced(model);
		}

		public Task<Order> PlaceMarketOrderInQuoteCurrency(Side side, String productId, Decimal amount)
		{
			var model = new OrderRequest
			{
				Side = side,
				ProductId = productId,
				Type = OrderType.Market,
				Funds = amount
			};
			
			return this.PlaceOrderAdvanced(model);
		}
		
		public Task<Order> PlaceLimitOrder(Side side, String productId, Decimal amount, Decimal limitPrice)
		{
			var model = new OrderRequest
			{
				Side = side,
				ProductId = productId,
				Type = OrderType.Limit,
				Size = amount,
				Price = limitPrice
			};
			
			return this.PlaceOrderAdvanced(model);
		}

		public Task<Order> PlaceStopOrder(Side side, String productId, Decimal price, Decimal amount)
		{
			var model = new OrderRequest
			{
				Side = side,
				ProductId = productId,
				Type = OrderType.Stop,
				Price = price,
				Size = amount
			};

			return this.PlaceOrderAdvanced(model);
		}

		public Task<Order> PlaceStopOrderInQuoteCurrency(Side side, String productId, Decimal price, Decimal amount)
		{
			var model = new OrderRequest
			{
				Side = side,
				ProductId = productId,
				Type = OrderType.Stop,
				Price = price,
				Funds = amount
			};

			return this.PlaceOrderAdvanced(model);
		}

		public async Task<Order> PlaceOrderAdvanced(OrderRequest order)
		{
			var request = new GdaxRequestBuilder("/orders", HttpMethod.Post)
				.AddBody(order, this.serialzer)
				.Build();

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}

		public async Task<PagedResults<Order, DateTime?>> GetOrders(String productId = null, OrderStates? states = null, PagingOptions<DateTime?> paging = null)
		{
			var request = new GdaxRequestBuilder("/orders")
				.AddEnumParameterIfNotNull("status", states)
				.AddParameterIfNotNull("product_id", productId)
				.AddPagingOptions(paging, CursorEncoders.DateTime)
				.Build();

			var response = await this.GetResponse<IList<Order>>(request).ConfigureAwait(false);

			return new PagedResults<Order, DateTime?>(response, CursorEncoders.DateTime, paging);
		}

		public async Task CancelOrder(String orderId)
		{
			var request = new GdaxRequestBuilder($"/orders/{orderId}", HttpMethod.Delete)
				.Build();

			await this.GetResponse(request).ConfigureAwait(false);
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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;


namespace Gdax
{
	public partial class GdaxClient
    {
		/*
		 * size	[optional]* Desired amount in BTC
		 * funds	[optional]* Desired amount of quote currency to use
		 */

		public async Task<Order> SubmitMarketOrderCrypto(OrderType orderType, Side side, string productID, double size)
		{
			var request = new GdaxRequestBuilder("/orders", this.POST)
				.AddParameterIfNotNull("type", ((OrderType)orderType).ToString())
				.AddParameterIfNotNull("side", ((Side)side).ToString())
				.AddParameterIfNotNull("product_id", productID)
				.AddParameterIfNotNull("size", ((double)size).ToString())
				.Build();

			return (await this.GetResponse<Order>(request).ConfigureAwait(false)).Value;
		}
	}
}

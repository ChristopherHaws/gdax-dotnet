using Gdax.MarketData.Products;

namespace Gdax.MerketData
{

	internal class MarketDataService : IMarketDataService
	{
		private readonly GdaxClient client;

		public MarketDataService(GdaxClient client)
		{
			this.client = Check.NotNull(client, nameof(client));
			this.Products = new ProductService(client);
		}

		public IProductService Products { get; }
	}
}

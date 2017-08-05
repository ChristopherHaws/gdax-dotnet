using Gdax.MarketData.Products;

namespace Gdax.MarketData
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

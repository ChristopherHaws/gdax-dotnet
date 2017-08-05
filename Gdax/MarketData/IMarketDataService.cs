using Gdax.MarketData.Products;

namespace Gdax.MarketData
{
	public interface IMarketDataService
	{
		IProductService Products { get; }
	}
}

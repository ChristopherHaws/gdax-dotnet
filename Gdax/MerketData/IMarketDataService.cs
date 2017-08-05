using Gdax.MarketData.Products;

namespace Gdax.MerketData
{
	public interface IMarketDataService
	{
		IProductService Products { get; }
	}
}

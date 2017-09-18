using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IOrdersClient
	{
		Task<Order> SubmitMarketOrderCrypto(OrderType orderType, Side side, string productID, double size);
	}
}

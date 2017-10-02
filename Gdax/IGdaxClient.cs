using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	/// <summary>
	/// The GdaxClient is thread safe and can be used as a singleton for the lifetime of your application.
	/// </summary>
	public interface IGdaxClient : IAccountClient, IFillsClient, IProductClient, IOrdersClient, ITransferClient
	{
		Task<Time> GetServerTime();
	}
}

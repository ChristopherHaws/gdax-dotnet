using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public partial class GdaxClient
	{
		public async Task<Time> GetServerTime()
		{
			var request = new GdaxRequestBuilder("/time")
				.Build();

			return (await this.GetResponse<Time>(request).ConfigureAwait(false)).Value;
		}
	}
}

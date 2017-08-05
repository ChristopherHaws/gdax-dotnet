using System;
using System.Threading.Tasks;

namespace Gdax.Times
{
	public static class TimeQuery
	{
		public static async Task<Time> GetServerTimeAsync(this GdaxClient client)
		{
			Check.NotNull(client, nameof(client));

			var request = new GdaxRequestBuilder("/time")
				.Build();

			return (await client.GetResponseAsync<Time>(request).ConfigureAwait(false)).Value;
		}

		public class Time
		{
			public DateTime Iso { get; set; }
			public Decimal Epoch { get; set; }
		}
	}
}

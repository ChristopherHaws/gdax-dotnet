using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Accounts
{
	public class GetAccountHistoryQueryTests
	{
		[Fact]
		public async Task GetAccountHistory_ShouldReturnTheAccounts()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var accounts = await client.GetAccounts();
			var ledger = await client.GetAccountHistory(accounts.First().Id);

			ledger.Results.ShouldNotBeNull();
		}
	}
}

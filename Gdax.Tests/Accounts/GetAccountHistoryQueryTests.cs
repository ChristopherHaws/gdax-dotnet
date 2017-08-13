using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gdax.Accounts
{
	public class GetAccountHistoryQueryTests
	{
		[Fact]
		public async Task GetAccountHistoryAsync_ShouldReturnTheAccounts()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var accounts = await client.ListAccountsAsync();
			var ledger = await client.GetAccountHistoryAsync(accounts.First().Id);

			ledger.Results.Should().NotBeNull();
		}
	}
}

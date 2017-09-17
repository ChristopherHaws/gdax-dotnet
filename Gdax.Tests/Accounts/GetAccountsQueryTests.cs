using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Gdax.Accounts
{
	public class GetAccountsQueryTests
	{
		[Fact]
		public async Task GetAccountsAsync_ShouldReturnTheAccounts()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var accounts = await client.GetAccountsAsync();

			accounts.ShouldNotBeNull();
		}
	}
}

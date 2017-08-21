using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Gdax.Accounts
{
	public class ListAccountsQueryTests
	{
		[Fact]
		public async Task ListAccountsAsync_ShouldReturnTheAccounts()
		{
			var client = new GdaxClient(TestAuthenticators.FullAccess)
			{
				UseSandbox = true
			};

			var accounts = await client.GetAccountsAsync();
			
			accounts.Should().NotBeNullOrEmpty();
		}
	}
}

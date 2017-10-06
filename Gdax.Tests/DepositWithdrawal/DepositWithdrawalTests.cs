using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Gdax.Models;
using Shouldly;
using Xunit;

namespace Gdax.Tests.DepositWithdrawal
{
	public class DepositWithdrawalTests
	{
		public static GdaxClient client = new GdaxClient(TestAuthenticators.FullAccess)
		{
			UseSandbox = true
		};

		private static Guid coinbase_id;

		[Fact]
		public async Task DepositWithdrawals_ShouldReturnTheSuccess()
		{
			foreach (var c in await client.GetCoinbaseAccounts())
			{
				if (c.Currency == "USD")
				{
					coinbase_id = c.Id;
				}
			}

			var depositFiat = await client.DepositFromCoinbase(1000m, "USD", coinbase_id).ConfigureAwait(false);

			depositFiat.ShouldBeNull();

			var withdrawtoCoinbase = await client.WithdrawToCoinbase(1000m, "USD", coinbase_id).ConfigureAwait(false);

			withdrawtoCoinbase.ShouldBeNull();
		}

	}
}

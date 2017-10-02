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
		private static Guid paymentIdForWithdrawal;
		private static Guid coinbase_id;

		[Fact]
		public async Task TestAllDepositWithdrawalFunctions()
		{
			await GetPaymentsInfo().ConfigureAwait(false);

			await TestDepositBank(100m, paymentIdForWithdrawal, "EUR");

			await TestDepositCoinbase(100m, coinbase_id, "USD");

			await TestWithdrawCoinbase(00m, coinbase_id, "USD");
		}

		public static async Task GetPaymentsInfo()
		{
			foreach (var b in await client.GetPaymentMethods())
			{
				// if (b.Name.Contains("EUR"))
				// && b.Type == "fiat_account"

				if (b.Type.Contains("sepa"))
				{
					Debug.WriteLine("*******************************");
					Debug.WriteLine("ID {0}", b.Id);
					Debug.WriteLine("Type {0}", b.Type);
					Debug.WriteLine("Currency {0}", b.Currency);
					Debug.WriteLine("Primary Sell {0}", b.IsPrimarySellMethod);
					Debug.WriteLine("Bank Name {0}", b.Name);
					Debug.WriteLine("Allow Withdraw {0}", b.CanWithdraw);
					Debug.WriteLine("Allow Deposit {0}", b.CanDeposit);
					Debug.WriteLine("*******************************");

					paymentIdForWithdrawal = new Guid(b.Id.ToString());
				}
			}

			foreach (var c in await client.GetCoinbaseAccounts())
			{
				// if (c.Currency == "GBP") // && Convert.ToDecimal(c.Balance) > 0
				// {
				Debug.WriteLine("*******************************");
				Debug.WriteLine("Coinbase ID {0}", c.Id);
				Debug.WriteLine("Coinbase Balance {0}", c.Balance);
				Debug.WriteLine("Coinbase Currency {0}", c.Currency);
				Debug.WriteLine("*******************************");

				coinbase_id = new Guid(c.Id.ToString());
			}
		}

		public static async Task TestDepositBank(Decimal amount, Guid paymentID, String currency)
		{
			var depositFiat = await client.DepositFromBank(amount, currency, paymentID).ConfigureAwait(false);
		}

		public static async Task TestDepositCoinbase(Decimal amount, Guid coinbaseID, String currency)
		{
			var depositFiat = await client.DepositFromCoinbase(amount, currency, coinbaseID).ConfigureAwait(false);
		}

		public static async Task TestWithdrawBank(Decimal amoumt, Guid paymentID, String currency)
		{
			Debug.WriteLine("Send Sepa Withdrawal");

			var withdrawSepa = await client.WithdrawToBank(amoumt, currency, paymentID);
		}

		public static async Task TestWithdrawCoinbase(Decimal amount, Guid coinbaseID, String currency)
		{
			Debug.WriteLine("Send Coinbase Withdrawal");

			var withdrawtoCoinbase = await client.WithdrawToCoinbase(amount, currency, coinbaseID).ConfigureAwait(false);
		}

		public static async Task TestWithdrawCrypto(Decimal amount, String currency, String walletAddress)
		{
			Debug.WriteLine("Send Crypto Withdrawal");

			walletAddress = "someCryptoAddress";

			var withdrawCypto = await client.WithdrawToWallet(amount, currency, walletAddress).ConfigureAwait(false);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public partial class GdaxClient
	{
		public async Task<IList<PaymentMethod>> GetPaymentMethods()
		{
			var request = new GdaxRequestBuilder("/payment-methods").Build();

			return (await this.GetResponse<IList<PaymentMethod>>(request).ConfigureAwait(false)).Value;
		}
		
		public async Task<BankTransfer> DepositFromBank(Decimal amount, String currency, Guid paymentID)
		{
			var model = new BankTransferRequest
			{
				Amount = amount,
				Currency = currency,
				PaymentMethodId = paymentID
			};

			var request = new GdaxRequestBuilder("/deposits/payment-method", HttpMethod.Post)
				.AddBody(model)
				.Build();

			return (await this.GetResponse<BankTransfer>(request).ConfigureAwait(false)).Value;
		}

		public async Task<BankTransfer> WithdrawToBank(Decimal amount, String currency, Guid paymentID)
		{
			var model = new BankTransferRequest
			{
				Amount = amount,
				Currency = currency,
				PaymentMethodId = paymentID
			};

			var request = new GdaxRequestBuilder("/withdrawals/payment-method", HttpMethod.Post)
				.AddBody(model)
				.Build();

			return (await this.GetResponse<BankTransfer>(request).ConfigureAwait(false)).Value;
		}

		public async Task<CoinbaseDeposit> DepositFromCoinbase(Decimal amount, String currency, Guid coinbaseID)
		{
			var model = new CoinbaseDepositRequest
			{
				Amount = amount,
				Currency = currency,
				CoinbaseAccountId = coinbaseID
			};

			var request = new GdaxRequestBuilder("/deposits/coinbase-account", HttpMethod.Post)
				.AddBody(model)
				.Build();

			return (await this.GetResponse<CoinbaseDeposit>(request).ConfigureAwait(false)).Value;
		}

		public async Task<CoinbaseWithdrawal> WithdrawToCoinbase(Decimal amount, String currency, Guid coinbaseID)
		{
			var model = new CoinbaseWithdrawalRequest
			{
				Amount = amount,
				Currency = currency,
				CoinbaseAccountId = coinbaseID
			};
			
			var request = new GdaxRequestBuilder("/withdrawals/coinbase", HttpMethod.Post)
				.AddBody(model)
				.Build();

			return (await this.GetResponse<CoinbaseWithdrawal>(request).ConfigureAwait(false)).Value;
		}

		public async Task<WalletWithdrawal> WithdrawToWallet(Decimal amount, String currency, String cryptoAddress)
		{
			var model = new WalletWithdrawalRequest
			{
				Amount = amount,
				Currency = currency,
				CryptoAddress = cryptoAddress
			};

			var request = new GdaxRequestBuilder("/withdrawals/crypto", HttpMethod.Post)
				.AddBody(model)
				.Build();

			return (await this.GetResponse<WalletWithdrawal>(request).ConfigureAwait(false)).Value;
		}
	}
}

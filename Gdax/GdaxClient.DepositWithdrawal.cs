using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Gdax.Models;
using Newtonsoft.Json;

namespace Gdax
{
	public partial class GdaxClient
	{
		private HttpMethod POST;

		/// <summary>
		/// Get all payment information on account - Only need ID for payments
		/// </summary>
		/// <returns></returns>
		public async Task<PaymentMethods> GetPaymentMethods()
		{
			var request = new GdaxRequestBuilder("/payment-methods").Build();

			return (await this.GetResponse<PaymentMethods>(request).ConfigureAwait(false)).Value;

		}

		/// <summary>
		/// Withdraw to Bank Account / Fiat
		/// </summary>
		/// <param name="amount"></param>
		/// <param name="currency"></param>
		/// <param name="paymentID"></param>
		/// <returns></returns>
		public async Task<DepositWithdrawal> GetWithdrawalToBank(double amount, string currency, Guid paymentID)
		{
			var request = new GdaxRequestBuilder("/withdrawals/payment-method", this.POST)
				.AddParameterIfNotNull("amount", ((double)amount).ToString())
				.AddParameterIfNotNull("currency", currency)
				.AddParameterIfNotNull("payment_method_id", ((Guid)paymentID).ToString())
				.Build();

			return (await this.GetResponse<DepositWithdrawal>(request).ConfigureAwait(false)).Value;
		}

		/// <summary>
		/// Withdraw funds to crypto wallet
		/// </summary>
		/// <param name="amount"></param>
		/// <param name="currency"></param>
		/// <param name="crypto_address"></param>
		/// <returns></returns>
		public async Task<DepositWithdrawal> GetWithdrawalToWallet(double amount, string currency, string crypto_address)
		{
			var request = new GdaxRequestBuilder("/withdrawals/crypto", this.POST)
				.AddParameterIfNotNull("amount", ((double)amount).ToString())
				.AddParameterIfNotNull("currency", currency)
				.AddParameterIfNotNull("crypto_address", crypto_address)
				.Build();

			return (await this.GetResponse<DepositWithdrawal>(request).ConfigureAwait(false)).Value;
		}
	}
}

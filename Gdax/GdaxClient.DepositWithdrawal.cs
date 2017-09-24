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
		/// <summary>
		/// Get all payment information on account - Only need ID for payments and to check limits and Bank name etc
		/// </summary>
		/// <returns></returns>
		public async Task<IList<PaymentMethod>>GetPaymentMethods()
		{
			var request = new GdaxRequestBuilder("/payment-methods").Build();

			return (await this.GetResponse<IList<PaymentMethod>>(request).ConfigureAwait(false)).Value;
		}

		/// <summary>
		/// Withdraw to Bank Account / Fiat
		/// </summary>
		/// <param name="amount"></param>
		/// <param name="currency"></param>
		/// <param name="paymentID"></param>
		/// <returns></returns>
		public async Task<DepositWithdrawal> GetWithdrawalToBank(Decimal amount, String currency, String paymentID, String crypto_Address = null, String coinbaseID = null)
		{
			var model = new DepositWithdrawalRequest()
			{
				Amount = amount,
				Currency = currency,
				Payment_Method_Id = paymentID
			};

			var request = new GdaxRequestBuilder("/withdrawals/payment-method", HttpMethod.Post)
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
		public async Task<DepositWithdrawal> GetWithdrawalToWallet(Decimal amount, String currency, String crypto_Address, String paymentID = null, String coinbaseID = null)
		{
			var model = new DepositWithdrawalRequest()
			{
				Amount = amount,
				Currency = currency,
				Crypto_Address = crypto_Address
			};


			var request = new GdaxRequestBuilder("/withdrawals/crypto", HttpMethod.Post)
				.Build();

			return (await this.GetResponse<DepositWithdrawal>(request).ConfigureAwait(false)).Value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="amount"></param>
		/// <param name="currency"></param>
		/// <param name="coinbaseID"></param>
		/// <returns></returns>
		public async Task<DepositWithdrawal> GetWithdrawalToCoinbase(Decimal amount, String currency, String coinbaseID, String crypto_Address = null, String paymentID = null)
		{
			var model = new DepositWithdrawalRequest()
			{
				Amount = amount,
				Currency = currency,
				Coinbase_Account_Id = coinbaseID
			};


			var request = new GdaxRequestBuilder("/withdrawals/coinbase", HttpMethod.Post)
				.Build();

			return (await this.GetResponse<DepositWithdrawal>(request).ConfigureAwait(false)).Value;
		}
	}
}

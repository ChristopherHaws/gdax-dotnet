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
		public async Task<IList<PaymentMethod>>GetPaymentMethods()
		{
			var request = new GdaxRequestBuilder("/payment-methods").Build();

			return (await this.GetResponse<IList<PaymentMethod>>(request).ConfigureAwait(false)).Value;
		}

		public async Task<WithdrawalBank> WithdrawalToBank(Decimal amount, String currency, Guid paymentID)
		{
			var model = new DepositBankRequest()
			{
				Amount = amount,
				Currency = currency,
				Payment_Method_Id = paymentID
			};

			var request = new GdaxRequestBuilder("/withdrawals/payment-method", HttpMethod.Post).Build();

			request.RequestBody = JsonConvert.SerializeObject(model);

			return (await this.GetResponse<WithdrawalBank>(request).ConfigureAwait(false)).Value;
		}

		public async Task<WithdrawalCrypto> WithdrawalToWallet(Decimal amount, String currency, String crypto_Address)
		{
			var model = new WithdrawalCryptoRequest()
			{
				Amount = amount,
				Currency = currency,
				Crypto_Address = crypto_Address
			};


			var request = new GdaxRequestBuilder("/withdrawals/crypto", HttpMethod.Post).Build();

			request.RequestBody = JsonConvert.SerializeObject(model);

			return (await this.GetResponse<WithdrawalCrypto>(request).ConfigureAwait(false)).Value;
		}

		public async Task<WithdrawalCoinbase> WithdrawalToCoinbase(Decimal amount, String currency, Guid coinbaseID)
		{
			var model = new WithdrawalCoinbaseRequest()
			{
				Amount = amount,
				Currency = currency,
				Coinbase_Account_Id = coinbaseID
			};


			var request = new GdaxRequestBuilder("/withdrawals/coinbase", HttpMethod.Post).Build();

			request.RequestBody = JsonConvert.SerializeObject(model);

			return (await this.GetResponse<WithdrawalCoinbase>(request).ConfigureAwait(false)).Value;
		}


		// DEPOSITS

		public async Task<DepositBank> DepositFromBank(Decimal amount, String currency, Guid paymentID)
		{
			var model = new DepositBankRequest()
			{
				Amount = amount,
				Currency = currency,
				Payment_Method_Id = paymentID

			};

			var request = new GdaxRequestBuilder("/deposits/payment-method", HttpMethod.Post).Build();

			request.RequestBody = JsonConvert.SerializeObject(model);

			return (await this.GetResponse<DepositBank>(request).ConfigureAwait(false)).Value;
		}

		public async Task<DepositCoinbase> DepositFromCoinbase(Decimal amount, String currency, Guid coinbaseID)
		{
			var model = new DepositCoinbaseRequest()
			{
				Amount = amount,
				Currency = currency,
				Coinbase_Account_Id = coinbaseID
			};


			var request = new GdaxRequestBuilder("/deposits/coinbase-account", HttpMethod.Post).Build();

			request.RequestBody = JsonConvert.SerializeObject(model);

			return (await this.GetResponse<DepositCoinbase>(request).ConfigureAwait(false)).Value;
		}
	}
}

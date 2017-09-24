using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Gdax.Models
{
    public class DepositWithdrawalRequest
    {
		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }

		[JsonProperty("payment_method_id")]
		public Guid Payment_Method_Id { get; set; }

		[JsonProperty("crypto_address")]
		public String Crypto_Address { get; set; }

		[JsonProperty("coinbase_account_id")]
		public Guid Coinbase_Account_Id { get; set; }

	}
}

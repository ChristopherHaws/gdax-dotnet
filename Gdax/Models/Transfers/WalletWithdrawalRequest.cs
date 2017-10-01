using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	internal class WalletWithdrawalRequest
	{
		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }

		[JsonProperty("crypto_address")]
		public String CryptoAddress { get; set; }
	}
}

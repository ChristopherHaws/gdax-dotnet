using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	internal class CoinbaseDepositRequest
	{
		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }

		[JsonProperty("coinbase_account_id")]
		public Guid CoinbaseAccountId { get; set; }
	}
}

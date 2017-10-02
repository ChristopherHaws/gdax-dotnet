using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class CoinbaseWithdrawal
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }
	}
}

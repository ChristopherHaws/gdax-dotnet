using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class DepositWithdrawal
	{

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("amount")]
		public string Amount { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("payout_at")]
		public DateTime Payout_At { get; set; }
	}

}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class DepositCoinbaseRequest
	{
		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }

		[JsonProperty("coinbase_account_id")]
		public Guid Coinbase_Account_Id { get; set; }

	}
}

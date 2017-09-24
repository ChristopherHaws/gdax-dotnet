using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Gdax.Models
{
    class DepositCoinbaseRequest
	{

	[JsonProperty("amount")]
	public Decimal Amount { get; set; }

	[JsonProperty("currency")]
	public String Currency { get; set; }

	[JsonProperty("coinbase_account_id")]
	public String Coinbase_Account_Id { get; set; }

	}
}

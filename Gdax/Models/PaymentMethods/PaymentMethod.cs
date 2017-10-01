using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class PaymentMethod
	{
		[JsonProperty("allow_withdraw")]
		public Boolean AllowWithdraw { get; set; }

		[JsonProperty("name")]
		public String Name { get; set; }

		[JsonProperty("allow_deposit")]
		public Boolean AllowDeposit { get; set; }

		[JsonProperty("allow_buy")]
		public Boolean AllowBuy { get; set; }

		[JsonProperty("allow_sell")]
		public Boolean AllowSell { get; set; }

		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }

		[JsonProperty("primary_sell")]
		public Boolean PrimarySell { get; set; }

		[JsonProperty("primary_buy")]
		public Boolean PrimaryBuy { get; set; }

		[JsonProperty("type")]
		public String Type { get; set; }
	}
}

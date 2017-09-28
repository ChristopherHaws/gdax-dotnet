
using System;
using System.Diagnostics;
using Gdax.Serialization;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class PaymentMethod
	{
		[JsonProperty("allow_withdraw")]
		public bool AllowWithdraw { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("allow_deposit")]
		public bool AllowDeposit { get; set; }

		[JsonProperty("allow_buy")]
		public bool AllowBuy { get; set; }

		[JsonProperty("allow_sell")]
		public bool AllowSell { get; set; }

		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("primary_sell")]
		public bool PrimarySell { get; set; }

		[JsonProperty("primary_buy")]
		public bool PrimaryBuy { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}

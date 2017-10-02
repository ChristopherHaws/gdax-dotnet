using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class PaymentMethod
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("type")]
		public String Type { get; set; }

		[JsonProperty("name")]
		public String Name { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }

		[JsonProperty("primary_buy")]
		public Boolean IsPrimaryBuyMethod { get; set; }

		[JsonProperty("primary_sell")]
		public Boolean IsPrimarySellMethod { get; set; }

		[JsonProperty("allow_buy")]
		public Boolean CanBuy { get; set; }

		[JsonProperty("allow_sell")]
		public Boolean CanSell { get; set; }

		[JsonProperty("allow_deposit")]
		public Boolean CanDeposit { get; set; }

		[JsonProperty("allow_withdraw")]
		public Boolean CanWithdraw { get; set; }

		[JsonProperty("limits")]
		public IDictionary<String, PaymentMethodLimit> Limits { get; set; }
	}

	public class PaymentMethodLimit
	{
		//TODO: Create a converter for this that converts it to a TimeSpan
		[JsonProperty("period_in_days")]
		public Boolean PeriodInDays { get; set; }

		[JsonProperty("total")]
		public Money Total { get; set; }

		[JsonProperty("remaining")]
		public Money Remaining { get; set; }

	}

	public class Money
	{
		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }
	}
}

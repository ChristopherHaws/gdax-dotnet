using System;
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
		public PaymentMethodLimits Limits { get; set; }
	}

	public class PaymentMethodLimits
	{
		[JsonProperty("name")]
		public String Name { get; set; }

		[JsonProperty("type")]
		public String Type { get; set; }

		[JsonProperty("buy")]
		public PaymentMethodLimit[] BuyLimits { get; set; }

		[JsonProperty("sell")]
		public PaymentMethodLimit[] SellLimits { get; set; }

		[JsonProperty("deposit")]
		public PaymentMethodLimit[] DepositLimits { get; set; }
	}

	public class PaymentMethodLimit
	{
		[JsonProperty("label")]
		public String Label { get; set; }

		[JsonProperty("description")]
		public String Description { get; set; }

		[JsonProperty("period_in_days")]
		public Int32 PeriodInDays { get; set; }

		[JsonProperty("remaining")]
		public Money Remaining { get; set; }

		[JsonProperty("total")]
		public Money Total { get; set; }

	}

	public class Money
	{
		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }
	}
}

using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class CoinbaseAccounts
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("balance")]
		public Decimal Balance { get; set; }

		[JsonProperty("active")]
		public Boolean Active { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }

		[JsonProperty("primary")]
		public Boolean Primary { get; set; }

		[JsonProperty("type")]
		public String Type { get; set; }

		[JsonProperty("name")]
		public String Name { get; set; }

		[JsonProperty("sepa_deposit_information")]
		public SepaDepositInformation SepaDepositInformation { get; set; }

		[JsonProperty("wire_deposit_information")]
		public WireDepositInformation WireDepositInformation { get; set; }
	}

	public class SepaDepositInformation
	{
		[JsonProperty("bank_country_name")]
		public String BankCountryName { get; set; }

		[JsonProperty("account_name")]
		public String AccountName { get; set; }

		[JsonProperty("account_address")]
		public String AccountAddress { get; set; }

		[JsonProperty("bank_address")]
		public String BankAddress { get; set; }

		[JsonProperty("iban")]
		public String Iban { get; set; }

		[JsonProperty("bank_name")]
		public String BankName { get; set; }

		[JsonProperty("reference")]
		public String Reference { get; set; }

		[JsonProperty("swift")]
		public String Swift { get; set; }
	}

	public class WireDepositInformation
	{
		[JsonProperty("bank_address")]
		public String BankAddress { get; set; }

		[JsonProperty("account_name")]
		public String AccountName { get; set; }

		[JsonProperty("account_address")]
		public String AccountAddress { get; set; }

		[JsonProperty("account_number")]
		public String AccountNumber { get; set; }

		[JsonProperty("bank_name")]
		public String BankName { get; set; }

		[JsonProperty("bank_country")]
		public Country BankCountry { get; set; }

		[JsonProperty("reference")]
		public String Reference { get; set; }

		[JsonProperty("routing_number")]
		public String RoutingNumber { get; set; }
	}

	public class Country
	{
		[JsonProperty("code")]
		public String Code { get; set; }

		[JsonProperty("name")]
		public String Name { get; set; }
	}
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class CoinbaseAccounts
	{

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("balance")]
		public string Balance { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("primary")]
		public bool Primary { get; set; }

		[JsonProperty("active")]
		public bool Active { get; set; }

		[JsonProperty("wire_deposit_information")]
		public WireDepositInformation Wire_deposit_information { get; set; }

		[JsonProperty("sepa_deposit_information")]
		public SepaDepositInformation Sepa_deposit_information { get; set; }
	}

	public class WireDepositInformation
	{

		[JsonProperty("account_number")]
		public string Account_number { get; set; }

		[JsonProperty("routing_number")]
		public string Routing_number { get; set; }

		[JsonProperty("bank_name")]
		public string Bank_name { get; set; }

		[JsonProperty("bank_address")]
		public string Bank_address { get; set; }

		[JsonProperty("bank_country")]
		public BankCountry Bank_country { get; set; }

		[JsonProperty("account_name")]
		public string Account_name { get; set; }

		[JsonProperty("account_address")]
		public string Account_address { get; set; }

		[JsonProperty("reference")]
		public string Reference { get; set; }
	}

	public class SepaDepositInformation
	{

		[JsonProperty("iban")]
		public string Iban { get; set; }

		[JsonProperty("swift")]
		public string Swift { get; set; }

		[JsonProperty("bank_name")]
		public string Bank_name { get; set; }

		[JsonProperty("bank_address")]
		public string Bank_address { get; set; }

		[JsonProperty("bank_country_name")]
		public string Bank_country_name { get; set; }

		[JsonProperty("account_name")]
		public string Account_name { get; set; }

		[JsonProperty("account_address")]
		public string Account_address { get; set; }

		[JsonProperty("reference")]
		public string Reference { get; set; }
	}

	public class BankCountry
	{

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}


}

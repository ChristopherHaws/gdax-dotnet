using System;
using System.Collections.Generic;
using Gdax.Serialization;
using Newtonsoft.Json;

namespace Gdax.Models
{

		public partial class CoinbaseAccounts
		{
			[JsonProperty("id")]
			public Guid Id { get; set; }

			[JsonProperty("balance")]
			public Decimal Balance { get; set; }

			[JsonProperty("active")]
			public bool Active { get; set; }

			[JsonProperty("currency")]
			public string Currency { get; set; }

			[JsonProperty("primary")]
			public bool Primary { get; set; }

			[JsonProperty("type")]
			public string Type { get; set; }

			[JsonProperty("name")]
			public string Name { get; set; }

			[JsonProperty("sepa_deposit_information")]
			public SepaDepositInformation SepaDepositInformation { get; set; }

			[JsonProperty("wire_deposit_information")]
			public WireDepositInformation WireDepositInformation { get; set; }
		}

		public partial class SepaDepositInformation
		{
			[JsonProperty("bank_country_name")]
			public string BankCountryName { get; set; }

			[JsonProperty("account_name")]
			public string AccountName { get; set; }

			[JsonProperty("account_address")]
			public string AccountAddress { get; set; }

			[JsonProperty("bank_address")]
			public string BankAddress { get; set; }

			[JsonProperty("iban")]
			public string Iban { get; set; }

			[JsonProperty("bank_name")]
			public string BankName { get; set; }

			[JsonProperty("reference")]
			public string Reference { get; set; }

			[JsonProperty("swift")]
			public string Swift { get; set; }
		}

		public partial class WireDepositInformation
		{
			[JsonProperty("bank_address")]
			public string BankAddress { get; set; }

			[JsonProperty("account_name")]
			public string AccountName { get; set; }

			[JsonProperty("account_address")]
			public string AccountAddress { get; set; }

			[JsonProperty("account_number")]
			public string AccountNumber { get; set; }

			[JsonProperty("bank_name")]
			public string BankName { get; set; }

			[JsonProperty("bank_country")]
			public BankCountry BankCountry { get; set; }

			[JsonProperty("reference")]
			public string Reference { get; set; }

			[JsonProperty("routing_number")]
			public string RoutingNumber { get; set; }
		}

		public partial class BankCountry
		{
			[JsonProperty("code")]
			public string Code { get; set; }

			[JsonProperty("name")]
			public string Name { get; set; }
		}


		public partial class CoinbaseAccounts
		{
			public static CoinbaseAccounts[] FromJson(string json)
			{
				return JsonConvert.DeserializeObject<CoinbaseAccounts[]>(json, Converter.Settings);
			}
		}

		public static class SerializeAccounts
		{
			public static string ToJson(this CoinbaseAccounts[] self)
			{
				return JsonConvert.SerializeObject(self, Converter.Settings);
			}
		}

		
	}

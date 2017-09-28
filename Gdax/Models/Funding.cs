using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class Funding
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("order_id")]
		public string OrderId { get; set; }

		[JsonProperty("profile_id")]
		public string ProfileId { get; set; }

		[JsonProperty("amount")]
		public string Amount { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("repaid_amount")]
		public string RepaidAmount { get; set; }

		[JsonProperty("default_amount")]
		public string DefaultAmount { get; set; }

		[JsonProperty("repaid_default")]
		public bool RepaidDefault { get; set; }
	}

}

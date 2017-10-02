using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class Funding
	{
		[JsonProperty("id")]
		public String Id { get; set; }

		[JsonProperty("order_id")]
		public String OrderId { get; set; }

		[JsonProperty("profile_id")]
		public String ProfileId { get; set; }

		[JsonProperty("amount")]
		public String Amount { get; set; }

		[JsonProperty("status")]
		public String Status { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }

		[JsonProperty("repaid_amount")]
		public String RepaidAmount { get; set; }

		[JsonProperty("default_amount")]
		public String DefaultAmount { get; set; }

		[JsonProperty("repaid_default")]
		public Boolean RepaidDefault { get; set; }
	}
}

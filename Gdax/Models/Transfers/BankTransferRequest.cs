using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	internal class BankTransferRequest
	{
		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("currency")]
		public String Currency { get; set; }

		[JsonProperty("payment_method_id")]
		public Guid PaymentMethodId { get; set; }
	}
}

using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public class Transfer
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("type")]
		public TransferType Type { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("completed_at")]
		public DateTime? CompletedAt { get; set; }

		[JsonProperty("canceled_at")]
		public DateTime? CanceledAt { get; set; }

		[JsonProperty("processed_at")]
		public DateTime? ProcessedAt { get; set; }

		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("details")]
		public TransferDetails Details { get; set; }
	}

	public enum TransferType
	{
		Withdraw,
		Deposit,
	}

	public class TransferDetails
	{
		[JsonProperty("coinbase_account_id")]
		public Guid CoinbaseAccountId { get; set; }

		[JsonProperty("coinbase_transaction_id")]
		public String CoinbaseTransactionId { get; set; }

		[JsonProperty("crypto_address")]
		public String CryptoAddress { get; set; }

		[JsonProperty("crypto_transaction_hash")]
		public String CryptoTransactionHash { get; set; }

		[JsonProperty("crypto_transaction_id")]
		public String CryptoTransactionId { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gdax
{
	public static class GetAccountsQuery
	{
		public static async Task<IList<Account>> GetAccountsAsync(this GdaxClient client)
		{
			Check.NotNull(client, nameof(client));

			var request = new GdaxRequestBuilder("/accounts").Build();

			var response = await client.GetResponseAsync<IList<Account>>(request).ConfigureAwait(false);

			return response.Value;
		}

		public class Account
		{
			/// <summary>
			/// Gets or sets the Account ID
			/// </summary>
			[JsonProperty("id")]
			public Guid Id { get; set; }

			/// <summary>
			/// Gets or sets the profile ID
			/// </summary>
			[JsonProperty("profile_id")]
			public Guid ProfileId { get; set; }

			/// <summary>
			/// Gets or sets the currency of the account
			/// </summary>
			[JsonProperty("currency")]
			public String Currency { get; set; }

			/// <summary>
			/// Gets or sets the total funds in the account
			/// </summary>
			[JsonProperty("balance")]
			public Decimal Balance { get; set; }

			/// <summary>
			///		<para>
			///			Gets or sets the funds on hold (not available for use).
			///		</para>
			///		<para>
			///			When you place an order, the funds for the order are placed on hold. They cannot be used for
			///			other orders or withdrawn. Funds will remain on hold until the order is filled or canceled.
			///		</para>
			/// </summary>
			[JsonProperty("holds")]
			public Decimal Holds { get; set; }

			/// <summary>
			/// Gets or sets the funds available to withdraw* or trade
			/// </summary>
			[JsonProperty("available")]
			public Decimal Available { get; set; }

			/// <summary>
			/// Gets or sets the margin] true if the account belongs to margin profile
			/// </summary>
			[JsonProperty("margin_enabled")]
			public Boolean MarginEnabled { get; set; }

			/// <summary>
			/// Gets or sets the margin] amount of funding GDAX is currently providing this account
			/// </summary>
			[JsonProperty("funded_amount")]
			public Decimal FundedAmount { get; set; }

			/// <summary>
			/// Gets or sets the margin] amount defaulted on due to not being able to pay back funding
			/// </summary>
			[JsonProperty("default_amount")]
			public Decimal DefaultAmount { get; set; }
		}
	}

}

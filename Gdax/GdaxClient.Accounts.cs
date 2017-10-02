using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public partial class GdaxClient
	{
		public async Task<PagedResults<Ledger, Int32?>> GetAccountHistory(Guid accountId, PagingOptions<Int32?> paging = null)
		{
			Check.NotEmpty(accountId, nameof(accountId));

			var request = new GdaxRequestBuilder($"/accounts/{accountId}/ledger")
				.AddPagingOptions(paging, CursorEncoders.Int32)
				.Build();

			var response = await this.GetResponse<IList<Ledger>>(request).ConfigureAwait(false);

			return new PagedResults<Ledger, Int32?>(response, CursorEncoders.Int32, paging);
		}

		public async Task<IList<Account>> GetAccounts()
		{
			var request = new GdaxRequestBuilder("/accounts").Build();

			var response = await this.GetResponse<IList<Account>>(request).ConfigureAwait(false);

			return response.Value;
		}

		public async Task<IList<CoinbaseAccounts>> GetCoinbaseAccounts()
		{
			var request = new GdaxRequestBuilder("/coinbase-accounts").Build();

			var response = await this.GetResponse<IList<CoinbaseAccounts>>(request).ConfigureAwait(false);

			return response.Value;
		}

		public async Task<PagedResults<Transfer, DateTimeOffset?>> GetTransfers(Guid accountId, PagingOptions<DateTimeOffset?> paging = null)
		{
			Check.NotEmpty(accountId, nameof(accountId));

			var request = new GdaxRequestBuilder($"/accounts/{accountId}/transfers")
				.AddPagingOptions(paging, CursorEncoders.DateTimeOffset)
				.Build();

			var response = await this.GetResponse<IList<Transfer>>(request).ConfigureAwait(false);

			return new PagedResults<Transfer, DateTimeOffset?>(response, CursorEncoders.DateTimeOffset, paging);
		}
	}
}

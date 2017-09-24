using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IAccountClient
	{
		Task<PagedResults<Ledger, Int32?>> GetAccountHistory(Guid accountId, PagingOptions<Int32?> paging = null);

		Task<IList<Account>> GetAccounts();

		Task<IList<CoinbaseAccounts>> GetCoinbaseAccounts();

		Task<PagedResults<Transfer, DateTimeOffset?>> GetTransfers(Guid accountId, PagingOptions<DateTimeOffset?> paging = null);
	}
}

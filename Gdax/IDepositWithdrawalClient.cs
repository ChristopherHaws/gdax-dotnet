using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface ITransferClient
	{
		Task<IList<PaymentMethod>> GetPaymentMethods();

		Task<BankTransfer> WithdrawToBank(Decimal amount, String currency, Guid paymentID);

		Task<WalletWithdrawal> WithdrawToWallet(Decimal amount, String currency, String cryptoAddress);

		Task<CoinbaseWithdrawal> WithdrawToCoinbase(Decimal amount, String currency, Guid coinbaseID);

		Task<BankTransfer> DepositFromBank(Decimal amount, String currency, Guid paymentID);

		Task<CoinbaseDeposit> DepositFromCoinbase(Decimal amount, String currency, Guid coinbaseID);
	}
}

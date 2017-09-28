using System;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IDepositWithdrawalClient
	{
		Task<PaymentMethod> GetPaymentMethods();

		Task<WithdrawalBank> WithdrawalToBank(Decimal amount, String currency, Guid paymentID);

		Task<WithdrawalCrypto> WithdrawalToWallet(Decimal amount, String currency, String crypto_Address);

		Task<WithdrawalCoinbase> WithdrawalToCoinbase(Decimal amount, String currency, Guid coinbaseID);

		Task<DepositBank> DepositFromBank(Decimal amount, String currency, Guid paymentID);

		Task<DepositCoinbase> DepositFromCoinbase(Decimal amount, String currency, Guid coinbaseID);
	}
}

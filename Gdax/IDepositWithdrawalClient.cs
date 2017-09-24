using System;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IDepositWithdrawalClient
	{
		Task<PaymentMethod> GetPaymentMethods();

		Task<DepositWithdrawal> WithdrawalToBank(Decimal amount, String currency, String paymentID);

		Task<DepositWithdrawal> GWithdrawalToWallet(Decimal amount, String currency, String crypto_Address);

		Task<DepositWithdrawal> WithdrawalToCoinbase(Decimal amount, String currency, String coinbaseID);

		Task<DepositWithdrawal> DepositFromBank(Decimal amount, String currency, String paymentID);

		Task<DepositWithdrawal> DepositFromCoinbase(Decimal amount, String currency, String coinbaseID);
	}
}

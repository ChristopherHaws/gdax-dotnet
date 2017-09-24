using System;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IDepositWithdrawalClient
	{
		Task<PaymentMethod> GetPaymentMethods();

		Task<DepositWithdrawal> GetWithdrawalToBank(Decimal amount, String currency, String paymentID, String crypto_Address = null, String coinbaseID = null);

		Task<DepositWithdrawal> GetWithdrawalToWallet(Decimal amount, String currency, String crypto_Address, String paymentID = null, String coinbaseID = null);

		Task<DepositWithdrawal> GetWithdrawalToCoinbase(Decimal amount, String currency, String coinbaseID, String crypto_Address = null, String paymentID = null);
	}
}

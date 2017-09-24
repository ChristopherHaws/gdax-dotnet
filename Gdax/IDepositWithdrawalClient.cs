using System;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IDepositWithdrawalClient
	{
		Task<PaymentMethod> GetPaymentMethods();

		Task<DepositWithdrawal> GetWithdrawalToBank(Decimal amount, String currency, string paymentID);

		Task<DepositWithdrawal> GetWithdrawalToWallet(double amount, string currency, string crypto_address);
	}
}

﻿using System;
using System.Threading.Tasks;
using Gdax.Models;

namespace Gdax
{
	public interface IDepositWithdrawalClient
	{
		Task<PaymentMethods> GetPaymentMethods();

		Task<DepositWithdrawal> GetWithdrawalToBank(double amount, string currency, Guid paymentID);

		Task<DepositWithdrawal> GetWithdrawalToWallet(double amount, string currency, string crypto_address);
	}
}
using System;
namespace Gdax.Models
{
	public enum OrderType
	{
		Limit,
		Market,
		Stop
	}

	[Flags]
	public enum OrderStates
	{
		All,
		Open,
		Pending,
		Active,
		Done,
		Settled
	}
}

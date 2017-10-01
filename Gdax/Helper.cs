using System;
using System.Diagnostics;
using Gdax.Models;

namespace Gdax
{
	public static class Helper
	{
		internal static Side ToOrderSide(this String value)
		{
			Debug.WriteLine("Order Side Value = " + value);
			switch (value)
			{
				case "buy":
					return Side.Buy;

				case "sell":
					return Side.Sell;
			}

			throw new ArgumentOutOfRangeException("value");
		}

		internal static OrderType ToOrderType(this String value)
		{
			Debug.WriteLine("Order Type Value = " + value);
			switch (value)
			{
				case "market":
					return OrderType.Market;

				case "limit":
					return OrderType.Limit;

				case "stop":
					return OrderType.Stop;
			}

			throw new ArgumentOutOfRangeException("value");
		}
	}
}

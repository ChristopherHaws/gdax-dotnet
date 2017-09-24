using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Gdax.Models;

namespace Gdax
{
    public static class Helper
    {
		internal static Side ToOrderSide(this string value)
		{
			Debug.WriteLine("Order Side Value = " + value);
			switch (value)
			{
				case "buy":
					return Side.buy;

				case "sell":
					return Side.sell;
			}

			throw new ArgumentOutOfRangeException("value");
		}

		internal static OrderType ToOrderType(this string value)
		{
			Debug.WriteLine("Order Type Value = " + value);
			switch (value)
			{
				case "market":
					return OrderType.market;

				case "limit":
					return OrderType.limit;

				case "stop":
					return OrderType.stop;
			}

			throw new ArgumentOutOfRangeException("value");
		}
	}
}

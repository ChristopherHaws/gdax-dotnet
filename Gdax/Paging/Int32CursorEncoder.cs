using System;

namespace Gdax
{
	internal class Int32CursorEncoder : ICursorEncoder<Int32?>
	{
		public Int32? Decode(String value)
		{
			if (!Int32.TryParse(value, out var number))
			{
				return null;
			}

			return number;
		}

		public String Encode(Int32? value)
		{
			if (!value.HasValue)
			{
				return null;
			}

			return value.Value.ToString();
		}
	}
}

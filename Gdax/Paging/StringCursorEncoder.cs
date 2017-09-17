using System;

namespace Gdax
{
	internal class StringCursorEncoder : ICursorEncoder<String>
	{
		public String Decode(String value) => value;

		public String Encode(String value) => value;
	}
}

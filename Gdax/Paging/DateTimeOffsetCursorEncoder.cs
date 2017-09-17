using System;

namespace Gdax
{
	internal class DateTimeOffsetCursorEncoder : ICursorEncoder<DateTimeOffset?>
	{
		public DateTimeOffset? Decode(String value) => String.IsNullOrWhiteSpace(value) ? null : (DateTimeOffset?)DateTimeOffset.Parse(value);

		public String Encode(DateTimeOffset? value) => value?.ToString("yyyy-MM-dd hh:mm:ss.ffffffzz");
	}
}

using System;

namespace Gdax
{
	internal class DateTimeCursorEncoder : ICursorEncoder<DateTime?>
	{
		public DateTime? Decode(String value) => String.IsNullOrWhiteSpace(value) ? null : (DateTime?)DateTime.Parse(value).ToUniversalTime();

		public String Encode(DateTime? value) => value?.ToString("yyyy-MM-ddThh:mm:ss.ffffffZ");
	}
}

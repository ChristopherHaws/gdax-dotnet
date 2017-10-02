using System;

namespace Gdax
{
	public static class CursorEncoders
	{
		public static ICursorEncoder<String> String = new StringCursorEncoder();
		public static ICursorEncoder<Int32?> Int32 = new Int32CursorEncoder();
		public static ICursorEncoder<DateTimeOffset?> DateTimeOffset = new DateTimeOffsetCursorEncoder();
		public static ICursorEncoder<DateTime?> DateTime = new DateTimeCursorEncoder();
	}
}

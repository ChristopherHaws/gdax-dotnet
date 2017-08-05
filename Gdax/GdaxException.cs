using System;

namespace Gdax
{
	public class GdaxException : Exception
	{
		public GdaxException()
			: base()
		{
		}

		public GdaxException(String message)
			: base(message)
		{

		}

		public GdaxException(Exception innerException)
			: base(null, innerException)
		{
		}

		public GdaxException(String message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}

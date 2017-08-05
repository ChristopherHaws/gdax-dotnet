using System;

namespace Gdax
{
	internal static class Check
	{
		public static T NotNull<T>(T value, String paramName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(paramName);
			}

			return value;
		}

		public static T NotNull<T>(T value, String paramName, String message)
		{
			if (value == null)
			{
				throw new ArgumentNullException(paramName, message);
			}

			return value;
		}

		public static String NotNullOrEmpty(String value, String paramName)
		{
			if (String.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException(paramName);
			}

			return value;
		}

		public static String NotNullOrEmpty(String value, String paramName, String message)
		{
			if (String.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException(paramName, message);
			}

			return value;
		}

		public static String NotNullOrWhiteSpace(String value, String paramName)
		{
			if (String.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException(paramName);
			}

			return value;
		}

		public static String NotNullOrWhiteSpace(String value, String paramName, String message)
		{
			if (String.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException(paramName, message);
			}

			return value;
		}

		public static Guid NotEmpty(Guid value, String paramName)
		{
			if (value == Guid.Empty)
			{
				throw new ArgumentNullException(paramName);
			}

			return value;
		}

		public static Guid NotEmpty(Guid value, String paramName, String message)
		{
			if (value == Guid.Empty)
			{
				throw new ArgumentNullException(paramName, message);
			}

			return value;
		}
	}
}

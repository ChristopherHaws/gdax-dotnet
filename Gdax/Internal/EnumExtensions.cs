using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Gdax.Internal
{
	internal static class EnumExtensions
	{
		public static String GetEnumMemberValue<T>(this T value)
			where T : struct, IConvertible
		{
			return typeof(T)
				.GetTypeInfo()
				.DeclaredMembers
				.SingleOrDefault(x => x.Name == value.ToString())
				?.GetCustomAttribute<EnumMemberAttribute>(false)
				?.Value;
		}

		public static String GetEnumMemberValue<T>(this T? value)
			where T : struct, IConvertible
		{
			if (value == null)
			{
				return null;
			}

			return value.Value.GetEnumMemberValue();
		}
	}
}

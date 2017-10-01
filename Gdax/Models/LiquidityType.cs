using System;
using Newtonsoft.Json;

namespace Gdax.Models
{
	public enum LiquidityType
	{
		Maker,
		Taker
	}

	public class LiquidityTypeConverter : JsonConverter
	{
		public override Boolean CanConvert(Type objectType)
		{
			return objectType == typeof(LiquidityType);
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.String)
			{
				throw new Exception("Invalid token. Expected string");
			}

			var value = reader.Value as String;

			switch (value)
			{
				case "m":
				case "M":
					return LiquidityType.Maker;
				case "t":
				case "T":
					return LiquidityType.Taker;
				default:
					throw new GdaxException("Invalid liquidity type.");
			}
		}

		public override void WriteJson(JsonWriter writer, Object input, Newtonsoft.Json.JsonSerializer serializer)
		{
			if (input is LiquidityType value)
			{
				writer.WriteValue(value == LiquidityType.Maker ? "M" : "T");
			}
			else
			{
				throw new ArgumentException(nameof(input));
			}
		}
	}
}

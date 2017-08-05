using System;
using Newtonsoft.Json;

namespace Gdax
{
	internal class JsonSerializer : ISerialzer
	{
		public String Serialize<T>(T value)
		{
			return JsonConvert.SerializeObject(value);
		}

		public T Deserialize<T>(String value)
		{
			return JsonConvert.DeserializeObject<T>(value);
		}
	}
}

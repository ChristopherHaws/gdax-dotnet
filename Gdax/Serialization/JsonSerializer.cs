using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Gdax.Serialization
{
	internal class JsonSerializer : ISerialzer
	{
		private readonly JsonSerializerSettings settings;

		public JsonSerializer()
		{
			this.settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				NullValueHandling = NullValueHandling.Ignore,
				Converters =
				{
					new StringEnumConverter
					{
						CamelCaseText = true
					}
				},
			};
		}

		public String Serialize<T>(T value)
		{
			return JsonConvert.SerializeObject(value, this.settings);
		}

		public T Deserialize<T>(String value)
		{
			try
			{
				return JsonConvert.DeserializeObject<T>(value, this.settings);
			}
			catch (JsonSerializationException ex)
			{
				GdaxErrorMessage error = null;

				try
				{
					error = JsonConvert.DeserializeObject<GdaxErrorMessage>(value, this.settings);
				}
				catch (Exception)
				{
					// NOOP
				}

				if (error != null)
				{
					throw new GdaxException(error.Message);
				}
				else
				{
					throw new GdaxException($"Could not deserialize '{value}'.", ex);
				}
			}
		}
	}

	internal class GdaxErrorMessage
	{
		[JsonProperty("message")]
		public String Message { get; set; }
	}
}

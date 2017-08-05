using System;

namespace Gdax.Serialization
{
	public interface ISerialzer
	{
		String Serialize<T>(T value);
		T Deserialize<T>(String value);
	}
}

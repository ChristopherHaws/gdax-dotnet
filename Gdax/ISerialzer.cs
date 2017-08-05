using System;

namespace Gdax
{
	public interface ISerialzer
	{
		String Serialize<T>(T value);
		T Deserialize<T>(String value);
	}
}

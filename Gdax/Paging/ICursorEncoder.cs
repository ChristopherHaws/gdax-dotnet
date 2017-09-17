using System;

namespace Gdax
{
	public interface ICursorEncoder<TCursor>
	{
		TCursor Decode(String value);

		String Encode(TCursor value);
	}
}

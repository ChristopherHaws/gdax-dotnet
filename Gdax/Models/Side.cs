using System.Runtime.Serialization;

namespace Gdax.Models
{
	public enum Side
	{
		[EnumMember(Value = "buy")]
		Buy,

		[EnumMember(Value = "sell")]
		Sell
	}
}

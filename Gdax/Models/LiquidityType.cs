using System.Runtime.Serialization;

namespace Gdax.Models
{
	public enum LiquidityType
	{
		[EnumMember(Value = "M")]
		Maker,

		[EnumMember(Value = "T")]
		Taker
	}
}

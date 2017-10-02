using System.Runtime.Serialization;

namespace Gdax.Models
{
	public enum OrderType
	{
		[EnumMember(Value = "limit")]
		Limit,

		[EnumMember(Value = "market")]
		Market,

		[EnumMember(Value = "stop")]
		Stop
	}
}

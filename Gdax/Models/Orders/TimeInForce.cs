using System.Runtime.Serialization;

namespace Gdax.Models
{
	public enum TimeInForce
	{
		[EnumMember(Value = "GTC")]
		GoodTillCanceled,

		[EnumMember(Value = "GTT")]
		GoodTillTime,

		[EnumMember(Value = "IOC")]
		ImmediateOrCancel,

		[EnumMember(Value = "FOK")]
		FillOrKill
	}
}


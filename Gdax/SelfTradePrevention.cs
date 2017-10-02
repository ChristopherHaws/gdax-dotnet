using System.Runtime.Serialization;

namespace Gdax.Models
{
	public enum SelfTradePrevention
	{
		[EnumMember(Value = "dc")]
		DecreaseAndCancel,

		[EnumMember(Value = "co")]
		CancelOldest,

		[EnumMember(Value = "cn")]
		CancelNewest,

		[EnumMember(Value = "cb")]
		CancelBoth
	}
}


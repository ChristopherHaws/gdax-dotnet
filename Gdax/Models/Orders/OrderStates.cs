using System;
using System.Runtime.Serialization;

namespace Gdax.Models
{
	[Flags]
	public enum OrderStates
	{
		[EnumMember(Value = "all")]
		All = 0x1,

		[EnumMember(Value = "open")]
		Open = 0x2,

		[EnumMember(Value = "pending")]
		Pending = 0x3,

		[EnumMember(Value = "active")]
		Active = 0x4,

		[EnumMember(Value = "done")]
		Done = 0x5,

		[EnumMember(Value = "settled")]
		Settled = 0x6
	}
}

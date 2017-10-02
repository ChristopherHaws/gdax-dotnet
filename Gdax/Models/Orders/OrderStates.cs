using System;
namespace Gdax.Models
{
	[Flags]
	public enum OrderStates
	{
		All = 0x1,
		Open = 0x2,
		Pending = 0x3,
		Active = 0x4,
		Done = 0x5,
		Settled = 0x6
	}
}

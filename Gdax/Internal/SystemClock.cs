using System;

namespace Gdax.Internal
{
	public interface ISystemClock
	{
		DateTime Now { get; }
		DateTime UtcNow { get; }
		Double UnixTimestamp { get; }
	}

	public class SystemClock : ISystemClock
	{
		public DateTime Now => DateTime.Now;
		public DateTime UtcNow => DateTime.UtcNow;
		public Double UnixTimestamp => DateTime.UtcNow.ToUnixTimestamp();
	}
}

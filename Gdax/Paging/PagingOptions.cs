using System;

namespace Gdax
{
	public class PagingOptions<TCursor>
	{
		public Int32? Limit { get; set; }

		/// <summary>
		/// Maps to CB-BEFORE
		/// </summary>
		public TCursor NewerThan { get; set; }

		/// <summary>
		/// Maps to CB-AFTER
		/// </summary>
		public TCursor OlderThan { get; set; }
	}
}

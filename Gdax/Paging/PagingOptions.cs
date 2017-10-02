using System;

namespace Gdax
{
	public class PagingOptions<TCursor>
	{
		public Int32? Limit { get; set; }
		public String SortBy { get; set; }
		public SortOrder? SortOrder { get; set; }

		/// <summary>
		/// Maps to CB-BEFORE (Newer Than)
		/// </summary>
		public TCursor NewerThan { get; set; }

		/// <summary>
		/// Maps to CB-AFTER (Older Than)
		/// </summary>
		public TCursor OlderThan { get; set; }
	}
}

using System;

namespace Gdax
{
	public class PagingOptions<TCursor>
	{
		public Int32? Limit { get; set; }
		public TCursor Before { get; set; }
		public TCursor After { get; set; }
	}
}

using System;

namespace Gdax.CommonModels
{
	public class PaginationOptions
	{
		public Int32? Limit { get; set; }
		public CursorType CursorType { get; set; }
		public String Value { get; set; }
	}
}

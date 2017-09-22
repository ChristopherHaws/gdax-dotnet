using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace Gdax
{
	public class GdaxResponse<T> : GdaxResponse
	{
		public GdaxResponse(KeyValuePair<String, IEnumerable<String>>[] headers, HttpStatusCode statusCode, String content, T typedContent)
			: base(headers, statusCode, content)
		{
			this.Value = typedContent;
		}

		public T Value { get; }
	}
}

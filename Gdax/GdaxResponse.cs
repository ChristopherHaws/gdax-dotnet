using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Gdax
{
	public class GdaxResponse
	{
		public GdaxResponse(KeyValuePair<String, IEnumerable<String>>[] headers, HttpStatusCode statusCode, String content)
		{
			this.Headers = headers.ToArray();
			this.StatusCode = statusCode;
			this.Content = content;
		}

		public KeyValuePair<String, IEnumerable<String>>[] Headers { get; }
		public HttpStatusCode StatusCode { get; }
		public String Content { get; }
	}
}

using System;
using System.Net.Http;

namespace Gdax
{
	public class GdaxRequest
	{
		public GdaxRequest(HttpMethod httpMethod, String relativePath, String requestBody = null)
		{
			this.HttpMethod = httpMethod;
			this.RequestUrl = relativePath;
			this.RequestBody = requestBody;
		}
		
		public HttpMethod HttpMethod { get; set; }
		public String RequestUrl { get; set; }
		public String RequestBody { get; set; }
	}
}

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
			this.Timestamp = DateTime.UtcNow.ToUnixTimestamp();
		}

		public Double Timestamp { get; set; }
		public HttpMethod HttpMethod { get; set; }
		public String RequestUrl { get; set; }
		public String RequestBody { get; set; }
		public Boolean IsExpired => (this.GetCurrentUnixTimeStamp() - this.Timestamp) >= 30;

		protected virtual Double GetCurrentUnixTimeStamp()
		{
			return DateTime.UtcNow.ToUnixTimestamp();
		}
	}
}

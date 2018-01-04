using System;
using System.Globalization;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gdax.Internal;

namespace Gdax
{
	public class GdaxAuthenticationHandler : DelegatingHandler
	{
		private readonly GdaxCredentials credentials;
		private readonly ISystemClock clock;

		public GdaxAuthenticationHandler(GdaxCredentials credentials)
			: this(credentials, new SystemClock())
		{
		}

		public GdaxAuthenticationHandler(GdaxCredentials credentials, ISystemClock clock)
			: base()
		{
			this.credentials = Check.NotNull(credentials, nameof(credentials));
			this.clock = Check.NotNull(clock, nameof(clock));
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var timestamp = this.clock.UnixTimestamp;
			var signature = await this.ComputeSignature(request, timestamp);

			SetHttpRequestHeaders(request, timestamp, signature);

			return await base.SendAsync(request, cancellationToken);
		}

		private void SetHttpRequestHeaders(HttpRequestMessage requestMessage, Double timestamp, String signature)
		{
			requestMessage.Headers.Add("CB-ACCESS-KEY", this.credentials.ApiKey);
			requestMessage.Headers.Add("CB-ACCESS-SIGN", signature);
			requestMessage.Headers.Add("CB-ACCESS-TIMESTAMP", timestamp.ToString(CultureInfo.InvariantCulture));
			requestMessage.Headers.Add("CB-ACCESS-PASSPHRASE", this.credentials.Passphrase);
			requestMessage.Headers.Add("User-Agent", this.credentials.ApplicationName);
		}

		private async Task<String> ComputeSignature(HttpRequestMessage request, Double timestamp)
		{
			var data = Convert.FromBase64String(this.credentials.Secret);
			var content = request.Content == null ? null : (await request.Content.ReadAsStringAsync());
			var prehash = timestamp.ToString(CultureInfo.InvariantCulture) + request.Method.ToString().ToUpper() + request.RequestUri.PathAndQuery + content;

			return HashString(prehash, data);
		}

		private String HashString(String value, Byte[] secret)
		{
			var bytes = Encoding.UTF8.GetBytes(value);

			using (var hmac = new HMACSHA256(secret))
			{
				var hash = hmac.ComputeHash(bytes);
				return Convert.ToBase64String(hash);
			}
		}
	}
}

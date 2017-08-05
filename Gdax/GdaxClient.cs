using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gdax.Authentication;
using Gdax.MarketData;

namespace Gdax
{
	public class GdaxClient
	{
		private readonly IAuthenticator authenticator;
		private readonly ISerialzer serialzer;
		private readonly HttpClient http;

		public GdaxClient(IAuthenticator authenticator)
			: this(authenticator, new JsonSerializer())
		{
		}

		public GdaxClient(IAuthenticator authenticator, ISerialzer serialzer)
		{
			this.authenticator = Check.NotNull(authenticator, nameof(authenticator));
			this.serialzer = Check.NotNull(serialzer, nameof(serialzer));
			this.http = new HttpClient();
			this.MarketData = new MarketDataService(this);
		}

		public Uri BaseUri { get; } = new Uri(@"https://api.gdax.com");

		public IMarketDataService MarketData { get; }

		public async Task<Time> GetServerTimeAsync()
		{
			return (await this.GetResponseAsync<Time>(
				new GdaxRequest(HttpMethod.Get, "/time")
			).ConfigureAwait(false)).Value;
		}

		public async Task<GdaxResponse<TResponse>> GetResponseAsync<TResponse>(GdaxRequest request)
		{
			var httpResponse = await this.GetResponseAsync(request).ConfigureAwait(false);
			var contentBody = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

			return new GdaxResponse<TResponse>(
				httpResponse.Headers.ToArray(),
				httpResponse.StatusCode,
				contentBody,
				this.serialzer.Deserialize<TResponse>(contentBody)
			);
		}

		public async Task<HttpResponseMessage> GetResponseAsync(GdaxRequest request)
		{
			var httpRequest = this.BuildRequestMessagee(request);
			httpRequest.Headers.Add("User-Agent", @"gdax-dotnet");

			return await this.http.SendAsync(httpRequest).ConfigureAwait(false);
		}

		private HttpRequestMessage BuildRequestMessagee(GdaxRequest request)
		{
			var requestMessage = new HttpRequestMessage
			{
				RequestUri = new Uri(this.BaseUri, request.RequestUrl),
				Method = request.HttpMethod
			};

			if (request.RequestBody != null)
			{
				requestMessage.Content = new StringContent(request.RequestBody, Encoding.UTF8, "application/json");
			}

			var token = this.authenticator.GetAuthenticationToken(request);
			SetHttpRequestHeaders(requestMessage, token);

			return requestMessage;
		}

		private static void SetHttpRequestHeaders(HttpRequestMessage requestMessage, AuthenticationToken token)
		{
			requestMessage.Headers.Add("CB-ACCESS-KEY", token.ApiKey);
			requestMessage.Headers.Add("CB-ACCESS-SIGN", token.Signature);
			requestMessage.Headers.Add("CB-ACCESS-TIMESTAMP", token.Timestamp);
			requestMessage.Headers.Add("CB-ACCESS-PASSPHRASE", token.Passphrase);
		}
	}
}

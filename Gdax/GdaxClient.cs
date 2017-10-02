using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gdax.Serialization;

namespace Gdax
{
	public partial class GdaxClient : IGdaxClient, IDisposable
	{
		private readonly GdaxCredentials credentials;
		private readonly ISerialzer serialzer;
		private readonly HttpClient http;

		public GdaxClient(String apiKey, String passphrase, String secret, String applicationName = "gdax-dotnet")
			: this(new GdaxCredentials(apiKey, passphrase, secret, applicationName), new JsonSerializer())
		{
		}

		public GdaxClient(GdaxCredentials credentials)
			: this(credentials, new JsonSerializer())
		{
		}

		public GdaxClient(GdaxCredentials credentials, ISerialzer serialzer)
		{
			this.credentials = Check.NotNull(credentials, nameof(credentials));
			this.serialzer = Check.NotNull(serialzer, nameof(serialzer));

			this.http = new HttpClient(new GdaxAuthenticationHandler(credentials)
			{
				InnerHandler = new HttpClientHandler()
			});
		}

		public void Dispose()
		{
			this.http?.Dispose();
		}

		public Boolean UseSandbox { get; set; } = false;

		public Uri BaseUri => this.UseSandbox
			? new Uri(@"https://api-public.sandbox.gdax.com")
			: new Uri(@"https://api.gdax.com");
		
		public async Task<GdaxResponse<TResponse>> GetResponse<TResponse>(GdaxRequest request)
		{
			var response = await this.GetResponse(request).ConfigureAwait(false);
			var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			return new GdaxResponse<TResponse>(
				response.Headers.ToArray(),
				response.StatusCode,
				body,
				this.serialzer.Deserialize<TResponse>(body)
			);
		}

		public async Task<HttpResponseMessage> GetResponse(GdaxRequest request)
		{
			var httpRequest = this.BuildRequestMessagee(request);

			var response = await this.http.SendAsync(httpRequest).ConfigureAwait(false);

			if (!response.IsSuccessStatusCode)
			{
				var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				var error = this.serialzer.Deserialize<GdaxErrorMessage>(body);

				throw new GdaxException(error.Message);
			}

			return response;
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
			
			return requestMessage;
		}
	}
}

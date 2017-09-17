using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gdax.Internal;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Gdax.Authentication
{
	public class GdaxAuthenticatorTests
	{
		[Theory]
		[InlineData(5, "Get", "/time", null, @"BnUZcmX41TBXAeHYN0r9czPBsm5oO2a3Y0N+BP1ZLqc=")]
		[InlineData(5, "Post", "/time", "Body", @"nspxt/XZZ1NS6+jgiw/c5A0+vJA1uRuwZqXX8BblapM=")]
		public async Task GetAuthenticationToken_ReturnsCorrectSignature(Int32 timestamp, String method, String request, String body, String signiture)
		{
			// Arrange
			var clock = Substitute.For<ISystemClock>();
			clock.UnixTimestamp.Returns(timestamp);

			var apiKey = "thisisafakekeythisisafakekey1234";
			var apiPassphrase = "thisisafake";
			var apiSecret = "thisisafakesecretthisisafakesecretthisisafakesecretthisisafakesecretthisisafakesecret+==";
			var applicationName = "test-application";

			var credentials = new GdaxCredentials(apiKey, apiPassphrase, apiSecret, applicationName);
			var handler = new GdaxAuthenticationHandler(credentials, clock)
			{
				InnerHandler = new NoopHandler()
			};

			var http = new HttpClient(handler);
			
			// Act
			var response = await http.SendAsync(new HttpRequestMessage
			{
				Method = new HttpMethod(method),
				RequestUri = new Uri("https://test.com" + request),
				Content = body == null ? null : new StringContent(body)
			});

			// Assert
			response.RequestMessage.Headers.GetValues("CB-ACCESS-KEY").Single().ShouldBe(apiKey);
			response.RequestMessage.Headers.GetValues("CB-ACCESS-SIGN").Single().ShouldBe(signiture);
			response.RequestMessage.Headers.GetValues("CB-ACCESS-TIMESTAMP").Single().ShouldBe(timestamp.ToString(CultureInfo.InvariantCulture));
			response.RequestMessage.Headers.GetValues("CB-ACCESS-PASSPHRASE").Single().ShouldBe(apiPassphrase);
			response.RequestMessage.Headers.GetValues("User-Agent").Single().ShouldBe(applicationName);
		}

		private class NoopHandler : HttpMessageHandler
		{
			protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
			{
				return Task.FromResult(new HttpResponseMessage
				{
					RequestMessage = request
				});
			}
		}
	}
}

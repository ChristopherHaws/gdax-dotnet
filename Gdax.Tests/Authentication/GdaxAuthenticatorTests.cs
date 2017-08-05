using System;
using System.Net.Http;
using Xunit;

namespace Gdax.Authentication
{
	public class GdaxAuthenticatorTests
	{
		[Theory]
		[InlineData(5, "Get", "/time", "Body", "Xhb0b22ZdjEPO4pk/sYLWfzuEPz4NTno7dXlo+7fy8Y=")]
		public void GetAuthenticationToken_ReturnsCorrectSignature(Int32 timestamp, String method, String request, String body, String signiture)
		{
			var auth = new GdaxAuthenticator("thisisafakekeythisisafakekey1234", "thisisafake", "thisisafakesecretthisisafakesecretthisisafakesecretthisisafakesecretthisisafakesecret+==");

			var token = auth.GetAuthenticationToken(new GdaxRequest(new HttpMethod(method), request, body)
			{
				Timestamp = timestamp
			});
			
			Assert.Equal(signiture, token.Signature);			
		}
	}
}

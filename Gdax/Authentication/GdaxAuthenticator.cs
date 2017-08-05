using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Gdax.Authentication
{
	public class GdaxAuthenticator : IAuthenticator
	{
		private readonly String apiKey;
		private readonly String passphrase;
		private readonly String secret;

		public GdaxAuthenticator(String apiKey, String passphrase, String secret)
		{
			this.apiKey = Check.NotNull(apiKey, nameof(apiKey));
			this.passphrase = Check.NotNull(passphrase, nameof(passphrase));
			this.secret = Check.NotNull(secret, nameof(secret));
		}

		public AuthenticationToken GetAuthenticationToken(GdaxRequest request)
		{
			var timestamp = (request.Timestamp).ToString(CultureInfo.InvariantCulture);
			var signature = ComputeSignature(request);

			return new AuthenticationToken(this.apiKey, signature, timestamp, this.passphrase);
		}

		private String ComputeSignature(GdaxRequest request)
		{
			var data = Convert.FromBase64String(this.secret);
			var prehash = request.Timestamp + request.HttpMethod.ToString().ToUpper() + request.RequestUrl + request.RequestBody;
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

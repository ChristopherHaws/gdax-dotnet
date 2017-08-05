using System;

namespace Gdax.Authentication
{
	public class AuthenticationToken
	{
		public AuthenticationToken(String apiKey, String signature, String timestamp, String passphrase)
		{
			this.ApiKey = apiKey;
			this.Signature = signature;
			this.Timestamp = timestamp;
			this.Passphrase = passphrase;
		}

		public String ApiKey { get; set; }
		public String Signature { get; set; }
		public String Timestamp { get; set; }
		public String Passphrase { get; set; }
	}
}

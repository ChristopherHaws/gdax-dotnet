using System;

namespace Gdax
{
	public class GdaxCredentials
	{
		public GdaxCredentials(String apiKey, String passphrase, String secret, String applicationName = "gdax-dotnet")
		{
			this.ApiKey = Check.NotNull(apiKey, nameof(apiKey));
			this.Passphrase = Check.NotNull(passphrase, nameof(passphrase));
			this.Secret = Check.NotNull(secret, nameof(secret));
			this.ApplicationName = Check.NotNullOrWhiteSpace(applicationName, nameof(applicationName));
		}

		public String ApiKey { get; set; }
		public String Passphrase { get; set; }
		public String Secret { get; set; }
		public String ApplicationName { get; set; }
	}
}

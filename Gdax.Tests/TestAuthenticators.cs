using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Gdax
{
	public static class TestAuthenticators
	{
		private static IConfiguration Config;

		static TestAuthenticators() => Config = new ConfigurationBuilder()
			.AddEnvironmentVariables()
			.AddUserSecrets(Assembly.GetExecutingAssembly())
			.Build();

		public static GdaxCredentials Unauthorized => new GdaxCredentials(@"", @"", @"");
		public static GdaxCredentials FullAccess => new GdaxCredentials(Config["GdaxCredentials:ApiKey"], Config["GdaxCredentials:Passphrase"], Config["GdaxCredentials:Secret"]);
	}
}

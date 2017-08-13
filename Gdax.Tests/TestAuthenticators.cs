using Gdax.Authentication;

namespace Gdax
{
	public static class TestAuthenticators
	{
		public static IAuthenticator Unauthorized = new GdaxAuthenticator(@"", @"", @"");
		public static IAuthenticator ViewOnly = new GdaxAuthenticator(@"73d9ebe84652d7775341210f583d503b", @"4l1os2thjj4", @"nLsnGFX6kXAA1g+VFSxF+2pslbePTs+6emb85sCqePSsLscGJCQEucOoOGkO2JfmKjiing45mytsinjK+lqA5A==");
		public static IAuthenticator FullAccess = new GdaxAuthenticator(@"21de46f18b4d20b6a6290a9ae905586a", @"4l1os2thjj4", @"d+79D/4qnl6NZ9fcMmqq6EHVqYOCCkCtXVbLMt8IVkozfQsb0BKUZilKLyyHctJ81NT+N58WZ1G/ZJnZeoKrZA==");
	}
}

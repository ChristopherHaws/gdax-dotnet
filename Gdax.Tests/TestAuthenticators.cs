namespace Gdax
{
	public static class TestAuthenticators
	{
		public static GdaxCredentials Unauthorized = new GdaxCredentials(@"", @"", @"");
		public static GdaxCredentials ViewOnly = new GdaxCredentials(@"73d9ebe84652d7775341210f583d503b", @"4l1os2thjj4", @"nLsnGFX6kXAA1g+VFSxF+2pslbePTs+6emb85sCqePSsLscGJCQEucOoOGkO2JfmKjiing45mytsinjK+lqA5A==");
		public static GdaxCredentials FullAccess = new GdaxCredentials(@"21de46f18b4d20b6a6290a9ae905586a", @"4l1os2thjj4", @"d+79D/4qnl6NZ9fcMmqq6EHVqYOCCkCtXVbLMt8IVkozfQsb0BKUZilKLyyHctJ81NT+N58WZ1G/ZJnZeoKrZA==");
	}
}

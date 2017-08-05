using Gdax.Authentication;
namespace Gdax.Tests
{
	public static class TestAuthenticators
	{
		public static IAuthenticator Unauthorized = new GdaxAuthenticator(@"", @"", @"");
		public static IAuthenticator ViewOnly = new GdaxAuthenticator(@"25f0c7347afd7549e5ec5e753143151d", @"4l1os2thjj4", @"JS6NYX86UbeXgSEskNofRtmyKuTjB9uEmJoMSGEoF7bGxKj9q1D96OGxQrMDdotaDmRnzHuYyuNaRXyuLK7P0g==");
		public static IAuthenticator FullAccess = new GdaxAuthenticator(@"b99fc826c12b3cae701d1e82d863f376", @"4l1os2thjj4", @"rWTUbRPBpGL83p7vRIG74rX/SevKT04Z4v+IY8QkLsC9/JmEul4IgzchsWjscqccqv1UYoOblIWvOIEyNuLquA==");
	}
}

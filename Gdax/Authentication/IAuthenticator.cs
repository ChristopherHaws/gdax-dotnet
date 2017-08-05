namespace Gdax.Authentication
{
	public interface IAuthenticator
	{
		AuthenticationToken GetAuthenticationToken(GdaxRequest request);
	}
}

namespace Gdax
{
	public interface IAuthenticator
	{
		AuthenticationToken GetAuthenticationToken(GdaxRequest request);
	}
}

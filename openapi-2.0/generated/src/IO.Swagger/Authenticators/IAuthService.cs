using IO.Swagger.Model;

namespace IO.Swagger.Authenticators
{
    public interface IAuthService
    {
        AuthorizationHeaderValue GetAuthorizationHeaderValue();
    }
}
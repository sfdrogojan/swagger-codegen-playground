namespace IO.Swagger.Authentication
{
    public interface IAuthService
    {
        AuthorizationToken GetAuthorizationToken();
    }
}
using IO.Swagger.Model;

namespace IO.Swagger.Authenticators
{
    public interface ICacheService
    {
        AccessTokenResponse Get(string key);
        void Add(string key, AccessTokenResponse value);
    }
}
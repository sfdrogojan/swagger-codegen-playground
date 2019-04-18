using IO.Swagger.Model;

namespace IO.Swagger.Authenticators
{
    public interface ICacheService
    {
        AccessTokenResponse Get(string key);
        void AddOrUpdate(string key, AccessTokenResponse value);
    }
}
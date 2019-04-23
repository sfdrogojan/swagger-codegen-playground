using IO.Swagger.Model;

namespace IO.Swagger.Authentication
{
    public interface ICacheService
    {
        AccessTokenResponse Get(string key);
        void AddOrUpdate(string key, AccessTokenResponse value);
    }
}
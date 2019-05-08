using Salesforce.MarketingCloud.Model;

namespace Salesforce.MarketingCloud.Authentication
{
    public interface ICacheService
    {
        AccessTokenResponse Get(string key);
        void AddOrUpdate(string key, AccessTokenResponse value);
    }
}
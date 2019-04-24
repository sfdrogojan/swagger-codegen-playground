using System;
using System.Collections.Concurrent;
using IO.Swagger.Model;

namespace IO.Swagger.Authentication
{
    internal class CacheService : ICacheService
    {
        internal static ConcurrentDictionary<string, Tuple<AccessTokenResponse, DateTime>> cache;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly int invalidCacheWindowInSeconds = 5 * 60;

        static CacheService()
        {
            cache = new ConcurrentDictionary<string, Tuple<AccessTokenResponse, DateTime>>();
        }

        public CacheService(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        public AccessTokenResponse Get(string key)
        {
            Tuple<AccessTokenResponse, DateTime> value;
            if (cache.TryGetValue(key, out value))
            {
                if (value.Item2 > dateTimeProvider.Now)
                    return value.Item1;
            }
            return null;
        }

        public void AddOrUpdate(string key, AccessTokenResponse value)
        {

            var expirationTime = dateTimeProvider.Now.AddSeconds(value.ExpiresIn).Subtract(TimeSpan.FromSeconds(invalidCacheWindowInSeconds));
            var valueToAdd = new Tuple<AccessTokenResponse, DateTime>(value, expirationTime);
            cache.AddOrUpdate(key, (cacheKey) => valueToAdd, (cacheKey, existingCacheValue) => valueToAdd);
        }
    }
}
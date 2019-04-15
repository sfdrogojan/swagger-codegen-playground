using System;
using System.Collections.Concurrent;
using IO.Swagger.Model;

namespace IO.Swagger.Authenticators
{
    public class CacheService : ICacheService
    {
        internal static ConcurrentDictionary<string, Tuple<AccessTokenResponse, DateTime>> cache = new ConcurrentDictionary<string, Tuple<AccessTokenResponse, DateTime>>();
        private readonly IDateTimeProvider dateTimeProvider;

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

        public void Add(string key, AccessTokenResponse value)
        {
            if(!cache.ContainsKey(key))
            {
                cache.TryAdd(key, new Tuple<AccessTokenResponse, DateTime>(
                    value, 
                    dateTimeProvider.Now.AddSeconds(value.ExpiresIn).AddMinutes(-5))
                );
            }
        }
    }
}
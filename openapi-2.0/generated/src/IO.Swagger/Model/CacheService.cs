using System.Collections.Concurrent;

namespace IO.Swagger.Model
{
    public class CacheService : ICacheService
    {
        private ConcurrentDictionary<string, string> cacheStore;

        public CacheService()
        {
            this.cacheStore = new ConcurrentDictionary<string, string>();
        }
    }
}
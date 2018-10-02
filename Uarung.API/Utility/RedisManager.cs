using System;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;

namespace Uarung.API.Utility
{
    public class RedisManager
    {
        private readonly IDistributedCache _distributedCache;

        public RedisManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Set(string key, string value, TimeSpan? lifeTime = null)
        {
            var valueBytes = Encoding.Default.GetBytes(value);

            if(lifeTime != null)
                _distributedCache.Set(key, valueBytes, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = lifeTime
                });
            else
                _distributedCache.Set(key, valueBytes);
        }

        public string Get(string key)
        {
            var valueBytes = _distributedCache.Get(key);

            return valueBytes == null 
                ? null 
                : Encoding.Default.GetString(valueBytes);
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }
    }
}
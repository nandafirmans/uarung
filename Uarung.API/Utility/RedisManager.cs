using System;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;

namespace Uarung.API.Utility
{
    public class RedisManager
    {
        private readonly RedisCache _redisCache;

        public RedisManager(IConfiguration configuration)
        {
            var redisConfig = configuration.GetValue<string>("RedisOption");

            if(string.IsNullOrEmpty(redisConfig))
                throw new Exception("fail to get redis option");

            _redisCache = new RedisCache(new RedisCacheOptions()
            {
                Configuration = redisConfig
            });
        }

        public void Set(string key, string value, TimeSpan? lifeTime = null)
        {
            var valueBytes = Encoding.Default.GetBytes(value);

            if(lifeTime != null)
                _redisCache.Set(key, valueBytes, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = lifeTime
                });

            _redisCache.Set(key, valueBytes);
        }

        public string Get(string key)
        {
            try
            {
                return Encoding.Default.GetString(_redisCache.Get(key));
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
using System;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;

namespace Uarung.API.Utility
{
    public static class DistributedCacheExtension
    {
        public static string GetValue(this IDistributedCache cache, string key)
        {
            var valueBytes = cache.Get(key);

            return valueBytes == null
                ? null
                : Encoding.Default.GetString(valueBytes);
        }

        public static void SetValue(this IDistributedCache cache, string key, string value, TimeSpan? lifeTime = null)
        {
            var valueBytes = Encoding.Default.GetBytes(value);

            if (lifeTime != null)
                cache.Set(key, valueBytes, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = lifeTime
                });
            else
                cache.Set(key, valueBytes);
        }
    }
}
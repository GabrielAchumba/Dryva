using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebkitFrameworkCore
{
    public class HttpRuntimeCache : IHttpRuntimeCache
    {
        public HttpRuntimeCache(IMemoryCache cache)
        {
            Cache = cache;
        }

        public T Get<T>(string key)
        {
            string value;
            if (Cache.TryGetValue(key, out value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public void Insert(string key, object value, DateTimeOffset absoluteExpiration, TimeSpan slidingExpiration)
        {
            var options = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(slidingExpiration)
                .SetAbsoluteExpiration(absoluteExpiration);

            Cache.Set(key, value, options);
        }

        public void Insert(string key, object value, TimeSpan absoluteExpiration, TimeSpan slidingExpiration)
        {
            var options = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(slidingExpiration)
                .SetAbsoluteExpiration(absoluteExpiration);

            Cache.Set(key, value, options);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public IMemoryCache Cache { get; }
    }

    public class Cache
    {
        public static DateTimeOffset NoAbsoluteExpiration => DateTimeOffset.MaxValue;
        public static TimeSpan NoSlidingExpiration => TimeSpan.Zero;
    }
}

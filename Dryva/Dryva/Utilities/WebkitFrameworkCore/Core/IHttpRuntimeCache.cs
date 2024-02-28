using Microsoft.Extensions.Caching.Memory;
using System;

namespace WebkitFrameworkCore
{
    public interface IHttpRuntimeCache
    {
        IMemoryCache Cache { get; }

        T Get<T>(string key);
        void Insert(string key, object value, DateTimeOffset absoluteExpiration, TimeSpan slidingExpiration);
        void Insert(string key, object value, TimeSpan absoluteExpiration, TimeSpan slidingExpiration);
        void Remove(string key);
    }
}
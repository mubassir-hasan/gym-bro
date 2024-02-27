using GymBro.Abstractions.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymBro.Infrastructure.Caches
{
    public class CacheService : ICacheService
    {
        private static readonly ConcurrentDictionary<string, bool> CacheKeys = new();
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            string? cachedValue=await _distributedCache.GetStringAsync(key, cancellationToken);
            if (cachedValue is null)
            {
                return null;
            }

            T? value=JsonConvert.DeserializeObject<T>(cachedValue);

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="factory">Consider factory method handle null value</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T?> GetAsync<T>(string key, Func<Task<T>> factory, CancellationToken cancellationToken = default) where T : class
        {
            T? cachedValue=await GetAsync<T>(key, cancellationToken);

            if(cachedValue is not null)
                return cachedValue;

            cachedValue = await factory();

            await SetAsync(key, cachedValue,cancellationToken);

            return cachedValue;
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            await _distributedCache.RemoveAsync(key, cancellationToken);

            CacheKeys.TryRemove(key, out _);
        }

        public async Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default)
        {
            var tasks=CacheKeys
                .Keys
                .Where(k=>k.StartsWith(prefixKey))
                .Select(k=>RemoveAsync(k, cancellationToken));
            await Task.WhenAll(tasks);
        }

        public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
        {
            var cacheValue=JsonConvert.SerializeObject(value);
            await _distributedCache.SetStringAsync(key, cacheValue, cancellationToken);

            CacheKeys.TryAdd(key, true);
        }
    }
}

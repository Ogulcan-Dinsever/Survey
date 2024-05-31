using Microsoft.Extensions.Caching.Distributed;
using Survey.Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Survey.Application.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var cachedValue = await _cache.GetStringAsync(key);
            return cachedValue == null ? default : JsonSerializer.Deserialize<T>(cachedValue);
        }

        public async void ClearCache(string keyPrefix)
        {
            var keys = await _cache.GetStringAsync(keyPrefix);

            _cache.Remove(keys);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan duration)
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(duration);
            var serializedValue = JsonSerializer.Serialize(value);

            var cachedData = Encoding.UTF8.GetBytes(serializedValue);

            await _cache.SetAsync(key, cachedData, options);
        }
    }
}

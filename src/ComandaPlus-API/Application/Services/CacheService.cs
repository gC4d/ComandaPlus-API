using System;
using ComandaPlus_API.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ComandaPlus_API.Application.Services;

public class CacheService(IMemoryCache memoryCache) : ICacheService
{
    private readonly IMemoryCache _memoryCache = memoryCache;
    public async Task<T> GetAsync<T>(string key)
    {
        T? result = await Task.Run(
            () => _memoryCache.TryGetValue(key, out T value) ? value : default(T)
        );
        
        result ??= default(T);

        return result;
    }

    public async Task RemoveAsync(string key)
    {
        await Task.Run(() => _memoryCache.Remove(key));
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        await Task.Run(() => _memoryCache.Set(key, value, expiration));
    }
}

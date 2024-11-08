using Microsoft.Extensions.Caching.Memory;

namespace ComandaPlus_API.Services;

public class VerificationService(
    ICacheEntry cache)
{
    private readonly ICacheEntry _cache = cache;
    
    
}
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CIAC_TAS_Service.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;
        public ResponseCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeLive)
        {
            if (response == null)
            {
                return;
            }

            var serializedResponse = JsonConvert.SerializeObject(response);

            try
            {
                await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = timeLive
                });
            }
            catch (Exception ex)
            {
            }
            
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            try
            {
                var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);

                return String.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
            }
            catch (Exception ex)
            {

                return null;
            }  
        }
    }
}

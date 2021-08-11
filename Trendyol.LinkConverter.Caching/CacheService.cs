using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Text;
using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Caching
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public void Add(string key, ResponseModel entity)
        {
            distributedCache.SetString(key, JsonConvert.SerializeObject(entity), new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60)));
        }

        public ResponseModel Get(string key)
        {
            var result = distributedCache.GetString(key);

            if (String.IsNullOrEmpty(result))
                return null;

            return JsonConvert.DeserializeObject<ResponseModel>(result);
        }
    }
}

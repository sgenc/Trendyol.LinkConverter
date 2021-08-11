using Serilog;
using System.Text.RegularExpressions;
using Trendyol.LinkConverter.Caching;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;
using Trendyol.LinkConverter.Service.Interface;

namespace Trendyol.LinkConverter.Service
{
    public class UrlConverterService : BaseUrlConverterService, IUrlConverterService
    {
        private readonly IUrlConverterStrategyResolver urlConverterStrategyResolver;
        private readonly ICacheService cacheService;
        

        public UrlConverterService(IUrlConverterStrategyResolver urlConverterStrategyResolver, ICacheService cacheService)
        {
            this.urlConverterStrategyResolver = urlConverterStrategyResolver;
            this.cacheService = cacheService;
        }

        public ResponseModel ConvertUrl(RequestModel requestModel)
        {
            var cacheData = cacheService.Get(requestModel.Url);

            if (cacheData != null && !string.IsNullOrEmpty(cacheData.Data))
                return cacheData;

            var urlConverterStrategyType = FindUrlConverterStrategy(requestModel.Url);

            IUrlConverterStrategy urlConverterStrategy = urlConverterStrategyResolver.Resolve(urlConverterStrategyType);

            var responseModel = urlConverterStrategy.ConvertUrl(requestModel);

            if (responseModel != null)
                cacheService.Add(requestModel.Url, responseModel);

            return responseModel;
        }

        public override UrlConverterStrategyType FindUrlConverterStrategy(string url)
        {
            UrlConverterStrategyType? urlConverterStrategyType = null;

            foreach (var item in UrlPatternConstants.PageUrlPatterns)
            {
                var regex = new Regex(item.Value, RegexOptions.IgnoreCase);

                if (regex.Match(url).Success)
                {
                    urlConverterStrategyType = item.Key;
                    break;
                }
            }

            if (!urlConverterStrategyType.HasValue)
            {
                urlConverterStrategyType = url.StartsWith("ty://") ? UrlConverterStrategyType.DefaultDeeplinkConverterStrategy : UrlConverterStrategyType.DefaultUrlConverterStrategy;
            }

            return urlConverterStrategyType.Value;
        }
    }
}

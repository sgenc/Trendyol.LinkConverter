using System;
using System.Text.RegularExpressions;
using System.Web;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Service
{
    public class ProductDetailDeeplinkToUrlConverterStrategy : IUrlConverterStrategy
    {
        public UrlConverterStrategyType StrategyType { get; private set; }

        public ProductDetailDeeplinkToUrlConverterStrategy()
        {
            StrategyType = UrlConverterStrategyType.ProductDetailDeeplinkConverterStrategy;
        }

        public ResponseModel ConvertUrl(RequestModel requestModel)
        {
            var uri = new Uri(requestModel.Url);

            var query = HttpUtility.ParseQueryString(uri.Query);

            var url = UrlConstants.ProductDetailUrl;

            var contentId = query.Get(UrlConstants.ContentId);

            if (!string.IsNullOrEmpty(contentId))
                url = $"{url}{contentId}";

            var campaignId = query.Get(UrlConstants.CampaignId);

            if (!string.IsNullOrEmpty(campaignId))
                url = $"{url}?boutiqueId={campaignId}";

            var merchantId = query.Get(UrlConstants.MerchantId);

            if (!string.IsNullOrEmpty(merchantId))
                url =  url.Contains("boutiqueId") ? $"{url}&merchantId={merchantId}" : $"{url}?merchantId={merchantId}";


            return new ResponseModel() { Data = url };
        }
    }
}

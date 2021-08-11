using System;
using System.Text.RegularExpressions;
using System.Web;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Service
{
    public class ProductDetailUrlToDeeplinkConverterStrategy : IUrlConverterStrategy
    {
        public UrlConverterStrategyType StrategyType { get; private set; }

        public ProductDetailUrlToDeeplinkConverterStrategy()
        {
            StrategyType = UrlConverterStrategyType.ProductDetailUrlConverterStrategy;
        }

        public ResponseModel ConvertUrl(RequestModel requestModel)
        {
            var uri = new Uri(requestModel.Url);
            
            Regex r = new Regex(UrlConstants.ProductDetailUrlContentIdPattern, RegexOptions.IgnoreCase);

            var query = HttpUtility.ParseQueryString(uri.Query);

            var url = String.Format(UrlConstants.ProductDetailDeeplink, r.Match(requestModel.Url).Value);

            var boutiqueId = query.Get(UrlConstants.BoutiqueId);

            if (!string.IsNullOrEmpty(boutiqueId))
                url = $"{url}&CampaignId={boutiqueId}";

            var merchantId = query.Get(UrlConstants.MerchantId);

            if (!string.IsNullOrEmpty(merchantId))
                url = $"{url}&MerchantId={merchantId}";

            return new ResponseModel() { Data = url };
        }
    }
}

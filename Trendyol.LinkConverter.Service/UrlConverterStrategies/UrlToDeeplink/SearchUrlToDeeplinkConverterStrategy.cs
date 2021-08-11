using System;
using System.Text.RegularExpressions;
using System.Web;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Service
{
    public class SearchUrlToDeeplinkConverterStrategy : IUrlConverterStrategy
    {
        public UrlConverterStrategyType StrategyType { get; private set; }

        public SearchUrlToDeeplinkConverterStrategy()
        {
            StrategyType = UrlConverterStrategyType.SearchUrlConverterStrategy;
        }

        public ResponseModel ConvertUrl(RequestModel requestModel)
        {
            Regex r = new Regex(UrlConstants.SearchUrlQueryPattern, RegexOptions.IgnoreCase);

            var url = String.Format(UrlConstants.SearchDeeplink, r.Match(requestModel.Url).Value);

            return new ResponseModel() { Data = url };
        }
    }

}

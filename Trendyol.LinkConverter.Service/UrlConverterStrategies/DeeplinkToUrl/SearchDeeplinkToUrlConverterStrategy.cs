using System;
using System.Text.RegularExpressions;
using System.Web;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Service
{
    public class SearchDeeplinkToUrlConverterStrategy : IUrlConverterStrategy
    {
        public UrlConverterStrategyType StrategyType { get; private set; }

        public SearchDeeplinkToUrlConverterStrategy()
        {
            StrategyType = UrlConverterStrategyType.SearchDeeplinkConverterStrategy;
        }

        public ResponseModel ConvertUrl(RequestModel requestModel)
        {
            Regex r = new Regex(UrlConstants.SearchDeeplinkQueryPattern, RegexOptions.IgnoreCase);

            var url = String.Format(UrlConstants.SearchUrl, r.Match(requestModel.Url).Value);

            return new ResponseModel() { Data = url };
        }
    }

}

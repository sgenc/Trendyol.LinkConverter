using System;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Service
{
    public class DefaultDeeplinkToUrlConverterStrategy : IUrlConverterStrategy
    {
        public UrlConverterStrategyType StrategyType { get; private set; }

        public DefaultDeeplinkToUrlConverterStrategy()
        {
            StrategyType = UrlConverterStrategyType.DefaultDeeplinkConverterStrategy;
        }

        public ResponseModel ConvertUrl(RequestModel requestModel)
        {
            return new ResponseModel() { Data = UrlConstants.DefaultUrl };
        }
    }

}

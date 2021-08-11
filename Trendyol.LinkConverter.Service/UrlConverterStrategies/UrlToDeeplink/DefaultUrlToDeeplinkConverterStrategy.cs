using System;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Service
{
    public class DefaultUrlToDeeplinkConverterStrategy : IUrlConverterStrategy
    {
        public UrlConverterStrategyType StrategyType { get; private set; }

        public DefaultUrlToDeeplinkConverterStrategy()
        {
            StrategyType = UrlConverterStrategyType.DefaultUrlConverterStrategy;
        }

        public ResponseModel ConvertUrl(RequestModel requestModel)
        {
            return new ResponseModel() { Data = UrlConstants.DefaultDeeplinkUrl };
        }
    }

}

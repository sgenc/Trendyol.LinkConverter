using System;
using System.Collections.Generic;
using System.Linq;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Service.Interface;

namespace Trendyol.LinkConverter.Service
{
    public class UrlConverterStrategyResolver : IUrlConverterStrategyResolver
    {
        private readonly IEnumerable<IUrlConverterStrategy> urlConverterStrategy;
        
        public UrlConverterStrategyResolver(IEnumerable<IUrlConverterStrategy> urlConverterStrategy)
        {
            this.urlConverterStrategy = urlConverterStrategy;
        }

        public IUrlConverterStrategy Resolve(UrlConverterStrategyType strategyType)
        {
            IUrlConverterStrategy strategy = urlConverterStrategy.FirstOrDefault(s => s.StrategyType == strategyType);

            if (strategy == null)
            {
                throw new ArgumentException("Strategy not found");
            }

            return strategy;
        }
    }
}

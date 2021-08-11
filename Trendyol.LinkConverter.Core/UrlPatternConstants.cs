using System.Collections.Generic;

namespace Trendyol.LinkConverter.Core
{
    public class UrlPatternConstants
    {
        public static readonly Dictionary<UrlConverterStrategyType, string> PageUrlPatterns = new Dictionary<UrlConverterStrategyType, string>()
        {
            { UrlConverterStrategyType.ProductDetailUrlConverterStrategy, "(https|http):\\/\\/www\\.trendyol\\.com\\/(.*)-p-([0-9]*)" },
            { UrlConverterStrategyType.SearchUrlConverterStrategy, "(https|http):\\/\\/www\\.trendyol\\.com\\/sr\\?q" },
            { UrlConverterStrategyType.SearchDeeplinkConverterStrategy, "ty://\\?Page=Search&Query=([A-Za-z])*" },
            { UrlConverterStrategyType.ProductDetailDeeplinkConverterStrategy, "ty://\\?Page=Product&" }
        };
    }
}

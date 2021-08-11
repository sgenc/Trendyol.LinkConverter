namespace Trendyol.LinkConverter.Core
{
    public class UrlConstants
    {
        public static readonly string ProductDetailDeeplink = "ty://?Page=Product&ContentId={0}";
        public static readonly string ProductDetailUrlContentIdPattern = "(?<=\\-p-)(.*?)(?=[\\?])|[^p-]*$";

        public static readonly string ProductDetailUrl = "https://www.trendyol.com/brand/name-p-";
        public static readonly string ProductDetailDeeplinkContentIdPattern = "(?<=(ContentId=))(.*)(?=&)";

        public static readonly string SearchDeeplink = "ty://?Page=Search&Query={0}";
        public static readonly string SearchUrlQueryPattern = "(?<=\\-p-)(.*?)(?=[\\?])|[^q=]*$";

        public static readonly string SearchUrl = "https://www.trendyol.com/sr?q={0}";
        public static readonly string SearchDeeplinkQueryPattern = "[^=]*$";



        public static readonly string DefaultDeeplinkUrl = "ty://?Page=Home";
        public static readonly string DefaultUrl = "https://www.trendyol.com";

        public static readonly string ContentId = "contentId";
        public static readonly string BoutiqueId = "boutiqueId";
        public static readonly string MerchantId = "merchantId";
        public static readonly string CampaignId = "campaignId";

    }
}

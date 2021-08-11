using Moq;
using NUnit.Framework;
using Trendyol.LinkConverter.Caching;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;
using Trendyol.LinkConverter.Service;
using Trendyol.LinkConverter.Service.Interface;

namespace Trendyol.LinkConverter.Test.Services
{
    [TestFixture]
    public class UrlToDeeplinkConverterServiceTests
    {
        [Test]
        public void When_Url_Converter_Service_Called_With_Product_Detail_Page_Url_Then_Should_Return_Converted_Product_Detail_Deeplink()
        {
            string requestUrl = "https://www.trendyol.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064";
            string expected = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064";

            var urlConverterStrategyResolverMock = new Mock<IUrlConverterStrategyResolver>(MockBehavior.Strict);
            urlConverterStrategyResolverMock.Setup(item => item.Resolve(It.IsAny<UrlConverterStrategyType>())).Returns(new ProductDetailUrlToDeeplinkConverterStrategy());

            var cacheServiceMock = new Mock<ICacheService>(MockBehavior.Strict);
            cacheServiceMock.Setup(item => item.Get(It.IsAny<string>())).Returns(new ResponseModel());
            cacheServiceMock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<ResponseModel>()));

            var urlConverterService = new UrlConverterService(urlConverterStrategyResolverMock.Object, cacheServiceMock.Object);
            var result = urlConverterService.ConvertUrl(new RequestModel() { Url = requestUrl });

            urlConverterStrategyResolverMock.Verify();
            cacheServiceMock.Verify();

            Assert.AreEqual(expected, result.Data);
        }

        [Test]
        public void When_Url_Converter_Service_Called_With_Search_Page_Url_Then_Should_Return_Converted_Search_Deeplink()
        {
            string requestUrl = "https://www.trendyol.com/sr?q=elbise";
            string expected = "ty://?Page=Search&Query=elbise";

            var urlConverterStrategyResolverMock = new Mock<IUrlConverterStrategyResolver>(MockBehavior.Strict);
            urlConverterStrategyResolverMock.Setup(item => item.Resolve(It.IsAny<UrlConverterStrategyType>())).Returns(new SearchUrlToDeeplinkConverterStrategy());

            var cacheServiceMock = new Mock<ICacheService>(MockBehavior.Strict);
            cacheServiceMock.Setup(item => item.Get(It.IsAny<string>())).Returns(new ResponseModel());
            cacheServiceMock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<ResponseModel>()));

            var urlConverterService = new UrlConverterService(urlConverterStrategyResolverMock.Object, cacheServiceMock.Object);
            var result = urlConverterService.ConvertUrl(new RequestModel() { Url = requestUrl });

            urlConverterStrategyResolverMock.Verify();
            cacheServiceMock.Verify();

            Assert.AreEqual(expected, result.Data);
        }

        [Test]
        public void When_Url_Converter_Service_Called_With_Default_Page_Url_Then_Should_Return_Converted_Default_Deeplink()
        {
            string requestUrl = "https://www.trendyol.com/Hesabim/#/Siparislerim";
            string expected = "ty://?Page=Home";

            var urlConverterStrategyResolverMock = new Mock<IUrlConverterStrategyResolver>(MockBehavior.Strict);
            urlConverterStrategyResolverMock.Setup(item => item.Resolve(It.IsAny<UrlConverterStrategyType>())).Returns(new DefaultUrlToDeeplinkConverterStrategy());

            var cacheServiceMock = new Mock<ICacheService>(MockBehavior.Strict);
            cacheServiceMock.Setup(item => item.Get(It.IsAny<string>())).Returns(new ResponseModel());
            cacheServiceMock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<ResponseModel>()));

            var urlConverterService = new UrlConverterService(urlConverterStrategyResolverMock.Object, cacheServiceMock.Object);
            var result = urlConverterService.ConvertUrl(new RequestModel() { Url = requestUrl });

            urlConverterStrategyResolverMock.Verify();
            cacheServiceMock.Verify();

            Assert.AreEqual(expected, result.Data);
        }
    }
}



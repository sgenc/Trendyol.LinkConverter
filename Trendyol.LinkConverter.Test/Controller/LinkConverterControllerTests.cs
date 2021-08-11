using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.LinkConverter.Api.Controllers;
using Trendyol.LinkConverter.Caching;
using Trendyol.LinkConverter.Core;
using Trendyol.LinkConverter.Core.ApiModels;
using Trendyol.LinkConverter.Service;
using Trendyol.LinkConverter.Service.Interface;

namespace Trendyol.LinkConverter.Test.Controller
{
    [TestFixture]
    public class LinkConverterControllerTests
    {

        [Test]
        public void When_Url_To_Deeplink_Endpoint_Called_With_Product_Detail_Deeplink_Then_Should_Return_Converted_Product_Detail_Page_Url()
        {
            var requestModel = new RequestModel() { Url = "https://www.trendyol.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064" };
            var expected = new ResponseModel() { Data = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064" };

            var urlConverterStrategyResolverMock = new Mock<IUrlConverterStrategyResolver>(MockBehavior.Strict);
            urlConverterStrategyResolverMock.Setup(item => item.Resolve(It.IsAny<UrlConverterStrategyType>())).Returns(new ProductDetailUrlToDeeplinkConverterStrategy());

            var cacheServiceMock = new Mock<ICacheService>(MockBehavior.Strict);
            cacheServiceMock.Setup(item => item.Get(It.IsAny<string>()));
            cacheServiceMock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<ResponseModel>()));

            var urlConverterServiceMock = new Mock<IUrlConverterService>(MockBehavior.Strict);
            urlConverterServiceMock.Setup(item => item.ConvertUrl(requestModel)).Returns(expected);

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(item => item.Information(It.IsAny<string>()));

            var linkConverterController = new LinkConverterController(urlConverterServiceMock.Object, loggerMock.Object);
            var result = linkConverterController.UrlToDeepLink(requestModel);

            urlConverterServiceMock.Verify();
            urlConverterStrategyResolverMock.Verify();
            cacheServiceMock.Verify();
            loggerMock.Verify();
        }

        [Test]
        public void When_Deeplink_To_Url_Endpoint_Called_With_Product_Detail_Deeplink_Then_Should_Return_Converted_Product_Detail_Page_Url()
        {
            var requestModel = new RequestModel() { Url = "ty://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064" };
            var expected = new ResponseModel() { Data = "https://www.trendyol.com/brand/name-p-1925865?boutiqueId=439892&merchantId=105064" };

            var urlConverterStrategyResolverMock = new Mock<IUrlConverterStrategyResolver>(MockBehavior.Strict);
            urlConverterStrategyResolverMock.Setup(item => item.Resolve(It.IsAny<UrlConverterStrategyType>())).Returns(new ProductDetailDeeplinkToUrlConverterStrategy());

            var cacheServiceMock = new Mock<ICacheService>(MockBehavior.Strict);
            cacheServiceMock.Setup(item => item.Get(It.IsAny<string>())).Returns(new ResponseModel());
            cacheServiceMock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<ResponseModel>()));

            var urlConverterServiceMock = new Mock<IUrlConverterService>(MockBehavior.Strict);
            urlConverterServiceMock.Setup(item => item.ConvertUrl(requestModel)).Returns(expected);

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(item => item.Information(It.IsAny<string>()));

            var linkConverterController = new LinkConverterController(urlConverterServiceMock.Object, loggerMock.Object);
            var result = linkConverterController.UrlToDeepLink(requestModel);

            urlConverterServiceMock.Verify();
            urlConverterStrategyResolverMock.Verify();
            cacheServiceMock.Verify();
            loggerMock.Verify();
        }
    }
}

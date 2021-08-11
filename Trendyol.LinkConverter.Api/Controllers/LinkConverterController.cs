using Microsoft.AspNetCore.Mvc;
using Serilog;
using Trendyol.LinkConverter.Core.ApiModels;
using Trendyol.LinkConverter.Service;

namespace Trendyol.LinkConverter.Api.Controllers
{
    [ApiController]
    [Route("api/linkconverter")]
    public class LinkConverterController : ControllerBase
    {
        private readonly IUrlConverterService urlConverterService;
        private readonly ILogger logger;

        public LinkConverterController(IUrlConverterService urlConverterService, ILogger logger)
        {
            this.urlConverterService = urlConverterService;
            this.logger = logger;
        }

        [HttpPost("url-to-deeplink")]
        public JsonResult UrlToDeepLink([FromBody] RequestModel requestModel)
        {
            var result = urlConverterService.ConvertUrl(requestModel);

            logger.Information("url-to-deeplink api called => Request url: {RequestUrl} - Response url: {ResponseUrl}", requestModel.Url, result.Data);

            return new JsonResult(result);
        }

        [HttpPost("deeplink-to-url")]
        public JsonResult DeepLinkToUrl([FromBody] RequestModel requestModel)
        {
            var result = urlConverterService.ConvertUrl(requestModel);

            logger.Information("deeplink-to-url api called => Request url: {RequestUrl} - Response url: {ResponseUrl}", requestModel.Url, result.Data);

            return new JsonResult(result);
        }
    }
}
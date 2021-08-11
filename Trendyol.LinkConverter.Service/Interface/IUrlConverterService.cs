using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Service
{
    public interface IUrlConverterService
    {
        ResponseModel ConvertUrl(RequestModel requestModel);
    }
}

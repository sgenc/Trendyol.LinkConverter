using Trendyol.LinkConverter.Core.ApiModels;

namespace Trendyol.LinkConverter.Caching
{
    public interface ICacheService
    {
        ResponseModel Get(string key);

        void Add(string key, ResponseModel entity);
    }
}

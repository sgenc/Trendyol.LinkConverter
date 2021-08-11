using Newtonsoft.Json;

namespace Trendyol.LinkConverter.Core.ApiModels
{
    public class ResponseModel
    {
        [JsonProperty(PropertyName = "d")]
        public string Data { get; set; }
    }
}

using Newtonsoft.Json;

namespace Trendyol.LinkConverter.Core.ApiModels
{
    public class RequestModel
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}

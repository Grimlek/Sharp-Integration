using Newtonsoft.Json;
using System.Collections.Generic;


namespace MultiChannelIntegration.Domain
{
    class Returns
    {
        [JsonProperty(PropertyName = "return_urls")]
        public List<string> ReturnUrls { get; set; }
    }
}

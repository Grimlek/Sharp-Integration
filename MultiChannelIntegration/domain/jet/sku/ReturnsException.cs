using Newtonsoft.Json;
using System.Collections.Generic;


namespace Jet
{
    class ReturnsException
    {
        [JsonProperty(PropertyName = "time_to_return")]
        public int TimeToReturn { get; set; }

        [JsonProperty(PropertyName = "return_location_ids")]
        public List<string> ReturnLocationIds { get; set; }

        [JsonProperty(PropertyName = "return_shipping_methods")]
        public List<string> ReturnShippingMethods { get; set; }
    }
}

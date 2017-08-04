using Newtonsoft.Json;
using System.Collections.Generic;


namespace Jet
{
    class FulfillmentNodes
    {
        [JsonProperty(PropertyName = "fulfillment_nodes")]
        public List<FulfillmentNode> Nodes { get; set; }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;


namespace Jet
{
    class Inventory
    {
        [JsonProperty(PropertyName = "fulfillment_nodes")]
        public List<FulfillmentNode> FulfillmentNodes { get; set; }

        public Inventory(List<FulfillmentNode> fulfillmentNodes)
        {
            this.FulfillmentNodes = fulfillmentNodes;
        }
    }
}

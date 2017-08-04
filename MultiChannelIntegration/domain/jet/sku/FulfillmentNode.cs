using Newtonsoft.Json;
using System.Collections.Generic;


namespace Jet
{
    class FulfillmentNode
    {
        [JsonProperty(PropertyName = "fulfillment_node_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "shipping_exceptions")]
        public List<ShippingException> ShippingExceptions { get; set; }

 
        public FulfillmentNode(string id, int quantity)
        {
            this.Id = id;
            this.Quantity = quantity;
        }


        public FulfillmentNode(string id, List<ShippingException> shippingExceptions)
        {
            this.Id = id;
            this.ShippingExceptions = shippingExceptions;
        }
    }
}
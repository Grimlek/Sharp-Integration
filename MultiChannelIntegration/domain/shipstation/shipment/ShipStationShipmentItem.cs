using Newtonsoft.Json;


namespace ShipStation
{
    class ShipStationShipmentItem
    {
        [JsonProperty(PropertyName = "orderItemId")]
        public string OrderItemId { get; set; }


        [JsonProperty(PropertyName = "lineItemKey")]
        public string LineItemKey { get; set; }


        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "unitPrice")]
        public decimal UnitPrice { get; set; }
    }
}

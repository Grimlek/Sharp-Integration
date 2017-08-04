using Newtonsoft.Json;


namespace ShipStation
{
    class OrderItem
    {
        [JsonProperty(PropertyName = "orderItemId")]
        public int OrderItemId { get; set; }


        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }


        [JsonProperty(PropertyName = "unitPrice")]
        public decimal UnitPrice { get; set; }


        [JsonProperty(PropertyName = "upc")]
        public string Upc { get; set; }
    }
}

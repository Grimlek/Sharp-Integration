using Newtonsoft.Json;


namespace Jet
{
    class OrderDetail
    {
        [JsonProperty(PropertyName = "request_shipping_carrier")]
        public string RequestedShippingCarrier { get; set; }

        [JsonProperty(PropertyName = "request_shipping_method")]
        public string RequestedShippingMethod { get; set; }

        [JsonProperty(PropertyName = "request_service_level")]
        public string RequestedServiceLevel { get; set; }

        [JsonProperty(PropertyName = "request_ship_by")]
        public string RequestedShipBy { get; set; }

        [JsonProperty(PropertyName = "request_delivery_by")]
        public string RequestedDeliveryDate { get; set; }
    }
}

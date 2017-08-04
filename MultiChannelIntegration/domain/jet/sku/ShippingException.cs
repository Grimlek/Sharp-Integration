using Newtonsoft.Json;


namespace Jet
{
    class ShippingException
    {
        [JsonProperty(PropertyName = "shipping_exception_type")]
        public string ShippingExceptionType { get; set; }

        [JsonProperty(PropertyName = "service_level")]
        public string ServiceLevel { get; set; }

        [JsonProperty(PropertyName = "shipping_method")]
        public string ShippingMethod { get; set; }
    }
}

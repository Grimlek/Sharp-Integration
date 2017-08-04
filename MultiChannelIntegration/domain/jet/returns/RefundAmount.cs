using Newtonsoft.Json;


namespace Jet
{
    class RefundAmount
    {
        [JsonProperty(PropertyName = "shipping_cost")]
        public decimal ShippingCost { get; set; }

        [JsonProperty(PropertyName = "shipping_tax")]
        public decimal ShippingTax { get; set; }

        [JsonProperty(PropertyName = "principal")]
        public decimal Principal { get; set; }

        [JsonProperty(PropertyName = "tax")]
        public decimal Tax { get; set; }
    }
}

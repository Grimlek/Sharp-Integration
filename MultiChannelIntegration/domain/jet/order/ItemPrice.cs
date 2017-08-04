using Newtonsoft.Json;


namespace Jet
{
    class ItemPrice
    {
        [JsonProperty(PropertyName = "base_price")]
        public decimal BasePrice { get; set; }

        [JsonProperty(PropertyName = "item_tax")]
        public decimal ItemTax { get; set; }

        [JsonProperty(PropertyName = "item_shipping_tax")]
        public decimal ItemShippingTax { get; set; }

        [JsonProperty(PropertyName = "item_shipping_cost")]
        public decimal ItemShippingCost { get; set; }
    }
}

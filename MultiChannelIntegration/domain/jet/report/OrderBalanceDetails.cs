using Newtonsoft.Json;


namespace Jet
{
    class OrderBalanceDetails
    {
        [JsonProperty(PropertyName = "merchant_price")]
        public decimal MerchantPrice { get; set; }

        [JsonProperty(PropertyName = "jet_variable_commission")]
        public decimal JetVariableCommission { get; set; }

        [JsonProperty(PropertyName = "fixed_commission")]
        public decimal FixedCommission { get; set; }

        [JsonProperty(PropertyName = "tax")]
        public decimal Tax { get; set; }

        [JsonProperty(PropertyName = "shipping_revenue")]
        public decimal ShippingRevenue { get; set; }

        [JsonProperty(PropertyName = "shipping_tax")]
        public decimal ShippingTax { get; set; }

        [JsonProperty(PropertyName = "shipping_charge")]
        public decimal ShippingCharge { get; set; }

        [JsonProperty(PropertyName = "fulfillment_fee")]
        public decimal FulfillmentFee { get; set; }

        [JsonProperty(PropertyName = "product_cost")]
        public decimal ProductCost { get; set; }
    }
}

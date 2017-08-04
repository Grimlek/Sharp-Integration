using Newtonsoft.Json;


namespace Jet
{
    class ReturnBalanceDetails
    {
        [JsonProperty(PropertyName = "merchant_price")]
        public decimal MerchantPrice { get; set; }

        [JsonProperty(PropertyName = "jet_variable_commission")]
        public decimal JetVariableCommission { get; set; }

        [JsonProperty(PropertyName = "fixed_commission")]
        public decimal FixedCommission { get; set; }

        [JsonProperty(PropertyName = "tax")]
        public decimal Tax { get; set; }

        [JsonProperty(PropertyName = "shipping_tax")]
        public decimal ShippingTax { get; set; }

        [JsonProperty(PropertyName = "merchant_return_charge")]
        public double MerchantReturnCharge { get; set; }

        [JsonProperty(PropertyName = "return_processing_fee")]
        public decimal ReturnProcessingFee { get; set; }

        [JsonProperty(PropertyName = "product_cost")]
        public double ProductCost { get; set; }
    }
}

using Newtonsoft.Json;


namespace Jet
{
    class ReturnMerchantSku
    {
        [JsonProperty(PropertyName = "order_item_id")]
        public string OrderItemId { get; set; }

        [JsonProperty(PropertyName = "alt_order_item_id")]
        public string AltOrderItemId { get; set; }

        [JsonProperty(PropertyName = "merchant_sku")]
        public string MerchantSku { get; set; }

        [JsonProperty(PropertyName = "merchant_sku_title")]
        public string MerchantSkuTitle { get; set; }

        [JsonProperty(PropertyName = "return_quantity")]
        public int ReturnQuantity { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "requested_refund_amount")]
        public RefundAmount RequestedRefundAmount { get; set; }
    }
}

using Newtonsoft.Json;


namespace Jet
{
    class OrderItem
    {
        [JsonProperty(PropertyName = "order_item_id")]
        public string OrderItemId { get; set; }

        [JsonProperty(PropertyName = "merchant_sku")]
        public string MerchantSku { get; set; }

        [JsonProperty(PropertyName = "request_order_quantity")]
        public int RequestedOrderQuantity { get; set; }

        [JsonProperty(PropertyName = "item_price")]
        public ItemPrice ItemPrice { get; set; }

        [JsonProperty(PropertyName = "item_fees")]
        public string ItemFees { get; set; }

        [JsonProperty(PropertyName = "product_title")]
        public string ProductTitle { get; set; }

        [JsonIgnore]
        public string Upc { get; set; }
    }
}

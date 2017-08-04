using Newtonsoft.Json;


namespace Jet
{
    class Item
    {
        [JsonProperty(PropertyName = "order_item_id")]
        public string OrderItemId { get; set; }

        [JsonProperty(PropertyName = "alt_order_item_id")]
        public string AltOrderItemId { get; set; }

        [JsonProperty(PropertyName = "total_quantity_returned")]
        public int TotalQtyReturned { get; set; }

        [JsonProperty(PropertyName = "order_return_refund_qty")]
        public int OrderReturnRefundQty { get; set; }

        [JsonProperty(PropertyName = "return_refund_feedback")]
        public string ReturnRefundFeedback { get; set; }

        [JsonProperty(PropertyName = "refund_amount")]
        public RefundAmount RefundAmount { get; set; }
    }
}

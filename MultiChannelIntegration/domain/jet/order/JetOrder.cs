using System;
using System.Collections.Generic;
using MultiChannelIntegration.Domain;
using Newtonsoft.Json;


namespace Jet
{
    class JetOrder
    {
        [JsonProperty(PropertyName = "merchant_order_id")]
        public string MerchantOrderId { get; set; }


        [JsonProperty(PropertyName = "reference_order_id")]
        public string ReferenceOrderId { get; set; }


        [JsonProperty(PropertyName = "fulfillment_node")]
        public string FulfillmentNode { get; set; }


        [JsonProperty(PropertyName = "order_ready_date")]
        public DateTime OrderReadyDate { get; set; }


        [JsonProperty(PropertyName = "order_acknowledge_date")]
        public string OrderAcknowledgedDate { get; set; }


        [JsonProperty(PropertyName = "hash_email")]
        public string HashEmail { get; set; }


        [JsonProperty(PropertyName = "status")]
        public OrderStatus Status { get; set; }


        [JsonProperty(PropertyName = "shipping_to")]
        public ShippingRecipient ShippingTo { get; set; }


        [JsonProperty(PropertyName = "order_detail")]
        public OrderDetail OrderDetail { get; set; }


        [JsonProperty(PropertyName = "order_items")]
        public List<OrderItem> OrderItems { get; set; }


        [JsonProperty(PropertyName = "buyer")]
        public Buyer Buyer { get; set; }
    }
}

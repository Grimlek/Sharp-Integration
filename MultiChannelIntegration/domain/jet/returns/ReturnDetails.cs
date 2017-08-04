using Newtonsoft.Json;
using System.Collections.Generic;


namespace Jet
{
    class ReturnDetails
    {
        [JsonProperty(PropertyName = "merchant_return_authorization_id")]
        public string MerchantReturnAuthorizationId { get; set; }

        [JsonProperty(PropertyName = "reference_return_authorization_id")]
        public string ReferenceReturnAuthorizationId { get; set; }

        [JsonProperty(PropertyName = "return_status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "refund_without_return")]
        public bool RefundWithoutReturn { get; set; }

        [JsonProperty(PropertyName = "merchant_order_id")]
        public string MerchantOrderId { get; set; }

        [JsonProperty(PropertyName = "reference_order_id")]
        public string ReferenceOrderId { get; set; }

        [JsonProperty(PropertyName = "alt_order_id")]
        public string AltOrderId { get; set; }

        [JsonProperty(PropertyName = "return_date")]
        public string ReturnDate { get; set; }

        [JsonProperty(PropertyName = "shipping_carrier")]
        public string ShippingCarrier { get; set; }

        [JsonProperty(PropertyName = "tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty(PropertyName = "merchant_return_charge")]
        public decimal MerchantReturnCharge { get; set; }

        [JsonProperty(PropertyName = "agree_to_return_charge")]
        public bool AgreeToReturnCharge { get; set; }

        [JsonProperty(PropertyName = "return_merchant_skus")]
        public List<ReturnMerchantSku> ReturnMerchantSkus { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<Item> Items { get; set; }
    }
}
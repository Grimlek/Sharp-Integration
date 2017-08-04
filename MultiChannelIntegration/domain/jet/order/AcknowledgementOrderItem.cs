using Newtonsoft.Json;


namespace Jet
{
    class AcknowledgementOrderItem
    {
        [JsonProperty(PropertyName = "order_item_acknowledgement_status")]
        public string AcknowledgementStatus { get; set; }


        [JsonProperty(PropertyName = "order_item_id")]
        public string OrderItemId { get; set; }
    }
}

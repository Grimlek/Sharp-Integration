using Newtonsoft.Json;


namespace Jet
{
    class JetShipmentItem
    {
        [JsonProperty(PropertyName = "alt_shipment_item_id")]
        public string ShipmentItemId { get; set; }

        [JsonProperty(PropertyName = "merchant_sku")]
        public string Sku { get; set; }

        [JsonProperty(PropertyName = "response_shipment_sku_quantity")]
        public int ShipmentSkuQuantity { get; set; }
    }
}

using System;
using Newtonsoft.Json;


namespace Jet
{
    class CancelShipmentItem
    {
        [JsonProperty(PropertyName = "shipment_item_id")]
        public String ShipmentItemId { get; set; }

        [JsonProperty(PropertyName = "merchant_sku")]
        public String Sku { get; set; }

        [JsonProperty(PropertyName = "response_shipment_cancel_qty")]
        public int CancelQty { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Jet
{
    class CancelShipment
    {
        [JsonProperty(PropertyName = "alt_shipment_id")]
        public String ShipmentId { get; set; }

        [JsonProperty(PropertyName = "shipment_items")]
        public List<CancelShipmentItem> ShipmentItems { get; set; }
    }
}

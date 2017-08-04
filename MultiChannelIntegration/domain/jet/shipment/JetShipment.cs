using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using MultiChannelIntegration.Domain;


namespace Jet
{
    class JetShipment
    {
        [JsonProperty(PropertyName = "shipment_tracking_number")]
        public string ShipmentTrackingNumber { get; set; }

        [JsonProperty(PropertyName = "response_shipment_method")]
        public string ResponseShipmentMethod { get; set; }

        [JsonProperty(PropertyName = "response_shipment_date")]
        public DateTime responseShipmentDate { get; set; }

        [JsonProperty(PropertyName = "shipment_items")]
        public List<JetShipmentItem> ShipmentItems { get; set; }

        [JsonProperty(PropertyName = "carrier")]
        public Carrier Carrier { get; set; }
    }
}

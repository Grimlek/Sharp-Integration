using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Jet
{
    class CancelShipments
    {
        [JsonProperty(PropertyName = "alt_order_id")]
        public String OrderId { get; set; }

        [JsonProperty(PropertyName = "shipments")]
        public List<CancelShipment> Shipments { get; set; }
    }
}

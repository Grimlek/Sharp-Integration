using Newtonsoft.Json;
using System.Collections.Generic;


namespace Jet
{
    class JetShipments
    {
        [JsonProperty(PropertyName = "shipments")]
        public List<JetShipment> Shipments { get; set; }
    }
}

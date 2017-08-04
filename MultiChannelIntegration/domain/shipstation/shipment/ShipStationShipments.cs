using System.Collections.Generic;
using Newtonsoft.Json;


namespace ShipStation
{
    class ShipStationShipments
    {
        [JsonProperty(PropertyName = "shipStationShipmentList")]
        public List<ShipStationShipment> ShipStationShipmentList;


        [JsonProperty(PropertyName = "Total")]
        public int Total;


        [JsonProperty(PropertyName = "Pages")]
        public int Pages;


        [JsonProperty(PropertyName = "page")]
        public int Page;
    }
}

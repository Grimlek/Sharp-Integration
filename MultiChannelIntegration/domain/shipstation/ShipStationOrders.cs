using ShipStation;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace ShipStation
{
    class ShipStationOrders
    {
        [JsonProperty(PropertyName = "orders")]
        public List<ShipStationOrder> Orders { get; set; }


        [JsonProperty(PropertyName = "page")]
        public uint Page { get; set; }


        [JsonProperty(PropertyName = "pages")]
        public uint Pages { get; set; }


        [JsonProperty(PropertyName = "total")]
        public uint Total { get; set; }
    }
}

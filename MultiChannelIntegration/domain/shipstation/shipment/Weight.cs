using Newtonsoft.Json;


namespace ShipStation
{
    class Weight
    {
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }


        [JsonProperty(PropertyName = "units")]
        public string Units { get; set; }
    }
}

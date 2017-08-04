using Newtonsoft.Json;


namespace ShipStation
{
    class Dimensions
    {
        [JsonProperty(PropertyName = "units")]
        public string Units;


        [JsonProperty(PropertyName = "length")]
        public int Length;


        [JsonProperty(PropertyName = "width")]
        public int Width;


        [JsonProperty(PropertyName = "height")]
        public int Height;
    }
}

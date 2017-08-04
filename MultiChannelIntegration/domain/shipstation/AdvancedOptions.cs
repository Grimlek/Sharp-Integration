using Newtonsoft.Json;


namespace ShipStation
{
    class AdvancedOptions
    {
        [JsonProperty(PropertyName = "storeId")]
        public int StoreId { get; set; }
    }
}

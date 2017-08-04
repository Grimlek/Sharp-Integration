using Newtonsoft.Json;


namespace Jet
{
    class SkuAttribute
    {
        [JsonProperty(PropertyName = "attribute_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "attribute_value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "attribute_value_unit")]
        public string ValueUnit { get; set; }
    }
}

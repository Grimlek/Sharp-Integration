using Newtonsoft.Json;


namespace Jet
{
    class Buyer
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }
    }
}

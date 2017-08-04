using Newtonsoft.Json;


namespace Jet
{
    class Recipient
    {
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}

using Newtonsoft.Json;


namespace Jet { 
    class Address
    {
        [JsonProperty(PropertyName = "address1")]
        public string AddressOne { get; set; }

        [JsonProperty(PropertyName = "address2")]
        public string AddressTwo { get; set; }

        [JsonProperty(PropertyName = "zip_code")]
        public string Zipcode { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}

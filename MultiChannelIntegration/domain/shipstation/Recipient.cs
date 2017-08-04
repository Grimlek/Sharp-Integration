using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShipStation;


namespace ShipStation
{
    class Recipient
    {
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }


        [JsonProperty(PropertyName = "company", NullValueHandling = NullValueHandling.Ignore)]
        public string Company { get; set; }


        [JsonProperty(PropertyName = "street1", NullValueHandling = NullValueHandling.Ignore)]
        public string Street1 { get; set; }


        [JsonProperty(PropertyName = "street2", NullValueHandling = NullValueHandling.Ignore)]
        public string Street2 { get; set; }


        [JsonProperty(PropertyName = "city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }


        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }


        [JsonProperty(PropertyName = "postalcode", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }


        [JsonProperty(PropertyName = "country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }


        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }


        [JsonProperty(PropertyName = "residential", NullValueHandling = NullValueHandling.Ignore)]
        public string Residential { get; set; }
    }
}

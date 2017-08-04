using Newtonsoft.Json;


namespace Jet
{
    class ShippingRecipient
    {
        [JsonProperty(PropertyName = "recipient")]
        public Recipient Recipient { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }
    }
}

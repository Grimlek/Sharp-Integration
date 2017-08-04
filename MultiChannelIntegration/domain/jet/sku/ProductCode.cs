using Newtonsoft.Json;


namespace Jet
{
    class ProductCode
    {
        [JsonProperty(PropertyName = "standard_product_code")]
        public string StandardProductCode { get; set; }

        [JsonProperty(PropertyName = "standard_product_code_type")]
        public string StandardProductCodeType { get; set; }
    }
}

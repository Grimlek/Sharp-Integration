using Newtonsoft.Json;
using System.Collections.Generic;


namespace Jet
{
    class Sku
    {
        [JsonIgnore]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty(PropertyName = "product_description")]
        public string ProductDescription { get; set; }

        [JsonProperty(PropertyName = "jet_browse_node_id")]
        public int JetBrowserNodeId { get; set; }

        [JsonProperty(PropertyName = "multipack_quantity")]
        public int MultipackQuantity { get; set; }

        [JsonProperty(PropertyName = "mfr_part_number")]
        public string ManufacturerPartNum { get; set; }

        [JsonProperty(PropertyName = "shipping_weight_pounds")]
        public decimal ShippingWeightPounds { get; set; }

        [JsonProperty(PropertyName = "map_implementation")]
        public string MapImplementation { get; set; }

        [JsonProperty(PropertyName = "product_tax_code")]
        public string ProductTaxCode { get; set; }

        [JsonProperty(PropertyName = "main_image_url")]
        public string MainImageUrl { get; set; }

        [JsonProperty(PropertyName = "standard_product_codes")]
        public List<ProductCode> ProductCodes { get; set; }

        [JsonProperty(PropertyName = "attributes_node_specific")]
        public List<SkuAttribute> Attributes { get; set; }

        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }

        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty(PropertyName = "msrp")]
        public double Msrp { get; set; }
        
        public string GetUpc()
        {
            foreach (ProductCode Code in ProductCodes)
            {
                if (Code.StandardProductCodeType.Equals("UPC"))
                {
                    return Code.StandardProductCodeType;
                }
            }
            return null;
        }
    }
}
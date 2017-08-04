using System.Collections.Generic;
using Newtonsoft.Json;
using System;


namespace ShipStation
{
    class ShipStationShipment
    {
        [JsonProperty(PropertyName = "shipmentId")]
        public string ShipmentId { get; set; }


        [JsonProperty(PropertyName = "orderId")]
        public string OrderId { get; set; }


        [JsonProperty(PropertyName = "orderNumber")]
        public string OrderNumber { get; set; }


        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }


        [JsonProperty(PropertyName = "createDate")]
        public DateTime CreateDate { get; set; }


        [JsonProperty(PropertyName = "shipDate")]
        public DateTime ShipDate { get; set; }


        [JsonProperty(PropertyName = "shipmentCost")]
        public decimal ShipmentCost { get; set; }


        [JsonProperty(PropertyName = "insuranceCost")]
        public string InsuranceCost { get; set; }


        [JsonProperty(PropertyName = "trackingNumber")]
        public string TrackingNumber { get; set; }


        [JsonProperty(PropertyName = "batchNumber")]
        public string BatchNumber { get; set; }


        [JsonProperty(PropertyName = "isReturnLabel")]
        public bool IsReturnLabel { get; set; }


        [JsonProperty(PropertyName = "carrierCode")]
        public string CarrierCode { get; set; }


        [JsonProperty(PropertyName = "serviceCode")]
        public string ServiceCode { get; set; }


        [JsonProperty(PropertyName = "packageCode")]
        public string PackageCode { get; set; }


        [JsonProperty(PropertyName = "confirmation")]
        public string Confirmation { get; set; }


        [JsonProperty(PropertyName = "voided")]
        public string Voided { get; set; }


        [JsonProperty(PropertyName = "voidDate")]
        public DateTime VoidDate { get; set; }


        [JsonProperty(PropertyName = "marketplaceNotified")]
        public string MarketplaceNotified { get; set; }


        [JsonProperty(PropertyName = "shipTo")]
        public Recipient ShipTo { get; set; }


        [JsonProperty(PropertyName = "weight")]
        public Weight Weight { get; set; }


        [JsonProperty(PropertyName = "dimensions")]
        public Dimensions Dimensions { get; set; }


        [JsonProperty(PropertyName = "shipStationShipmentItems")]
        public List<ShipStationShipmentItem> ShipStationShipmentItems { get; set; }
    }
}

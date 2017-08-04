using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MultiChannelIntegration.Domain;


namespace ShipStation
{
    class ShipStationOrder
    {
        [JsonProperty(PropertyName = "orderNumber")]
        public string OrderNumber { get; set; }


        [JsonProperty(PropertyName = "orderKey")]
        public string OrderKey { get; set; }


        [JsonProperty(PropertyName = "orderDate")]
        public DateTime OrderDate { get; set; }


        [JsonProperty(PropertyName = "orderStatus")]
        public OrderStatus OrderStatus { get; set; }


        [JsonProperty(PropertyName = "billTo")]
        public Recipient BillTo { get; set; }


        [JsonProperty(PropertyName = "shipTo")]
        public Recipient ShipTo { get; set; }


        [JsonProperty(PropertyName = "amountPaid")]
        public decimal AmountPaid { get; set; }


        [JsonProperty(PropertyName = "taxAmount")]
        public decimal TaxAmount { get; set; }


        [JsonProperty(PropertyName = "shippingAmount")]
        public decimal ShippingAmount { get; set; }


        [JsonProperty(PropertyName = "items")]
        public List<OrderItem> Items { get; set; }


        [JsonProperty(PropertyName = "advancedOptions")]
        public AdvancedOptions AdvancedOptions { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Jet;
using ShipStation;


namespace MultiChannelIntegration.Utils
{
    class AppConverter
    {
        private static Logger Logger = Logger.Instance;


        public static ShipStationOrder ConvertToShipStationOrder(JetOrder jetOrder)
        {
            ShipStationOrder ShipStationOrder = new ShipStationOrder();
            ShipStationOrder.OrderNumber = jetOrder.ReferenceOrderId;
            ShipStationOrder.OrderKey = jetOrder.ReferenceOrderId;
            ShipStationOrder.OrderDate = DateTime.ParseExact(
                jetOrder.OrderAcknowledgedDate, "yyyy-MM-ddTHH:mm:ssZ",
                System.Globalization.CultureInfo.InvariantCulture);
            Logger.Log("Setup Order Details Complete", Status.DEBUG);


            // Setup Advanced Options
            ShipStationOrder.AdvancedOptions = new ShipStation.AdvancedOptions();
            Logger.Log("Setup Advanced Options Complete", Status.DEBUG);
            // End Setup for Advanced Options


            // Setup Order Items
            List<ShipStation.OrderItem> 
                items = 
                new List<ShipStation.OrderItem>();

            foreach (Jet.OrderItem Item in jetOrder.OrderItems)
            {
                ShipStation.OrderItem ShipStationItem = new ShipStation.OrderItem();

                ShipStationItem.Name = Item.ProductTitle;
                ShipStationItem.Quantity = Item.RequestedOrderQuantity;

                string Sku = Item.MerchantSku;
                ShipStationItem.OrderItemId = 
                    Int32.Parse(Regex.Replace(Sku, "[^0-9]", ""));
                ShipStationItem.Sku = Sku;
                ShipStationItem.UnitPrice = Item.ItemPrice.BasePrice;
                ShipStationItem.Upc = Item.Upc;

                items.Add(ShipStationItem);
            }
            ShipStationOrder.Items = items;
            Logger.Log("Setup Order Items Complete", Status.DEBUG);
            // End Setup for Order Items


            // Setup Billing Recipient
            ShipStation.Recipient BillingRecipient = new ShipStation.Recipient();
            BillingRecipient.Name = jetOrder.Buyer.Name;
            BillingRecipient.Phone = jetOrder.Buyer.PhoneNumber;
            ShipStationOrder.BillTo = BillingRecipient;
            Logger.Log("Setup Billing Recipient Complete", Status.DEBUG);
            // End Setup for Billing Recipient


            // Setup Shipping Recipient
            ShipStation.Recipient ShippingRecipient = new ShipStation.Recipient();
            ShippingRecipient.Name = jetOrder.ShippingTo.Recipient.Name;
            ShippingRecipient.Phone = jetOrder.ShippingTo.Recipient.PhoneNumber;
            ShippingRecipient.Street1 = jetOrder.ShippingTo.Address.AddressOne;
            ShippingRecipient.Street2 = jetOrder.ShippingTo.Address.AddressTwo;
            ShippingRecipient.City = jetOrder.ShippingTo.Address.City;
            ShippingRecipient.PostalCode = jetOrder.ShippingTo.Address.Zipcode;
            ShippingRecipient.State = jetOrder.ShippingTo.Address.State;
            ShippingRecipient.Country = "US";
            ShipStationOrder.ShipTo = ShippingRecipient;
            Logger.Log("Setup Shipping Recipient Complete", Status.DEBUG);
            // End Setup for Shipping Recipient

            return ShipStationOrder;
        }

        public static CancelShipment ConvertToCancelShipment(JetOrder jetOrder)
        {
            CancelShipment Shipment = new CancelShipment();
            Shipment.ShipmentId = new Random().Next(2147483599).ToString();

            List<CancelShipmentItem> Items = new List<CancelShipmentItem>();
            foreach (Jet.OrderItem OrderItem in jetOrder.OrderItems)
            {
                CancelShipmentItem ShipmentItem = new CancelShipmentItem();
                ShipmentItem.ShipmentItemId = OrderItem.OrderItemId;
                ShipmentItem.Sku = OrderItem.MerchantSku;
                ShipmentItem.CancelQty = OrderItem.RequestedOrderQuantity;

                Items.Add(ShipmentItem);
            }

            Shipment.ShipmentItems = Items;
            return Shipment;
        }
    }
}

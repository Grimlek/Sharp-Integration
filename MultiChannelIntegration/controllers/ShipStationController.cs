using Jet;
using ShipStation;
using MultiChannelIntegration.Domain;
using MultiChannelIntegration.Services;
using MultiChannelIntegration.Utils;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MultiChannelIntegration.Controllers
{
    class ShipStationController
    {
        private static Logger Logger = Logger.Instance;
        
        private const string User = "your user";
        private const string Pass = "your secret";

        private ShipStationClientService ShipStationClientService;


        public ShipStationController()
        {
            this.ShipStationClientService = new ShipStationClientService(User, Pass);
        }


        public void UploadOrders(List<JetOrder> orders, OrderStatus status)
        {
            Logger.Log("Upload Jet Orders to Ship Station", Status.INFO);

            List<ShipStationOrder> ShipStationOrders = new List<ShipStationOrder>();

            foreach (JetOrder JetOrder in orders)
            {
                Logger.Log("Jet Order " + JetOrder.MerchantOrderId, Status.DEBUG);

                ShipStationOrder ShipStationOrder = AppConverter.ConvertToShipStationOrder(JetOrder);
                ShipStationOrder.OrderStatus = status;

                ShipStationOrders.Add(ShipStationOrder);

                Logger.Log("Jet Order Complete", Status.DEBUG);
            }
            Task.Run(async () => await ShipStationClientService.CreateOrders(ShipStationOrders));
        }


        public List<JetOrder> RemoveUploadedOrders(List<JetOrder> jetOrders)
        {
            Logger.Log("Remove Uploaded Jet Orders to Ship Station", Status.INFO);
            List<ShipStationOrder> shipStationOrders = GetOrders(OrderStatus.AwaitingShipment);

            for (int i = jetOrders.Count - 1; i >= 0; i--)
            {
                foreach (ShipStationOrder ShipStationOrder in shipStationOrders)
                {
                    if (ShipStationOrder.OrderNumber.Equals(jetOrders[i].ReferenceOrderId))
                    {
                        jetOrders.RemoveAt(i);
                        Logger.Log("Removed Order from List to Upload, " + 
                            jetOrders[i].ReferenceOrderId, Status.DEBUG);
                    }
                }
            }

            return jetOrders;
        }


        public List<JetOrder> GetCancelledOrders(List<JetOrder> jetOrders)
        {
            Logger.Log("Get Cancelled Jet Orders in Ship Station", Status.INFO);
            List<ShipStationOrder> ShipStationOrders = GetOrders(OrderStatus.Cancelled);

            List<JetOrder> CancelledOrders = new List<JetOrder>();

            foreach (JetOrder JetOrder in jetOrders)
            {
                foreach (ShipStationOrder ShipStationOrder in ShipStationOrders)
                {
                    if (ShipStationOrder.OrderKey.Equals(JetOrder.ReferenceOrderId))
                    {
                        CancelledOrders.Add(JetOrder);
                        Logger.Log("Add Cancelled Order to Jet Order List, " + JetOrder.ReferenceOrderId, Status.DEBUG);
                    }
                }
            }

            return CancelledOrders;
        }


        public List<ShipStationOrder> GetOrders(OrderStatus status)
        {
            Logger.Log("Get Orders from Ship Station with status " + status, Status.INFO);
            List<ShipStationOrder> OrderList = new List<ShipStationOrder>();

            DateTime StartDate = DateTime.Now.AddDays(-5);
            string OrderStatus = AppUtils.ToOrderStatusString(status);
            ShipStationOrders ShipStationOrders = 
                Task.Run(async () => await ShipStationClientService.GetOrders(
                    OrderStatus, StartDate, 1)).Result;
            if (ShipStationOrders.Orders == null)
            {
                return OrderList;
            }
            OrderList.AddRange(ShipStationOrders.Orders);

            int Page = 2;
            uint Pages = ShipStationOrders.Pages;

            while (Page <= Pages)
            {
                ShipStationOrders NextPage = 
                    Task.Run(async () => await ShipStationClientService.GetOrders(
                        OrderStatus, StartDate, Page)).Result;

                OrderList.AddRange(ShipStationOrders.Orders);

                Page++;

                Logger.Log("Orders Page Requested, Page "+ Page.ToString() +
                    " out of Pages " + Pages.ToString(), Status.DEBUG);
            }

            return OrderList;
        }
    }
}
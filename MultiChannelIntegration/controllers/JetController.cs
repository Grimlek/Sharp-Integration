using Jet;
using MultiChannelIntegration.Domain;
using MultiChannelIntegration.Services;
using MultiChannelIntegration.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MultiChannelIntegration.Controllers
{
    class JetController
    {
        private static Logger Logger = Logger.Instance;

        private const string User = "your username";
        private const string Pass = "your secret";
        private const string FulfillmentNodeId = "your fulfillment node id";

        private JetClientService JetClientService;


        public JetController()
        {
            this.JetClientService = new JetClientService(User, Pass, FulfillmentNodeId);
        }


        public void AcknowledgeOrders()
        {
            var JetOrders = JetClientService.CheckForOrders(OrderStatus.Ready).Result;

            foreach (string Id in JetOrders.OrderUrls)
            {
                Logger.Log("New Jet Order for : " + Id, Status.INFO);
                JetOrder JetOrder = JetClientService.CheckForOrderDetails(Id).Result;
                Task.Run(async () => await JetClientService.AcknowledgeOrder(JetOrder));
            }

            Logger.Log("Check For Orders Complete", Status.INFO);
        }


        public List<JetOrder> GetAcknowledgedOrders(OrderStatus status)
        {
            Logger.Log("Get all Acknowledged Orders from Jet", Status.INFO);
            List<JetOrder> JetOrders = new List<JetOrder>();
            foreach (string Id in JetClientService.CheckForOrders(status).Result.GetOrderIds())
            {
                JetOrder Order = JetClientService.CheckForOrderDetails(Id).Result;
                foreach (OrderItem OrderItem in Order.OrderItems)
                {
                    Sku Sku = JetClientService.GetSku(OrderItem.MerchantSku).Result;
                    OrderItem.Upc = Sku.GetUpc();
                }
                JetOrders.Add(Order);
            }
            return JetOrders;
        }


        public void CancelOrders(List<JetOrder> jetOrders)
        {
            foreach (JetOrder JetOrder in jetOrders)
            {
                Logger.Log("Cancel Jet Order for " + JetOrder.MerchantOrderId, Status.INFO);

                CancelShipments CancelShipments = new CancelShipments();

                CancelShipments.OrderId = JetOrder.MerchantOrderId;

                List<CancelShipment> CancelShipmentsList = new List<CancelShipment>();

                CancelShipmentsList.Add(AppConverter.ConvertToCancelShipment(JetOrder));
                CancelShipments.Shipments = CancelShipmentsList;

                Task.Run(async () => await this.JetClientService.CancelShipment(CancelShipments));

                Logger.Log("Cancel Order Complete!", Status.INFO);
            }
        }
    }
}

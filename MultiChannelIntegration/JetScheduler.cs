using MultiChannelIntegration.Controllers;
using MultiChannelIntegration;
using Jet;
using MultiChannelIntegration.Domain;
using System.Collections.Generic;
using System.Timers;


namespace MultiChannelIntegration
{
    class JetScheduler
    {
        private static Logger Logger = Logger.Instance;

        private JetController JetController;
        private ShipStationController ShipStationController;


        public JetScheduler()
        {
            this.JetController = new JetController();
            this.ShipStationController = new ShipStationController();
        }


        public void CheckForOrdersTimerElapsed(object sender, ElapsedEventArgs e)
        {
            this.JetController.AcknowledgeOrders();

            List<JetOrder> JetOrders = JetController.GetAcknowledgedOrders(OrderStatus.Acknowledged);

            List<JetOrder> CancelledOrders = ShipStationController.GetCancelledOrders(JetOrders);

            if (CancelledOrders.Count > 0)
            {
                this.JetController.CancelOrders(CancelledOrders);

                JetOrders = this.JetController.GetAcknowledgedOrders(OrderStatus.Acknowledged);
            }

            JetOrders = this.ShipStationController.RemoveUploadedOrders(JetOrders);

            if (JetOrders.Count > 0)
            {
                this.ShipStationController.UploadOrders(JetOrders, OrderStatus.AwaitingShipment);
            }
        }
    }
}

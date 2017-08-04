using MultiChannelIntegration.Domain;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Jet
{
    class AcknowledgementOrder
    {
        [JsonProperty(PropertyName = "order_items")]
        public List<AcknowledgementOrderItem> OrderItems { get; set; }


        [JsonProperty(PropertyName = "acknowledgement_status")]
        public OrderStatus Status { get; set; }

        public AcknowledgementOrder(OrderStatus status, List<AcknowledgementOrderItem> orderItems)
        {
            this.OrderItems = orderItems;
            this.Status = status;
        }

    }
}

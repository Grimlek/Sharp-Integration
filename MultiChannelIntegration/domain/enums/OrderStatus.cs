

namespace MultiChannelIntegration.Domain
{
    public enum OrderStatus
    {
        WaitingUpload,
        Acknowledged,
        AwaitingShipment,
        Cancelled,
        Accepted,
        Ready,
        Shipped
    }
}

using System;
using System.Text;
using MultiChannelIntegration.Domain;


namespace MultiChannelIntegration.Utils
{
    public static class AppUtils
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }


        public static Service GetServiceFromFormat(string source, char delimiter)
        {
            source = source.Replace(delimiter.ToString(), "");
            return (Service) Enum.Parse(typeof(Service), source);
        }


        public static Carrier GetCarrierFromFormat(string source, char delimiter)
        {
            source = source.Replace(delimiter.ToString(), "");
            return (Carrier)Enum.Parse(typeof(Carrier), source);
        }


        public static string ToOrderStatusString(this OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.Accepted:
                    return "accepted";
                case OrderStatus.Acknowledged:
                    return "acknowledged";
                case OrderStatus.Cancelled:
                    return "cancelled";
                case OrderStatus.Ready:
                    return "ready";
                case OrderStatus.Shipped:
                    return "shipped";
                case OrderStatus.AwaitingShipment:
                    return "awaiting_shipment";
                case OrderStatus.WaitingUpload:
                    return "waiting_upload";
                default:
                    return "Not Supported";
            }
        }
    }
}

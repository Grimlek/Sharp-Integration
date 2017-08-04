using System.Collections.Generic;
using Newtonsoft.Json;


namespace Jet
{
    class JetOrders
    {
        [JsonProperty(PropertyName = "order_urls")]
        public List<string> OrderUrls { get; set; }


        public List<string> GetOrderIds()
        {
            List<string> Ids = new List<string>();
            foreach (string url in this.OrderUrls)
            {
                Ids.Add(url.Replace("/orders/withoutShipmentDetail/", ""));
            }
            return Ids;
        }


        public bool ShouldSerializeOrderUrls()
        {
            return (OrderUrls.Count > 0);
        }
    }
}

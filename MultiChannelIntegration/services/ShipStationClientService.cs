using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using ShipStation;
using MultiChannelIntegration.Utils;
using Newtonsoft.Json;


namespace MultiChannelIntegration.Services
{
    class ShipStationClientService
    {
        private static Logger Logger = Logger.Instance;
        private static readonly HttpClient HttpClient = new HttpClient();
        private readonly Uri BaseUrl = new Uri("https://ssapi.shipstation.com");

        private string AuthCredentials;

        
        public ShipStationClientService(string user, string secret)
        {
            StringBuilder Sb = new StringBuilder(user).Append(":").Append(secret);
            this.AuthCredentials = AppUtils.Base64Encode(Sb.ToString());
            this.SetDefaultHeaders();
        }


        public async Task<ShipStationOrder> GetOrder(string orderId)
        {
            Logger.Log("--- Ship Station Get Order for: " + orderId, Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/orders/";
            UriBuilder.Path += orderId;

            HttpResponseMessage HttpResponse = await HttpClient.GetAsync(UriBuilder.Uri);
            if (HttpResponse.IsSuccessStatusCode)
            {
                var ResponseContent = await HttpResponse.Content.ReadAsStringAsync();
                ShipStationOrder Order = JsonConvert.DeserializeObject<ShipStationOrder>(ResponseContent);

                string Message = String.Concat("Ship Station Get Order Success");
                Logger.Log(Message, Status.INFO);

                return Order;
            }
            else
            {
                string Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
                return new ShipStationOrder();
            }
        }


        public async Task<ShipStationOrders> GetOrders(string status, DateTime createDateStart, int page)
        {
            Logger.Log("Ship Station Get Orders for status " + status +
                ", Create Start Date " + createDateStart.ToString() +
                " and Page " + page.ToString(), Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/orders";
            UriBuilder.Query = new StringBuilder()
                .Append("orderStatus=").Append(status)
                .Append("&").Append("page=").Append(page)
                .Append("&").Append("createDateStart=").Append(createDateStart)
                .ToString();
            
            HttpResponseMessage HttpResponse = await HttpClient.GetAsync(UriBuilder.Uri);
            if (HttpResponse.IsSuccessStatusCode)
            {
                var ResponseContent = await HttpResponse.Content.ReadAsStringAsync();
                ShipStationOrders ShipStationOrders = 
                    JsonConvert.DeserializeObject<ShipStationOrders>(ResponseContent);

                string Message = String.Concat("Ship Station Get Orders Success");
                Logger.Log(Message, Status.INFO);
                
                return ShipStationOrders;
            }
            else
            {
                string Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
                return new ShipStationOrders();
            }
        }


        public async Task CreateOrders(List<ShipStationOrder> orders)
        {
            Logger.Log("Ship Station Create Orders from List, count " + orders.Count, Status.INFO);

            if (orders.Count == 0)
            {
                Logger.Log("No Orders to Create in Ship Station", Status.INFO);
                return;
            }

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/orders/createorders";

            HttpResponseMessage HttpResponse = await HttpClient.GetAsync(UriBuilder.Uri);
            if (HttpResponse.IsSuccessStatusCode)
            {
                string Message = String.Concat("Ship Station Create Orders Success");
                Logger.Log(Message, Status.INFO);
            }
            else
            {
                string Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
            }
        }


        private void SetDefaultHeaders()
        {
            HttpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Basic", this.AuthCredentials);
            HttpClient.DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
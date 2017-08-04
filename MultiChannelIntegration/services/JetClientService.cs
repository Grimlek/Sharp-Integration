using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using MultiChannelIntegration.Domain;
using Jet;
using Newtonsoft.Json;


namespace MultiChannelIntegration.Services
{
    class JetClientService
    {
        private static Logger Logger = Logger.Instance;

        private static readonly HttpClient HttpClient = new HttpClient();
        private readonly Uri BaseUrl = new Uri("https://merchant-api.jet.com/api");

        private string User;
        private string Pass;
        private string FulfillmentNodeId;
        private AuthorizationToken Token;


        public JetClientService(string user, string pass, string fulfillmentNodeId)
        {
            this.User = user;
            this.Pass = pass;
            this.FulfillmentNodeId = fulfillmentNodeId;
        }


        public async Task Upload(Sku sku)
        {
            Logger.Log("--- Upload Sku: " + sku.Id, Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/merchant-skus/";
            UriBuilder.Path += sku.Id;

            if (this.IsTokenExpired())
            {
                await this.RetrieveToken(new AuthorizationToken(this.User, this.Pass));
            }

            var StringPayload = await Task.Run(() => JsonConvert.SerializeObject(sku));
            var HttpContent = new StringContent(StringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage HttpResponse = await HttpClient.PutAsync(UriBuilder.Uri, HttpContent);
            if (HttpResponse.IsSuccessStatusCode)
            {
                string Message = String.Concat("Upload Sku Success: ", sku.GetUpc());
                Logger.Log(Message, Status.INFO);
            }
            else
            {
                string Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
            }
        }


        public async Task UploadPrice(string skuId, decimal price)
        {
            Logger.Log("--- Upload Sku Price for " + skuId, Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/merchant-skus/";
            UriBuilder.Path += skuId;
            UriBuilder.Path += "/price";

            if (this.IsTokenExpired())
            {
                await this.RetrieveToken(new AuthorizationToken(this.User, this.Pass));
            }

            String JsonBody = "{\"price\":" + price + "}";
            var StringPayload = await Task.Run(() => JsonConvert.SerializeObject(JsonBody));
            var HttpContent = new StringContent(StringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage HttpResponse = await HttpClient.PutAsync(UriBuilder.Uri, HttpContent);
            if (HttpResponse.IsSuccessStatusCode)
            {
                string Message = String.Concat("Upload Sku Price Success: ", skuId);
                Logger.Log(Message, Status.INFO);
            }
            else
            {
                string Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
            }
        }


        public async Task UploadInventory(string skuId, int quantity)
        {
            Logger.Log("--- Upload Inventory for Sku: " + skuId, Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/merchant-skus/";
            UriBuilder.Path += skuId;
            UriBuilder.Path += "/Inventory";

            if (this.IsTokenExpired())
            {
                await this.RetrieveToken(new AuthorizationToken(this.User, this.Pass));
            }

            List<FulfillmentNode> FulfillmentNodes = new List<FulfillmentNode>();
            FulfillmentNodes.Add(new FulfillmentNode(this.FulfillmentNodeId, quantity));
            Inventory Inventory = new Inventory(FulfillmentNodes);
            
            var StringPayload = await Task.Run(() => JsonConvert.SerializeObject(Inventory));
            var HttpContent = new StringContent(StringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage HttpResponse = await HttpClient.PutAsync(UriBuilder.Uri, HttpContent);
            if (HttpResponse.IsSuccessStatusCode)
            {
                string Message = String.Concat("Upload Inventory Success: ", skuId);
                Logger.Log(Message, Status.INFO);
            }
            else
            {
                string Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
            }
        }


        public async Task<JetOrders> CheckForOrders(OrderStatus status)
        {
            Logger.Log("--- Check for Orders by Status: " + status, Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/orders/";
            UriBuilder.Path += status;

            if (this.IsTokenExpired())
            {
                await this.RetrieveToken(new AuthorizationToken(this.User, this.Pass));
            }

            HttpResponseMessage HttpResponse = await HttpClient.GetAsync(UriBuilder.Uri);
            if (HttpResponse.IsSuccessStatusCode)
            {
                var ResponseContent = await HttpResponse.Content.ReadAsStringAsync();
                JetOrders JetOrders = JsonConvert.DeserializeObject<JetOrders>(ResponseContent);

                string Message = String.Concat("Get Orders by Status Success");
                Logger.Log(Message, Status.INFO);

                return JetOrders;
            }
            else
            {
                string Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
                JetOrders JetOrders = new JetOrders();
                JetOrders.OrderUrls = new List<string>();
                return JetOrders;
            }
        }


        public async Task AcknowledgeOrder(JetOrder jetOrder)
        {
            Logger.Log("--- Acknowledge Jet Order: " + jetOrder.MerchantOrderId, Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/orders/";
            UriBuilder.Path += jetOrder.MerchantOrderId;
            UriBuilder.Path += "/acknowledge";

            if (this.IsTokenExpired())
            {
                await this.RetrieveToken(new AuthorizationToken(this.User, this.Pass));
            }

            List<AcknowledgementOrderItem> OrderItems = new List<AcknowledgementOrderItem>();
            foreach (OrderItem Item in jetOrder.OrderItems)
            {
                AcknowledgementOrderItem AcknowledgedItem = new AcknowledgementOrderItem();
                AcknowledgedItem.OrderItemId = Item.OrderItemId;
                AcknowledgedItem.AcknowledgementStatus = "fulfillable";
                OrderItems.Add(AcknowledgedItem);
            }
            AcknowledgementOrder AcknowledgementOrder = new AcknowledgementOrder(OrderStatus.Accepted, OrderItems);

            var StringPayload = await Task.Run(() => JsonConvert.SerializeObject(AcknowledgementOrder));
            var HttpContent = new StringContent(StringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage HttpResponse = await HttpClient.PutAsync(UriBuilder.Uri, HttpContent);
            if (HttpResponse.IsSuccessStatusCode)
            {
                string Message = String.Concat("Acknowledge Order Success: ", jetOrder.MerchantOrderId);
                Logger.Log(Message, Status.INFO);
            }
            else
            {
                string Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
            }
        }


        public async Task<JetOrder> CheckForOrderDetails(string orderid)
        {
            Logger.Log("--- Check for Order Details --- : " + orderid, Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/orders/withoutShipmentDetail/";
            UriBuilder.Path += orderid;

            if (this.IsTokenExpired())
            {
                await this.RetrieveToken(new AuthorizationToken(this.User, this.Pass));
            }

            HttpResponseMessage HttpResponse = await HttpClient.GetAsync(UriBuilder.Uri);
            if (HttpResponse.IsSuccessStatusCode)
            {
                var ResponseContent = await HttpResponse.Content.ReadAsStringAsync();
                JetOrder JetOrder = JsonConvert.DeserializeObject<JetOrder>(ResponseContent);

                var Message = String.Concat("Get Order Details Success");
                Logger.Log(Message, Status.INFO);

                return JetOrder;
            }
            else
            {
                var Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
                JetOrder JetOrder = new JetOrder();
                return JetOrder;
            }
        }


        public async Task<Sku> GetSku(string skuId)
        {
            Logger.Log("--- Get Sku for Id : " + skuId, Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/merchant-skus/";
            UriBuilder.Path += skuId;

            if (this.IsTokenExpired())
            {
                await this.RetrieveToken(new AuthorizationToken(this.User, this.Pass));
            }

            HttpResponseMessage HttpResponse = await HttpClient.GetAsync(UriBuilder.Uri);
            if (HttpResponse.IsSuccessStatusCode)
            {
                var ResponseContent = await HttpResponse.Content.ReadAsStringAsync();
                Sku Sku = JsonConvert.DeserializeObject<Sku>(ResponseContent);

                var Message = String.Concat("Get Sku Success");
                Logger.Log(Message, Status.INFO);

                return Sku;
            }
            else
            {
                var Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
                Sku Sku = new Sku();
                return Sku;
            }
        }


        public async Task CancelShipment(CancelShipments shipments)
        {
            Logger.Log("Jet Cancel Shipment for Order Id " + shipments.OrderId, Status.INFO);

            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/orders/";
            UriBuilder.Path += shipments.OrderId;
            UriBuilder.Path += "/shipped";

            if (this.IsTokenExpired())
            {
                await this.RetrieveToken(new AuthorizationToken(this.User, this.Pass));
            }

            var StringPayload = await Task.Run(() => JsonConvert.SerializeObject(shipments));
            var HttpContent = new StringContent(StringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage HttpResponse = await HttpClient.PutAsync(UriBuilder.Uri, HttpContent);
            if (HttpResponse.IsSuccessStatusCode)
            {
                Logger.Log("Jet Cancel Shipment Success", Status.INFO);
            }
            else
            {
                string Message = String.Concat("Error occurred, the status code is: ", HttpResponse.StatusCode);
                Logger.Log(Message, Status.ERROR);
            }
        }

        
        //public async Task ShipOrder(JetShipments jetShipments, string orderId)
        //{
        //    throw new NotImplementedException();
        //}


        //public async Task UploadShippingException(string skuId, FulfillmentNodes fulfillmentNodes)
        //{
        //    throw new NotImplementedException();
        //}


        //public async Task UploadReturnsException(string skuId, ReturnsException returnsException)
        //{
        //    throw new NotImplementedException();
        //}


        //public async SettlementReport GetSettlementReport(string settlementReportUrl)
        //{
        //    throw new NotImplementedException();
        //}


        //public async SettlementReports GetSettlementReportUrls(int days)
        //{
        //    throw new NotImplementedException();
        //}


        //public async ReturnDetails GetReturnDetails(string returnUrl)
        //{
        //    throw new NotImplementedException();
        //}


        //public async Task CompleteReturn(ReturnDetails returnDetails, string returnId)
        //{
        //    throw new NotImplementedException();
        //}


        //public async Task<List<string>> GetReturnsUrls(string status)
        //{
        //    throw new NotImplementedException();
        //}


        private async Task<object> RetrieveToken(AuthorizationToken token)
        {
            UriBuilder UriBuilder = new UriBuilder(BaseUrl);
            UriBuilder.Path += "/token";
            Uri UploadUri = UriBuilder.Uri;

            var StringPayload = await Task.Run(() => JsonConvert.SerializeObject(token));
            var HttpContent = new StringContent(StringPayload, Encoding.UTF8, "application/json");

            var HttpResponse = await HttpClient.PostAsync(UploadUri, HttpContent);
            if (HttpResponse.Content != null)
            {
                var ResponseContent = await HttpResponse.Content.ReadAsStringAsync();

                this.Token = JsonConvert.DeserializeObject<AuthorizationToken>(ResponseContent);
                
                HttpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", this.Token.TokenId);
                HttpClient.DefaultRequestHeaders
                    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            return Task.FromResult<object>(null);
        }


        private Boolean IsTokenExpired()
        {
            if (this.Token == null || this.Token.GetTokenExpiration().CompareTo(DateTime.Now) >= 0) {
                return true;
            }
            return false;
        }
    }
}

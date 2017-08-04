using Newtonsoft.Json;


namespace Jet
{
    class SettlementReport
    {
        [JsonProperty(PropertyName = "settlement_report_id")]
        public string SettlementReportId { get; set; }

        [JsonProperty(PropertyName = "settlement_state")]
        public string SettlementState { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "unavailable_balance")]
        public decimal UnavailableBalance { get; set; }

        [JsonProperty(PropertyName = "settlement_period_start")]
        public string SettlementPayPeriodStart { get; set; }

        [JsonProperty(PropertyName = "settlement_period_end")]
        public string SettlementPayPeriodEnd { get; set; }

        [JsonProperty(PropertyName = "return_balance")]
        public string ReturnBalance { get; set; }

        [JsonProperty(PropertyName = "jet_adjustment")]
        public string JetAdjustment { get; set; }

        [JsonProperty(PropertyName = "settlement_value")]
        public string SettlementValue { get; set; }

        [JsonProperty(PropertyName = "order_balance")]
        public decimal OrderBalance { get; set; }

        [JsonProperty(PropertyName = "order_balance_details")]
        public OrderBalanceDetails OrderBalanceDetails { get; set; }

        [JsonProperty(PropertyName = "return_balance_details")]
        public ReturnBalanceDetails ReturnBalanceDetails { get; set; }
    }
}

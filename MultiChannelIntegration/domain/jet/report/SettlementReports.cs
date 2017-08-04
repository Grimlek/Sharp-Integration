using Newtonsoft.Json;
using System.Collections.Generic;


namespace Jet
{
    class SettlementReports
    {
        [JsonProperty(PropertyName = "settlement_report_urls")]
        public List<string> SettlementReportUrls { get; set; }
    }
}

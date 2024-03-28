using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorMarketWatch.Web.Dtos
{
    public class StockDto
    {
        public class Rootobject
        {
            public TickerSummary meta { get; set; }
            public Value[] values { get; set; }
            public string status { get; set; }
        }

        public class TickerSummary
        {
            public string symbol { get; set; }
            public string interval { get; set; }
            public string currency { get; set; }
            public string exchange_timezone { get; set; }
            public string exchange { get; set; }
            public string mic_code { get; set; }
            public string type { get; set; }
        }

        public class Value
        {
            public string datetime { get; set; }
            public string open { get; set; }
            public string high { get; set; }
            public string low { get; set; }
            public string close { get; set; }
            public string volume { get; set; }
        }

        public class TickerSummaryDto
        {
            public List<TickerSummary> data { get; set; }
            public string status { get; set; }
        }
    }
}

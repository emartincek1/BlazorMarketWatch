namespace BlazorMarketWatch.Web.Dtos
{
    public class MarketMoversDto
    {
        public class MostActivelyTraded
        {
            public string ticker { get; set; }
            public string price { get; set; }
            public string change_amount { get; set; }
            public string change_percentage { get; set; }
            public string volume { get; set; }
        }

        public class Root
        {
            public string metadata { get; set; }
            public string last_updated { get; set; }
            public List<TopGainer> top_gainers { get; set; }
            public List<TopLoser> top_losers { get; set; }
            public List<MostActivelyTraded> most_actively_traded { get; set; }
        }

        public class TopGainer
        {
            public string ticker { get; set; }
            public string price { get; set; }
            public string change_amount { get; set; }
            public string change_percentage { get; set; }
            public string volume { get; set; }
        }

        public class TopLoser
        {
            public string ticker { get; set; }
            public string price { get; set; }
            public string change_amount { get; set; }
            public string change_percentage { get; set; }
            public string volume { get; set; }
        }
    }
}

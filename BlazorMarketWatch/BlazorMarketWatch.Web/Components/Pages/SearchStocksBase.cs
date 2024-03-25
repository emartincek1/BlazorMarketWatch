using Microsoft.AspNetCore.Components;

namespace BlazorMarketWatch.Web.Components.Pages
{
    public class SearchStocksBase:ComponentBase
    {
        public List<string> TopStocks { get; set; }
        public string TextValue { get; set; }

        protected override void OnInitialized()
        {
            TopStocks = new List<string> { "AAPL", "XOM", "WMT", "TSLA", "PYPL", "NFLX", "MSFT", "MMM", "META", "KO", "GOOGL", "COST" };
        }
    }
}

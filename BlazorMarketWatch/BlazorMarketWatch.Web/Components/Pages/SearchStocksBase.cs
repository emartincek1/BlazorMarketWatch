using BlazorMarketWatch.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using static BlazorMarketWatch.Web.Dtos.StockDto;

namespace BlazorMarketWatch.Web.Components.Pages
{
    public class SearchStocksBase:ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IStockService StockService { get; set; }

        public List<string> TopStocks { get; set; }
        public TickerSummaryDto TickerSummary { get; set; }
        public string TextValue { get; set; }

        protected async override Task OnInitializedAsync()
        {
            TickerSummary = await StockService.GetStockTickers();
            TopStocks = new List<string> { "AAPL", "XOM", "WMT", "TSLA", "PYPL", "NFLX", "MSFT", "MMM", "META", "KO", "GOOGL", "COST" };
        }

        protected void SearchStock_Click()
        {
            NavigationManager.NavigateTo($"StockDetail/{TextValue}/1day");
        }
    }
}

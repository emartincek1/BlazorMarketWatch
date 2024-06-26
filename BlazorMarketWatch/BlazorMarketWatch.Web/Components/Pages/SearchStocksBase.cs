﻿using BlazorMarketWatch.Web.Services.Contracts;
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
            TopStocks = new List<string> { "AAPL", "SPY", "XOM", "WMT", "TSLA", "PYPL", "NFLX", "MSFT", "MMM", "META", "KO", "GOOGL", "COST" };
        }

        protected void SearchStock_Click()
        {
            if (TextValue == null ) 
            {
                NavigationManager.NavigateTo($"StockDetail/Invalid/1day");
            }
            else
            {
                var ticker = TextValue.Split(" ");
                NavigationManager.NavigateTo($"StockDetail/{ticker[0]}/1day");
            }            
        }

        protected async Task<IEnumerable<string>> Search(string value)
        {
            if (string.IsNullOrEmpty(value))
                return new string[0];
            var tickers = TickerSummary.data.Where(x => x.symbol.Contains(value, StringComparison.InvariantCultureIgnoreCase)
                                                    || x.name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
            return Convert(tickers);
        }

        private IEnumerable<string> Convert(IEnumerable<TickerSummary> tickerSummaries)
        {
            List<string> result = [];
            foreach (var tickerSummary in tickerSummaries)
            {
                result.Add($"{tickerSummary.symbol} - {tickerSummary.name}");
            }
            return result;
        }
    }
}

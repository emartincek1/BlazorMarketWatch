using BlazorMarketWatch.Web.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;
using System.Text.Json;
using static BlazorMarketWatch.Web.Dtos.StockDto;

namespace BlazorMarketWatch.Web.Services
{
    public class StockService : IStockService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private TickerSummaryDto tickerSummary;

        public StockService (IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<StockDto.Rootobject?> GetStock(string symbol, string interval)
        {
            try
            {
                using var httpClient = httpClientFactory.CreateClient();

                var response = await httpClient.GetAsync(
                    $"https://api.twelvedata.com/time_series?symbol={symbol}&interval={interval}&outputsize=30&apikey=1aaff2c87d404866a270852a157e04b7");


                var stock = await response.Content.ReadFromJsonAsync<StockDto.Rootobject?>();

                if ( stock.values != null ) 
                {
                    return stock;
                }
                else
                {
                    throw new Exception("Invalid Stock Ticker");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TickerSummaryDto> GetStockTickers()
        {
            try
            {
                var s = File.ReadAllText("wwwroot/tickers.json");
                var dtos = JsonSerializer.Deserialize<TickerSummaryDto>(s);
                return dtos;

            }catch (Exception e)
            {
                return null;
            }
        }
    }
}

using BlazorMarketWatch.Models.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;

namespace BlazorMarketWatch.Web.Services
{
    public class StockService : IStockService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public StockService (IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<StockDto.Rootobject?> GetStock(string symbol, string interval)
        {
            try
            {
                using var httpClient = httpClientFactory.CreateClient();

                var stockData = await httpClient.GetFromJsonAsync<StockDto.Rootobject>(
                    $"https://api.twelvedata.com/time_series?symbol={symbol}&interval={interval}&outputsize=10&apikey=1aaff2c87d404866a270852a157e04b7");

                return stockData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

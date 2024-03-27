using BlazorMarketWatch.Web.Dtos;
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
    }
}

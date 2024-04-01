using BlazorMarketWatch.Web.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;
using static BlazorMarketWatch.Web.Dtos.StockDto;
using System.Text.Json;

namespace BlazorMarketWatch.Web.Services
{
    public class MarketMoversService : IMarketMoversService
    {

        private readonly IHttpClientFactory httpClientFactory;
        

        public MarketMoversService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<MarketMoversDto.Root> GetMarketMovers()
        {
            try
            {
                using var httpClient = httpClientFactory.CreateClient();

                var response = await httpClient.GetAsync(
                    $"https://www.alphavantage.co/query?function=TOP_GAINERS_LOSERS&apikey=H79HSAEXLIW212PN");


                var marketMovers = await response.Content.ReadFromJsonAsync<MarketMoversDto.Root>();

                if (marketMovers != null)
                {
                    return marketMovers;
                }
                else
                {
                    throw new Exception("Failure Getting Market Movers");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<MarketMoversDto.Root> GetMarketMoversJSON()
        {
            try
            {
                var s = File.ReadAllText("wwwroot/marketmovers.json");
                var dtos = JsonSerializer.Deserialize<MarketMoversDto.Root>(s);
                return dtos;

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}

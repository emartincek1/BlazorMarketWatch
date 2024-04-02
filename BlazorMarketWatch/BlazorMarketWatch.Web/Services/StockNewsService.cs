using BlazorMarketWatch.Web.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;

namespace BlazorMarketWatch.Web.Services
{
    public class StockNewsService : IStockNewsService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public StockNewsService(IHttpClientFactory httpClientFactory) 
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<StockNewsDto.Root> GetStockNews(string symbol)
        {
            try
            {
                using var httpClient = httpClientFactory.CreateClient();

                var response = await httpClient.GetAsync(
                        $"https://api.stockdata.org/v1/news/all?api_token=pRHjxs2ZYywvBvb3Ra5p0pdxEjDNYhGYxYdCy8GD&language=en&symbols={symbol}");

                var news = await response.Content.ReadFromJsonAsync<StockNewsDto.Root>();

                if (news != null) 
                {
                    return news;
                }
                else
                {
                    throw new Exception("Failure Getting Stock News");
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}

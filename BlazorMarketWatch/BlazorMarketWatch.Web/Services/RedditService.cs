using BlazorMarketWatch.Web.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;

namespace BlazorMarketWatch.Web.Services
{
    public class RedditService : IRedditService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RedditService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<RedditDto>> GetRedditStocks()
        {
            try
            {
                var currentDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
                using var httpClient = httpClientFactory.CreateClient();

                var response = await httpClient.GetAsync(
                    $"https://tradestie.com/api/v1/apps/reddit?date={currentDate}");

                var redditStocks = await response.Content.ReadFromJsonAsync<IEnumerable<RedditDto>>();

                if ( redditStocks != null )
                {
                    return redditStocks;
                }
                else
                {
                    throw new Exception("Failure Getting Reddit Stocks");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
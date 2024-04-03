using BlazorMarketWatch.Web.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;

namespace BlazorMarketWatch.Web.Services
{
    public class RedditService : IRedditService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<RedditService> logger;

        public RedditService(IHttpClientFactory httpClientFactory, ILogger<RedditService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<IEnumerable<RedditDto>> GetRedditStocks()
        {
            try
            {
                var currentDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
                using var httpClient = httpClientFactory.CreateClient();

                var response = await httpClient.GetAsync(
                    $"https://tradestie.com/api/v1/apps/reddit?date={currentDate}");

                logger?.LogInformation(response?.Content?.ToString() ?? "no response");

                var redditStocks = await response.Content.ReadFromJsonAsync<IEnumerable<RedditDto>>();
              
                return redditStocks;
            }
            catch (Exception e)
            {
                logger?.LogError(e, "Failure Getting Reddit Stocks");
                return null;
            }
        }
    }
}
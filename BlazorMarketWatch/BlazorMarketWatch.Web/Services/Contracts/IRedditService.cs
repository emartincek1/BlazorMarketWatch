using BlazorMarketWatch.Web.Dtos;

namespace BlazorMarketWatch.Web.Services.Contracts
{
    public interface IRedditService
    {
        Task<IEnumerable<RedditDto>> GetRedditStocks();
    }
}

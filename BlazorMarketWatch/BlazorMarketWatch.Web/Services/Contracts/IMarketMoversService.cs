using BlazorMarketWatch.Web.Dtos;
using static BlazorMarketWatch.Web.Dtos.MarketMoversDto;

namespace BlazorMarketWatch.Web.Services.Contracts
{
    public interface IMarketMoversService
    {
        Task<Root> GetMarketMovers();
        Task<Root> GetMarketMoversJSON();
    }
}

using BlazorMarketWatch.Web.Dtos;

namespace BlazorMarketWatch.Web.Services.Contracts
{
    public interface IStockNewsService
    {
        Task<StockNewsDto.Root> GetStockNews(string symbol);
    }
}

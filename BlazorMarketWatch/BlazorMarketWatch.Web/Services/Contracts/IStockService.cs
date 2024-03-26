using BlazorMarketWatch.Models.Dtos;

namespace BlazorMarketWatch.Web.Services.Contracts
{
    public interface IStockService
    {
        Task<StockDto.Rootobject?> GetStock(string symbol, string interval);
    }
}

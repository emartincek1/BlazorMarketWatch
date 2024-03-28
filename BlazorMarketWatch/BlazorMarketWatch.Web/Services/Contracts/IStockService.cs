using BlazorMarketWatch.Web.Dtos;

namespace BlazorMarketWatch.Web.Services.Contracts
{
    public interface IStockService
    {
        Task<StockDto.TickerSummaryDto> GetStockTickers();
        Task<StockDto.Rootobject?> GetStock(string symbol, string interval);
    }
}

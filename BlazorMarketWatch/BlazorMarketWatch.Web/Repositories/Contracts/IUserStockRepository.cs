using BlazorMarketWatch.Web.Entities;

namespace BlazorMarketWatch.Web.Repositories.Contracts
{
    public interface IUserStockRepository
    {
        Task<IEnumerable<UserStock>> GetUserStocks(string userId);
        Task<UserStock> AddUserStock(string ticker, string userId);
        Task<UserStock> DeleteUserStock(int id);
    }
}

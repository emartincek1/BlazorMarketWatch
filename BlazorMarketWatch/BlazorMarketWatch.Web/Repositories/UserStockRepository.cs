using BlazorMarketWatch.Web.Data;
using BlazorMarketWatch.Web.Entities;
using BlazorMarketWatch.Web.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BlazorMarketWatch.Web.Repositories
{
    public class UserStockRepository : IUserStockRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserStockRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        private async Task<bool> UserStockExists(string ticker, string userId)
        {
            return await applicationDbContext.UserStocks.AnyAsync(s => s.Ticker == ticker &&
                                                                s.UserId == userId);
        }

        public async Task<UserStock> AddUserStock(string ticker, string userId)
        {
            if (await UserStockExists(ticker, userId) == false)
            {
                var userStock = new UserStock
                {
                    Ticker = ticker,
                    UserId = userId
                };

                if (userStock != null)
                {
                    var result = await applicationDbContext.UserStocks.AddAsync(userStock);
                    await applicationDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;
        }

        public Task<UserStock> DeleteUserStock(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserStock>> GetUserStocks(string userId)
        {
            var userStocks = await (from userStock in applicationDbContext.UserStocks
                                    where userStock.UserId == userId
                                    select userStock).ToListAsync();
            return userStocks;
        }
    }
}

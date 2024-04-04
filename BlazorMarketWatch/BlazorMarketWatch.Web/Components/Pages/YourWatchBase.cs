using BlazorMarketWatch.Web.Entities;
using BlazorMarketWatch.Web.Repositories.Contracts;
using BlazorMarketWatch.Web.Services;
using BlazorMarketWatch.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using static BlazorMarketWatch.Web.Dtos.StockDto;

namespace BlazorMarketWatch.Web.Components.Pages
{
    public class YourWatchBase: ComponentBase
    {
        [Inject]
        public IUserStockRepository userStockRepository {  get; set; }

        [Inject]
        public AuthenticationStateProvider authenticationStateProvider { get; set; }

        [Inject]
        public IStockService StockService { get; set; }

        public TickerSummaryDto TickerSummaryData { get; set; }

        public IEnumerable<UserStock> UserStocks { get; set; }

        public IEnumerable<TickerSummary> Summaries { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TickerSummaryData = await StockService.GetStockTickers();
            GetUserStocks();
        }

        private async void GetUserStocks()
        {
            try
            {
                var userId = await getUserId();
                UserStocks = await userStockRepository.GetUserStocks(userId);
                if (UserStocks == null)
                {
                    throw new Exception("Error fetching user stocks");
                }
                Summaries = ConvertToTickerSummary(UserStocks);
                if (Summaries == null)
                {
                    throw new Exception("Error converting tickers to summaries");
                }
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private IEnumerable<TickerSummary> ConvertToTickerSummary(IEnumerable<UserStock> tickers)
        {
            List<TickerSummary> result = new List<TickerSummary>();
            foreach (UserStock ticker in tickers)
            {
                var summary = TickerSummaryData.data.Where(x => x.symbol == ticker.Ticker).FirstOrDefault();
                if (summary != null)
                {
                    result.Add(summary);
                }
            }
            return result;
        }

        async Task<string> getUserId()
        {
            var user = (await authenticationStateProvider.GetAuthenticationStateAsync()).User;
            var UserId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return UserId;
        }

        protected async void RemoveStock_Click(string ticker)
        {
            try
            {
                var id = ConvertTickerToId(ticker);
                if (id == 0)
                {
                    throw new Exception("Remove conversion failed");
                }
                var result = await userStockRepository.DeleteUserStock(id);
                if (result == null)
                {
                    throw new Exception("Remove user stock failed");
                }
                GetUserStocks();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private int ConvertTickerToId(string ticker)
        {
            var stock = UserStocks.Where(x => x.Ticker == ticker).FirstOrDefault();
            if (stock != null)
            {
                return stock.Id;
            }
            return 0;
        }
    }
}

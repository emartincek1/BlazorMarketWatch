using BlazorMarketWatch.Web.Entities;
using BlazorMarketWatch.Web.Repositories.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorMarketWatch.Web.Components.Pages
{
    public class YourWatchBase: ComponentBase
    {
        [Inject]
        public IUserStockRepository userStockRepository {  get; set; }

        [Inject]
        public AuthenticationStateProvider authenticationStateProvider { get; set; }

        public IEnumerable<UserStock> UserStocks { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
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
                StateHasChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        async Task<string> getUserId()
        {
            var user = (await authenticationStateProvider.GetAuthenticationStateAsync()).User;
            var UserId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return UserId;
        }

        protected async void RemoveStock_Click(int id)
        {
            try
            {
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
    }
}

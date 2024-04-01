using BlazorMarketWatch.Web.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace BlazorMarketWatch.Web.Components.Pages
{
    public class RedditStocksBase: ComponentBase
    {
        [Inject]
        public IRedditService redditService { get; set; }

        public IEnumerable<RedditDto> RedditStocks { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {   
                RedditStocks = await redditService.GetRedditStocks();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}

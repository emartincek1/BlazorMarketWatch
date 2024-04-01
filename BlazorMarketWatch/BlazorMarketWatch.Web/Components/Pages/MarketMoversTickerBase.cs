using BlazorMarketWatch.Web.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace BlazorMarketWatch.Web.Components.Pages
{
    public class MarketMoversTickerBase: ComponentBase
    {
        [Inject]
        public IMarketMoversService marketMoversService { get; set; }

        public MarketMoversDto.Root MarketMovers {  get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                MarketMovers = await marketMoversService.GetMarketMoversJSON();
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}

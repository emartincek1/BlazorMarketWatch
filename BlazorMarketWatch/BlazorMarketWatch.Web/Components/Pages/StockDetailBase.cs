using BlazorMarketWatch.Models.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace BlazorMarketWatch.Web.Components.Pages
{
    public class StockDetailBase : ComponentBase
    {
        [Parameter]
        public string Symbol { get; set; }

        [Inject]
        public IStockService StockService { get; set; }

        public StockDto.Rootobject? Stock { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Stock = await StockService.GetStock(Symbol, "1day");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}

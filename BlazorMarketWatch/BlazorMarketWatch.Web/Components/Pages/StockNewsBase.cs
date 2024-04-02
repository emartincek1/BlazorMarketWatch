using BlazorMarketWatch.Web.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace BlazorMarketWatch.Web.Components.Pages
{
    public class StockNewsBase:ComponentBase
    {
        [Inject]
        public IStockNewsService stockNewsService { get; set; }

        [Parameter]
        public string Symbol { get; set; }

        public StockNewsDto.Root StockNews { get; set; }

        public string ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {   
                StockNews = await stockNewsService.GetStockNews(Symbol);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}

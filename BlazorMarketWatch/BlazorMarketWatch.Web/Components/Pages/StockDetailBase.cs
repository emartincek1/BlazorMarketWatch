using BlazorMarketWatch.Web.Dtos;
using BlazorMarketWatch.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorMarketWatch.Web.Components.Pages
{
    public class StockDetailBase : ComponentBase
    {
        [Parameter]
        public string Symbol { get; set; }

        [Parameter]
        public string TimeInterval { get; set; }

        [Inject]
        public IStockService StockService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public StockDto.Rootobject? Stock { get; set; }

        public string ErrorMessage { get; set; }

        public string[] XAxisLabels { get; set; }

        public int Index = -1;

        public ChartOptions Options = new ChartOptions();

        public List<ChartSeries> Series = new List<ChartSeries>();
        public ChartSeries ChartSeries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Stock = await StockService.GetStock(Symbol, TimeInterval);

                XAxisLabels = [Stock.values[7].datetime, Stock.values[6].datetime, Stock.values[5].datetime, Stock.values[4].datetime, 
                                Stock.values[3].datetime, Stock.values[2].datetime, Stock.values[1].datetime, Stock.values[0].datetime,];

                ChartSeries = new ChartSeries()
                {
                    Name = $"{Stock.meta.symbol}",
                    Data = new double[] {Convert.ToDouble(Stock.values[7].close), Convert.ToDouble(Stock.values[6].close), Convert.ToDouble(Stock.values[5].close), Convert.ToDouble(Stock.values[4].close),                                        
                                        Convert.ToDouble(Stock.values[3].close), Convert.ToDouble(Stock.values[2].close), Convert.ToDouble(Stock.values[1].close), Convert.ToDouble(Stock.values[0].close)}
                };
                Series.Add(ChartSeries);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected void ChangeChart_Click(string symbol,string interval)
        {
            NavigationManager.NavigateTo($"StockDetail/{symbol}/{interval}", true);
        }
    }
}





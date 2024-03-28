using BlazorMarketWatch.Web.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorMarketWatch.Web.Entities
{
    public class UserStock
    {
        public int Id { get; set; }

        public string Ticker { get; set; }  

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}

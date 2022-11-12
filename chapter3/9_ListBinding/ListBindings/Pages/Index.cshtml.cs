using ListBindings.ServicesLayer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListBindings.Pages
{
    public class IndexModel : PageModel
    {
        private CurrencyService currencyService;
        public List<SelectListItem> Currencies { get; set; }

        public IndexModel(CurrencyService currencyService)
        {
            this.currencyService = currencyService; 
        }
        public void OnGet()
        {
            this.Currencies = this.currencyService.AllCurrencies
                .Select(x => new SelectListItem { Text = x.Key })
                .ToList();
        }
    }
}

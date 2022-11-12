using ListBindings.ServicesLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListBindings.Pages
{
    [IgnoreAntiforgeryToken]
    public class ShowRatesModel : PageModel
    {
        private readonly CurrencyService currencyService;
        public Dictionary<string, decimal> SelectedCurrencies { get; set; } = new Dictionary<string, decimal>();

        public ShowRatesModel(CurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        public void OnPost(List<string> currencies)
        {
            this.SelectedCurrencies =
                this.currencyService.AllCurrencies
                .Where(x => currencies.Contains(x.Key))
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
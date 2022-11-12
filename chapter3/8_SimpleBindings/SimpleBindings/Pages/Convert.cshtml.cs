using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleBindings.Pages
{
    public class ConvertModel : PageModel
    {
        public string Values { get; set; }

        public void OnGet( string currencyIn,  string currencyOut, int qty)
        {
            this.Values = $@"CurrencyIn: {currencyIn} CurrencyOut: {currencyOut} Qty: {qty}";
        }
    

    }
}
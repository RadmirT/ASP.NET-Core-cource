using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoutingExample.Pages
{
    public class CurrencyModel : PageModel
    {
        public string Code { get; private set; }
        public void OnGet(string code)
        {
            Code = code;
        }
    }
}

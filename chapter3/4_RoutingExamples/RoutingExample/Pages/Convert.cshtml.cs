using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoutingExample.Pages
{
    public class ConvertModel : PageModel
    {
        public string Currency { get; set; }

        public string Other { get; set; }

        public int Id { get; set; }
        public IActionResult OnGet(string currency, string other)
        {
            Currency = currency;
            Other = other;
            return Page();
        }

    }
}
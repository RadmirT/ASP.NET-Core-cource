using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RoutingExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            //var url = Url.Page("Currency", new { code = "USD" });
            
            //var url = Url.Action("Index", "Exchange",
            //    new { from = "USD", to="RUR"});

            return this.RedirectToPage("Currency", new { code = "RUR" });
        }
    }
}

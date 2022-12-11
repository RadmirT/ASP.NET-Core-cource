using System.Net;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;

namespace shopping.com.Areas.Auth.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            this._logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string returnUrl)
        {
            var url = WebUtility.UrlDecode(returnUrl);
            if (!Url.IsLocalUrl(url))
            {
                return this.Redirect("/Index");
            }
            return this.Redirect(url);
        }
    }
}

using CustomConfiguration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace SampleApplication.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> logger;
    private readonly CurrencyOptions options;

    public IndexModel(ILogger<IndexModel> logger, IOptions<CurrencyOptions> options)
    {
        this.logger = logger;
        this.options = options.Value;
    }

    public void OnGet()
    {

    }
}

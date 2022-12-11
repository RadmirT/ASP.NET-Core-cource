using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApplication.ServicesLayer;

namespace SampleApplication.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMyService myService;

    public IndexModel(ILogger<IndexModel> logger, IMyService myService)
    {
        _logger = logger;
        this.myService = myService;
    }

    public void OnGet()
    {

    }
}

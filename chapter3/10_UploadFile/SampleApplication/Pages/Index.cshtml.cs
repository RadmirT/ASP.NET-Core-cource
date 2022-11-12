using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleApplication.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public IFormFile File { get; set; }
    
    public void OnGet()
    {
    }
    public void OnPost()
    {
    }
}

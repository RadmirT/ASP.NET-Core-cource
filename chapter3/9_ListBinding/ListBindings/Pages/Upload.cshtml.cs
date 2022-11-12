using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListBindings.Pages
{
    public class UploadModel : PageModel
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
}

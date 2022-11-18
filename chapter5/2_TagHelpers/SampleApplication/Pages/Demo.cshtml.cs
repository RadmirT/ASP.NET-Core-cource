using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleApplication.Pages
{
    public class DemoModel : PageModel
    {
        public int Int { get; set; }
        public bool Boolean { get; set; }
        public DateTime? DateTime { get; set; }
        public void OnGet()
        {

        }
    }
}
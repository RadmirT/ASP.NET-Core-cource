using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApplication.ServicesLayer;

namespace SampleApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoService _service;

        public IndexModel(ToDoService service)
        {
            this._service = service;
        }

        public IEnumerable<ToDoItem> Items { get; set; }
        public void OnGet()
        {
            this.Items = this._service.AllItems;
        }
    }
}

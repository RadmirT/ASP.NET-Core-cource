using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApplication.ServicesLayer;

namespace SampleApplication.Pages.ToDos
{
    public class ViewToDoModel : PageModel
    {
        public ToDoItemViewModel Item { get; set; }

        public IActionResult OnGet(int id)
        {
            this.Item = TaskService.AllTasks.FirstOrDefault(x => x.Id == id);
            if (this.Item == null)
            {
                return this.RedirectToPage("RecentToDos");
            }
            return this.Page();
        }
    }
}

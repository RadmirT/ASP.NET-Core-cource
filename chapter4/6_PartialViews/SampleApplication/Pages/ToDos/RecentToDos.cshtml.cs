using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApplication.ServicesLayer;

namespace SampleApplication.Pages.ToDos
{
    public class RecentToDosModel : PageModel
    {
        public int RecentToDosToDisplay { get; } = 3;

        public IEnumerable<ToDoItemViewModel> RecentToDos { get; set; }

        public void OnGet()
        {
            this.RecentToDos = TaskService.AllTasks.Take(this.RecentToDosToDisplay);
        }
    }
}

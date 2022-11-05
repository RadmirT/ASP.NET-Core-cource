using System.Collections.Generic;
using ATypicalRazorPage.ServicesLayer.ToDo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATypicalRazorPage.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly IToDoService service;
        public List<ToDoListModel> Items { get; set; }

        public CategoryModel(IToDoService service)
        {
            this.service = service;
        }

        public ActionResult OnGet(string category)
        {
            this.Items = this.service.GetItemsForCategory(category);
            return this.Page();
        }
    }
}
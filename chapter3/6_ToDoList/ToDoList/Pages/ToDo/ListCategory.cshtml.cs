using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.ServicesLayer;

namespace ToDoList.Pages.ToDo
{
    public class ListCategoryModel : PageModel
    {
        private IToDoService service;
        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        public ListCategoryModel(IToDoService service)
        {
            this.service = service;
        }
        public IActionResult OnGet()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            //TODO: Validate the parameters
            this.Tasks = this.service.GetToDoItems(Input.Category, this.Input.Username)
                .Select(x => new Task(x.Number, x.Title));
            return Page();
        }


        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Category { get; set; }
        }

        public class Task
        {
            public Task(int id, string description)
            {
                Id = id;
                Description = description;
            }

            public int Id { get; }
            public string Description { get; set; }
        }
    }
}